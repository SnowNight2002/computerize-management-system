using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Better_Limited
{
    public partial class frmCreateDefect : Form
    {
        public frmCreateDefect(string employeeID, string position)
        {
            InitializeComponent();
            txtEmpID.Text = employeeID;
            txtPosition.Text = position;
        }

        private void checkOld_CheckedChanged(object sender, EventArgs e)
        {
            if (checkOld.Checked == true)
            {
                txtName.ReadOnly = false;
                txtPrice.ReadOnly = false;
                txtQty.ReadOnly = false;
            }
            else
            {
                txtName.ReadOnly = true;
                txtPrice.ReadOnly = true;
                txtQty.ReadOnly = true;
            }
        }

        private void frmCreateDefect_Load(object sender, EventArgs e)
        {
            using (var productContext = new WindowsFormsApp1.better_limitedEntities())
            {
                var product = (from list in productContext.products
                           select list);    // select * from payments

                foreach (var product2 in product.ToList())
                {
                    dataGridView1.Rows.Add(product2.productname, 0, 0, 0, product2.productUnitprice);
                }
            }
        }

        public DataGridViewTextBoxEditingControl CellEdit = null;

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.dataGridView1.CurrentCellAddress.X == 2)
            {
                CellEdit = (DataGridViewTextBoxEditingControl)e.Control;
                CellEdit.SelectAll();
                CellEdit.KeyPress += Cells_KeyPress;
            }
        }
        private void Cells_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((this.dataGridView1.CurrentCellAddress.X == 2))
            {
                if (!(e.KeyChar >= '0' && e.KeyChar <= '9')) e.Handled = true;
                if (e.KeyChar == '\b') e.Handled = false;
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++) {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[1].Value) == true)
                {
                    dataGridView1.Rows[i].Cells[3].Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value) * Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                }
                else
                {
                    dataGridView1.Rows[i].Cells[3].Value = 0;
                }
            }
        }
        private void InsertRecord()
        {
            using (var defectItemContext = new WindowsFormsApp1.better_limitedEntities())
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value) > 0)
                    {
                        var defectItem = new WindowsFormsApp1.defect_item();

                        defectItem.itemName = (Convert.ToString(dataGridView1.Rows[i].Cells[0].Value));
                        defectItem.itemQuantity = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
                        defectItem.returnPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                        defectItem.employeeID = txtEmpID.Text;

                        defectItemContext.defect_items.Add(defectItem);
                    }
                }
                try
                {
                    defectItemContext.SaveChanges();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void InsertOld()
        {
            using (var defectItemContext = new WindowsFormsApp1.better_limitedEntities())
            {
                if (checkOld.Checked == true)
                {
                     var defect = new WindowsFormsApp1.defect_item();
                     defect.itemName = txtName.Text;
                     defect.itemQuantity = Convert.ToInt32(txtQty.Text);
                     defect.returnPrice = Convert.ToDouble(txtPrice.Text);
                     defect.employeeID = txtEmpID.Text;

                    defectItemContext.defect_items.Add(defect);
                }
                try
                {
                    defectItemContext.SaveChanges();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void btnFinish_Click(object sender, EventArgs e)
        {
            
            if(checkOld.Checked == true)
            {
                int checkInt = 0;
                double checkDouble = 0;
                bool isDouble = false;
                bool isNumber = false;
                isNumber = int.TryParse(txtQty.Text, out checkInt);
                isDouble = double.TryParse(txtPrice.Text, out checkDouble);

                if (!isNumber)
                {
                    MessageBox.Show("Item Quantity must be int");
                }
                else if (!isDouble)
                {
                    MessageBox.Show("Item Price must be number");
                }
                else
                {
                    InsertRecord();
                    InsertOld();
                    MessageBox.Show("A defect item is recorded successful.");
                    string employeeID = txtEmpID.Text;
                    string position = txtPosition.Text;
                    frmCheckDefect checkDefect = new frmCheckDefect(employeeID, position);
                    checkDefect.Show();
                    this.Hide();
                }
            }
            else
            {
                int total = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value) != 0)
                    {
                        total += 1;
                    }
                }
                if (total == 0)
                {
                    MessageBox.Show("Please select an defect item");
                }
                else
                {
                    InsertRecord();
                    MessageBox.Show("A defect item is recorded successful.");
                    string employeeID = txtEmpID.Text;
                    string position = txtPosition.Text;
                    frmCheckDefect checkDefect = new frmCheckDefect(employeeID, position);
                    checkDefect.Show();
                    this.Hide();
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            string employeeID = txtEmpID.Text;
            string position = txtPosition.Text;
            frmCheckDefect checkDefect = new frmCheckDefect(employeeID, position);
            checkDefect.Show();
            this.Hide();
        }
    }
}
