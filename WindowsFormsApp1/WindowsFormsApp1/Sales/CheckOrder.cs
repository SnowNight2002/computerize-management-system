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
    public partial class frmOrder : Form
    {
        public frmOrder(string employeeID, string position)
        {
            InitializeComponent();
            label1.Text = employeeID;
            label2.Text = position;
        }

        private void paymentBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.paymentBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.better_limitedDataSet);

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            using (var orderContext = new WindowsFormsApp1.better_limitedEntities())
            {
                var ord = (from list in orderContext.payment
                           select list);    // select * from payments

                foreach (var ord2 in ord.ToList())
                {
                    dataGridView1.Rows.Add(ord2.Order_ID , ord2.Payment1, ord2.Created_Date, ord2.EmpID, ord2.PaymentMethod, ord2.Region, ord2.TotalPrice);
                }
            }
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            string employeeID = label1.Text;
            string position = label2.Text;
            frmCreate create = new frmCreate(employeeID, position);
            create.Show();
            this.Hide();
        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            using (var orderContext = new WindowsFormsApp1.better_limitedEntities()) {
                string employeeID = label1.Text;
                string position = label2.Text;
                if (e.ColumnIndex == 7)
                {
                    if (Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value) == "Payment Receipt")
                    {
                        string orderID = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                        string paymentMethod = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
                        string empID = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                        string region = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
                        string totalAmount = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[6].Value);
                        frmPayDetail detail = new frmPayDetail(orderID,employeeID,position,paymentMethod,empID,region,totalAmount);
                        detail.Show();
                        this.Hide();
                    }
                    if(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value) == "Deposit Receipt")
                    {
                        string orderID = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                        string paymentMethod = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
                        string empID = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                        string region = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
                        string totalAmount = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[6].Value);
                        frmDepositDetail detail= new frmDepositDetail(orderID, employeeID, position, paymentMethod, empID, region, totalAmount);
                        detail.Show();
                        this.Hide();
                    }
                }
                if (e.ColumnIndex == 8)
                {
                        string orderID = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                        frmUpdate update = new frmUpdate(orderID, employeeID, position);
                        update.Show();
                        this.Hide();
                }
                if (e.ColumnIndex == 9)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to delete a order record?", "Information", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string orderID = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                        var orderDel = (from list in orderContext.payment where list.Order_ID == orderID select list).First();
                        orderContext.payment.Remove(orderDel);
                        orderContext.SaveChanges();
                        MessageBox.Show("Successfully deleted");
                        frmOrder order = new frmOrder(employeeID, position);
                        order.Show();
                        this.Hide();
                    }  
                    return;
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (var orderContext = new WindowsFormsApp1.better_limitedEntities())
            { //keyword search
                if (txtSearch.Text != "")
                {
                    dataGridView1.Rows.Clear();
                    string keyword = txtSearch.Text;
                    var resultSet = from list in orderContext.payment
                                    where list.Order_ID.Contains(keyword)
                                    select list;
                    foreach (var emp2 in resultSet.ToList())
                    {
                        dataGridView1.Rows.Add(emp2.Order_ID, emp2.Payment1, emp2.Created_Date, emp2.EmpID, emp2.PaymentMethod, emp2.Region, emp2.TotalPrice);
                    }
                }
                else
                {
                    using (var orderContext1 = new WindowsFormsApp1.better_limitedEntities())
                    {
                        var ord = (from list in orderContext1.payment
                                   select list);    // select * from payments

                        foreach (var ord2 in ord.ToList())
                        {
                            dataGridView1.Rows.Add(ord2.Order_ID, ord2.Payment1, ord2.Created_Date, ord2.EmpID, ord2.PaymentMethod, ord2.Region, ord2.TotalPrice);
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string employeeID = label1.Text;
            string position = label2.Text;
            frmCheckDelivery CheckDelivery = new frmCheckDelivery(employeeID, position);
            CheckDelivery.Show();
            this.Hide();
        }
        private void btnDefect_Click(object sender, EventArgs e)
        {
            string employeeID = label1.Text;
            string position = label2.Text;
            frmCheckDefect CheckDelivery = new frmCheckDefect(employeeID, position);
            CheckDelivery.Show();
            this.Hide();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            string employeeID = label1.Text;
            string position = label2.Text;
            frmStock checkStock = new frmStock(employeeID, position);
            checkStock.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            WindowsFormsApp1.Form1 frmForm = new WindowsFormsApp1.Form1();
            frmForm.Show();
            this.Hide();
        }
    }
}
