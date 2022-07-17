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
    public partial class frmSelectItem : Form
    {
        public frmSelectItem(string employeeID, string position, string install, string timeslot, string date)
        {
            InitializeComponent();
            txtEmpID.Text = employeeID;
            txtPosition.Text = position;
            txtInstall.Text = install;
            txtTimeslot.Text = timeslot;
            txtDate.Text = date;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[3].Value) == true)
                    dataGridView1.Rows[i].Cells[5].Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value) * Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                else
                {
                    dataGridView1.Rows[i].Cells[5].Value = 0;
                }
            }
        }

        private void frmSelectItem_Load(object sender, EventArgs e)
        {
            using (var ItemContext = new WindowsFormsApp1.better_limitedEntities())
            {
                var item = (from list in ItemContext.products
                            select list);    // select * from product

                foreach (var item2 in item.ToList())
                {
                    dataGridView1.Rows.Add(item2.productid, item2.productname, item2.productUnitprice, false, "0", "0");
                }

                var delivery = (from id in ItemContext.deliveryorder
                                select id);
                foreach (var delivery2 in delivery.ToList())
                {
                    dataGridView2.Rows.Add(delivery2.deliveryid, delivery2.deliverystatus);
                }
            }
        }
        private void InsertDelivery()
        {
            using (var deliveryContext = new WindowsFormsApp1.better_limitedEntities())
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value) > 0)
                    {
                        var deliveryProduct = new WindowsFormsApp1.deliveryorderproduct();

                        int id = dataGridView2.Rows.Count - 1;
                        deliveryProduct.deliveryid = (Convert.ToInt32(dataGridView2.Rows[id].Cells[0].Value));
                        deliveryProduct.buyqty = Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                        deliveryProduct.amount = Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                        deliveryProduct.productid = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                        deliveryContext.deliveryorderproduct.Add(deliveryProduct);
                    }
                }
                try
                {
                    deliveryContext.SaveChanges();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void InsertInstall()
        {
            using (var installContext = new WindowsFormsApp1.better_limitedEntities())
            {
                var install = new WindowsFormsApp1.installationrequest();

                int id = dataGridView2.Rows.Count - 1;
                install.installEmpID = null;
                install.installDate = Convert.ToDateTime(txtDate.Text);
                install.installTimeslot = Convert.ToInt32(txtTimeslot.Text);
                install.installStatus = "Processing";
                install.installSignImage = null;
                install.deliveryid = (Convert.ToInt32(dataGridView2.Rows[id].Cells[0].Value));

                installContext.installationrequest.Add(install);
                try
                {
                    installContext.SaveChanges();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void btnFinish_Click(object sender, EventArgs e)
        {
            double price = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[3].Value) == true)
                {
                    dataGridView1.Rows[i].Cells[5].Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value) * Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                    price = price+Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                }
                else
                {
                    dataGridView1.Rows[i].Cells[5].Value = 0;
                }
            }
            if (price == 0)
            {
                MessageBox.Show("Please select a delivery item");
            }
            else
            {
                InsertDelivery();
                if (txtInstall.Text == "Y")
                {
                    InsertInstall();
                }
                MessageBox.Show("A new delivery order is created finish.");
                string employeeID = txtEmpID.Text;
                string position = txtPosition.Text;
                frmOrder order = new frmOrder(employeeID,position);
                order.Show();
                this.Hide();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            string employeeID = txtEmpID.Text;
            string position = txtPosition.Text;
            frmDelivery delivery = new frmDelivery(employeeID, position);
            delivery.Show();
            this.Hide();
        }

        public DataGridViewTextBoxEditingControl CellEdit = null;
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.dataGridView1.CurrentCellAddress.X == 4)
            {
                CellEdit = (DataGridViewTextBoxEditingControl)e.Control;
                CellEdit.SelectAll();
                CellEdit.KeyPress += Cells_KeyPress;
            }
        }
        private void Cells_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((this.dataGridView1.CurrentCellAddress.X == 4))
            {
                if (!(e.KeyChar >= '0' && e.KeyChar <= '9')) e.Handled = true;
                if (e.KeyChar == '\b') e.Handled = false;
            }
        }
    }
}
