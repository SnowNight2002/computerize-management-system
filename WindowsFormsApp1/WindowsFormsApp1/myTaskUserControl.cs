using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLtd
{
    public partial class myTaskUserControl : UserControl
    {
        //USER 
        private USER CURRENT_USER;


        //MySQL
        private string mySQLStatement;
        private MyDB con;
        //private DataTable dt;

        //Order Info
        private string workerid;
        private string jobType;
        private string orderId;
        private string deliveryTime;
        private string timeslot;


        public myTaskUserControl()
        {
            InitializeComponent();
            con = new MyDB();
            lblStatus.BackColor = System.Drawing.Color.Transparent;
        }

        public void SetOrderDetail(string jobType, string empid, string orderId,
            string customerName, string phone, string customerAddress, string deliveryTime,
            string timeslot, USER user)
        {

            //SET USER
            this.CURRENT_USER = user;
            this.jobType = jobType;
            this.orderId = orderId;
            this.deliveryTime = deliveryTime;
            this.timeslot = timeslot;
            this.workerid = empid;

            txtReceiverName.Text = customerName;
            txtAddress.Text = customerAddress;
            if (jobType == "Delivery Worker")
            {
                gboOrder.Text = "Delivery Order #" + orderId;
            }
            else
            {
                label2.Text = "Install Time:";
                gboOrder.Text = "Installation Order #" + orderId;
            }

            txtPhone.Text = phone;


            if (timeslot == "1")
            {
                txtDeliverTime.Text = Convert.ToDateTime(deliveryTime).ToShortDateString() + " Session 1:  (9:00am – 12:00nn) ";
            }
            else if (timeslot == "2")
            {
                txtDeliverTime.Text = Convert.ToDateTime(deliveryTime).ToShortDateString() + " Session 2:  (1:00pm – 5:00pm) ";
            }
            else
            {
                txtDeliverTime.Text = Convert.ToDateTime(deliveryTime).ToShortDateString() + " Session 3:  (6:00pm – 10:00pm)";
            }
        }

        private void completeOrder()
        {
            if (jobType == "Delivery Worker")
            {
                //Convert.ToDateTime(dt2.Rows[0]["expectdeliverydate"].ToString())
                if (CURRENT_USER.EmpId != workerid)
                {
                    MessageBox.Show("User not match");
                }
                else if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) < Convert.ToDateTime(deliveryTime))
                {
                    MessageBox.Show("Earlier than Order Request time, Update fail");
                }
                else if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) == Convert.ToDateTime(deliveryTime))
                {
                    //Update order completed time
                    mySQLStatement =
                        "Update deliveryorder set deliverystatus='Delivered', d" +
                        "eliverycompleteDate ='" + DateTime.Now.ToString("yyyy-MM-dd") + "' , " +
                        "EmpID = '" + CURRENT_USER.EmpId + "' where deliveryid ='" + orderId + "'";

                    if (con.InsertToMySQL(mySQLStatement))
                    {
                        MessageBox.Show("Order is complete!");
                        lblStatus.Text = "Completed";
                        //Refresh parent from
                        btnCOMPLETE.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Status Update fail");
                    }
                }
                else
                {
                    MessageBox.Show("Order time expired");
                    //Change the status to expired

                    mySQLStatement = "Update deliveryorder set deliverystatus='Expired' where deliveryid ='" + orderId + "'";
                    if (con.InsertToMySQL(mySQLStatement))
                    {
                        MessageBox.Show("Order Update to expired");
                        lblStatus.Text = "Expired";
                        //Refresh parent from
                        btnCOMPLETE.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Status Update fail");
                    }
                }
            }
            else
            {

                if (CURRENT_USER.EmpId != workerid)
                {
                    MessageBox.Show("User not match");
                }
                else if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) < Convert.ToDateTime(deliveryTime))
                {
                    MessageBox.Show("Earlier than Order Request time, Update fail");
                }
                else if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) == Convert.ToDateTime(deliveryTime))
                {
                    //Update order completed time
                    mySQLStatement =
                        "Update installationrequest set installStatus='Completed', installComDate = " +
                        "'" + DateTime.Now.ToString("yyyy-MM-dd") + "', installEmpID='" + CURRENT_USER.EmpId + "' " +
                        "where installRequestid='" + orderId + "'";

                    if (con.InsertToMySQL(mySQLStatement))
                    {
                        MessageBox.Show("Order Completed");
                        lblStatus.Text = "Completed";
                        //Refresh parent from
                        btnCOMPLETE.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Status Update fail");
                    }
                }
                else
                {
                    MessageBox.Show("Order time expired");
                    //Change the status to expired

                    mySQLStatement = "Update installationrequest set installStatus='Expired' where installRequestid ='" + orderId + "'";
                    if (con.InsertToMySQL(mySQLStatement))
                    {
                        MessageBox.Show("Order Update to expired");
                        lblStatus.Text = "Expired";
                        //Refresh parent from
                        btnCOMPLETE.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Status Update fail");
                    }
                }
            }
        }

        private void btnCOMPLETE_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are You Sure?", "Title", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                this.completeOrder();
            }
        }
        private void gboOrder_MouseHover(object sender, EventArgs e)
        {
            this.gboOrder.BackColor = Color.FromArgb(204, 204, 204);
        }
    }
}
