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
    public partial class frmStock : Form
    {
        public frmStock(string employeeID, string position)
        {
            InitializeComponent();
            txtEmpID.Text = employeeID;
            txtPosition.Text = position;
        }

        private void frmStock_Load(object sender, EventArgs e)
        {
            using (var stockContext = new WindowsFormsApp1.better_limitedEntities())
            {
                var stock = (from list in stockContext.products
                           select list);    // select * from product

                foreach (var stock2 in stock.ToList())
                {
                    dataGridView1.Rows.Add(stock2.productid, stock2.productname, stock2.productUnitprice, stock2.productUnitQty, stock2.StockMaxNumber, 0, stock2.EmpID);
                }
            }

            string record = "";

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value) < (Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * 0.2))
                {
                    dataGridView1.Rows[i].Cells[5].Value = "Out of Stock";
                    record += (dataGridView1.Rows[i].Cells[0].Value + ", ");
                }
                else
                {
                    dataGridView1.Rows[i].Cells[5].Value = "Sufficient";
                }
            }
            MessageBox.Show("Out stock ID is " + record + "please call to inventory department quickly.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string employeeID = txtEmpID.Text;
            string position = txtPosition.Text;
            frmOrder order = new frmOrder(employeeID, position);
            order.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            using (var productContext = new WindowsFormsApp1.better_limitedEntities())
            {
                string employeeID = txtEmpID.Text;
                string position = txtPosition.Text;

                if (e.ColumnIndex == 7)
                {
                    if (txtPosition.Text != "Sales Manager")
                    {
                        MessageBox.Show("You don't have permission");
                    }
                    else
                    {
                        frmEditStock edit = new frmEditStock(employeeID, position);
                        edit.Show();
                        this.Hide();
                    }
                }
                if (e.ColumnIndex == 8)
                {
                    if (txtPosition.Text != "Sales Manager")
                    {
                        MessageBox.Show("You don't have permission");
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Do you want to delete an item record?", "Information", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            int productID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                            var productDel = (from list in productContext.products where list.productid == productID select list).First();
                            productContext.products.Remove(productDel);
                            productContext.SaveChanges();
                            MessageBox.Show("Successfully deleted");
                            frmStock stock = new frmStock(employeeID, position);
                            stock.Show();
                            this.Hide();
                        }
                    }
                    return;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtPosition.Text != "Sales Manager")
            {
                MessageBox.Show("You don't have permission");
            }
            else
            {
                string employeeID = txtEmpID.Text;
                string position = txtPosition.Text;
                frmCreateItem create = new frmCreateItem(employeeID, position);
                create.Show();
                this.Hide();
            }
        }
    }
}
