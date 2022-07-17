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
    public partial class frmEditStockCN : Form
    {
        public frmEditStockCN(string employeeID, string position)
        {
            InitializeComponent();
            txtEmpID.Text = employeeID;
            txtPosition.Text = position;
        }

        private void frmEditStockCN_Load(object sender, EventArgs e)
        {
            using (var stockContext = new WindowsFormsApp1.better_limitedEntities())
            {
                var stock = (from list in stockContext.products
                             select list);    // select * from product

                foreach (var stock2 in stock.ToList())
                {
                    dataGridView1.Rows.Add(stock2.productid, stock2.productname, 0, stock2.productUnitQty, stock2.StockMaxNumber, stock2.productUnitprice, 0);
                }
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value) < (Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * 0.2))
                {
                    dataGridView1.Rows[i].Cells[6].Value = "缺货";

                }
                else
                {
                    dataGridView1.Rows[i].Cells[6].Value = "充足";
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value) < (Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * 0.2))
                {
                    dataGridView1.Rows[i].Cells[6].Value = "缺货";

                }
                else
                {
                    dataGridView1.Rows[i].Cells[6].Value = "充足";
                }
            }
        }
        private void updateRecord()
        {
            using (var updateContext = new WindowsFormsApp1.better_limitedEntities())
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string productName = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);

                    if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[2].Value) == true)
                    {
                        var results = updateContext.products.FirstOrDefault(result1 => result1.productname.Equals(productName));

                        results.productname = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                        results.productid = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                        results.productUnitprice = Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                        results.productUnitQty = Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
                        results.StockMaxNumber = Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                        results.EmpID = txtEmpID.Text;
                    }
                    try
                    {
                        updateContext.SaveChanges();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            int time = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[2].Value) == true)
                {
                    time += 1;
                }
            }
            if (time == 0)
            {
                MessageBox.Show("You need to select an update item to finish updated.");
            }
            else
            {
                updateRecord();
                MessageBox.Show("Updated finished");
                string employeeID = txtEmpID.Text;
                string position = txtPosition.Text;
                frmStockCN stock = new frmStockCN(employeeID, position);
                stock.Show();
                this.Hide();
            }
        }

        public DataGridViewTextBoxEditingControl CellEdit = null;
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.dataGridView1.CurrentCellAddress.X == 5 || this.dataGridView1.CurrentCellAddress.X == 3 || this.dataGridView1.CurrentCellAddress.X == 4)
            {
                CellEdit = (DataGridViewTextBoxEditingControl)e.Control;
                CellEdit.SelectAll();
                CellEdit.KeyPress += Cells_KeyPress;
            }
        }
        private void Cells_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((this.dataGridView1.CurrentCellAddress.X == 5) || this.dataGridView1.CurrentCellAddress.X == 3 || this.dataGridView1.CurrentCellAddress.X == 4)
            {
                if (!(e.KeyChar >= '0' && e.KeyChar <= '9')) e.Handled = true;
                if (e.KeyChar == '\b') e.Handled = false;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            string employeeID = txtEmpID.Text;
            string position = txtPosition.Text;
            frmStockCN stock = new frmStockCN(employeeID, position);
            stock.Show();
            this.Hide();
        }
    }
}
