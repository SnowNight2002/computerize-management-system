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
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            using (var customerContext = new WindowsFormsApp1.better_limitedEntities())
            {
                var customer = (from list in customerContext.customer
                            select list);    // select * from customer

                foreach (var customer2 in customer.ToList())
                {
                    dataGridView1.Rows.Add(customer2.Customerid, customer2.customername, customer2.CustomerAddress, customer2.District, customer2.PhoneNumber);
                }
            }
        }

        private void InsertCustomer()
        {
            using (var customerContext = new WindowsFormsApp1.better_limitedEntities())
            {
                var customer = new WindowsFormsApp1.customer();

                int id = dataGridView1.Rows.Count - 1;
                if (Convert.ToString(dataGridView1.Rows[id].Cells[0].Value) != "")
                {
                    customer.Customerid = (Convert.ToInt32(dataGridView1.Rows[id].Cells[0].Value) + 1);
                }
                else
                {
                    customer.Customerid = 1;
                }
                customer.customername = txtName.Text;
                customer.CustomerAddress = txtAddress.Text;
                customer.District = cmboxDistrict.Text;
                customer.PhoneNumber = Convert.ToInt32(txtPhone.Text);
                customerContext.customer.Add(customer);
                try
                {
                    customerContext.SaveChanges();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtPhone.Text==""|| txtAddress.Text=="" || cmboxDistrict.Text=="")
            {
                MessageBox.Show("Please input complete new customer information.");
            }
            else
            {
                InsertCustomer();
                MessageBox.Show("A new customer '" + txtName.Text + "' created finish.");
                frmCustomer custormer = new frmCustomer();
                this.Hide();
                custormer.Show();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (var customerContext = new WindowsFormsApp1.better_limitedEntities())
            { //keyword search
                dataGridView1.Rows.Clear();
                if (txtSearch.Text != "")
                {
                    int keyword = Convert.ToInt32(txtSearch.Text);
                    var resultSet = from list in customerContext.customer
                                    where list.PhoneNumber.Equals(keyword)
                                    select list;
                    foreach (var customer in resultSet.ToList())
                    {
                        dataGridView1.Rows.Add(customer.Customerid, customer.customername, customer.CustomerAddress, customer.District, customer.PhoneNumber);
                    }
                }
                else
                {
                    var customer = (from list in customerContext.customer
                                    select list);    // select * from payments

                    foreach (var customer2 in customer.ToList())
                    {
                        dataGridView1.Rows.Add(customer2.Customerid, customer2.customername, customer2.CustomerAddress, customer2.District, customer2.PhoneNumber);
                    }
                }
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
