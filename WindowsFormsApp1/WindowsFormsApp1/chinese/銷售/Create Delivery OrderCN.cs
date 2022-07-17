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
    public partial class frmDeliveryCN : Form
    {
        public frmDeliveryCN(string employeeID, string position)
        {
            InitializeComponent();
            txtEID.Text = employeeID;
            txtPosition.Text = position;
        }

        private void frmDelivery_Load(object sender, EventArgs e)
        {
            using (var orderContext = new WindowsFormsApp1.better_limitedEntities())
            {
                var order = (from list in orderContext.deliveryorder select list);

                foreach (var order2 in order.ToList())
                {
                    dataGridView1.Rows.Add(order2.expectdeliverydate, order2.timeslot);
                }
            }
        }

        private bool checkTimeslot()
        {
            bool result = true;
            for(int i =0; i<dataGridView1.Rows.Count; i++)
            {
                DateTime date = Convert.ToDateTime(dataGridView1.Rows[i].Cells[0].Value);
                if (date.ToString("d")  == (dateTimePicker1.Value.ToString("d")) && Convert.ToString(dataGridView1.Rows[i].Cells[1].Value) == cmboxTimeslot.Text)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
        private void InsertDelivery()
        {
            using (var deliveryContext = new WindowsFormsApp1.better_limitedEntities())
            {
                var delivery = new WindowsFormsApp1.deliveryorder();

                delivery.docreatedate = Convert.ToDateTime(System.DateTime.Now.ToString("d"));
                delivery.deliverystatus = "Processing";
                delivery.expectdeliverydate = Convert.ToDateTime(dateTimePicker1.Value.ToString("d"));
                delivery.Customerid = Convert.ToInt32(txtCusID.Text);
                delivery.timeslot = Convert.ToInt32(cmboxTimeslot.Text);
                if (checkInstall.Checked == true)
                {
                    delivery.InstallationNeed = "Y";
                }
                else
                {
                    delivery.InstallationNeed = "N";
                }
                deliveryContext.deliveryorder.Add(delivery);
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

        private bool CheckValidCustomerID(int CID)
        {
            bool result = false;
            using (var orderContext = new WindowsFormsApp1.better_limitedEntities())
            {
                var cus = from list in orderContext.customer
                          select list;    // select * from employees

                foreach (var cus2 in cus.ToList())
                {
                    if (cus2.Customerid == CID)
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }
        private void btnFinish_Click(object sender, EventArgs e)
        {
            int check;
            if (!int.TryParse(txtCusID.Text, out check))
            {
                MessageBox.Show("客户 ID 必须是整数");
            }
            else if (txtCusID.Text == "")
            {
                MessageBox.Show("请输入客户ID");
            }
            else if (txtCusID.Text == "" || !CheckValidCustomerID(Convert.ToInt32(txtCusID.Text)))
            {
                MessageBox.Show("请输入正确的客户 ID");
            }
            else if (checkTimeslot()==false)
            {
                MessageBox.Show("此时已经有订单，请选择其他时段！");
            }
            else if(cmboxTimeslot.Text == "")
            {
                MessageBox.Show("请选择时间段");
            }
            else
            {
                InsertDelivery();
                MessageBox.Show("一个新的交货单被创建完成。 请立即选择项目。");
                if (checkInstall.Checked == true)
                {
                    string install = "Y";
                    string employeeID = txtEID.Text;
                    string position = txtPosition.Text;
                    string timeslot = cmboxTimeslot.Text;
                    string date = dateTimePicker1.Value.ToString("d");

                    frmSelectItem item = new frmSelectItem(employeeID, position, install, timeslot, date);
                    item.Show();
                    this.Hide();
                }
                else
                {
                    string install = "N";
                    string employeeID = txtEID.Text;
                    string position = txtPosition.Text;
                    string timeslot = cmboxTimeslot.Text;
                    string date = dateTimePicker1.Value.ToString("d");

                    frmSelectItem item = new frmSelectItem(employeeID, position, install, timeslot, date);
                    item.Show();
                    this.Hide();
                }
            }
        }
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            frmCustomerCN customer = new frmCustomerCN();
            customer.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            string employeeID = txtEID.Text;
            string position = txtPosition.Text;
            frmOrderCN order = new frmOrderCN(employeeID, position);
            order.Show();
            this.Hide();
        }
    }
}
