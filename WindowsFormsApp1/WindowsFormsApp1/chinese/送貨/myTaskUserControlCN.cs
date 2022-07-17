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
    public partial class myTaskUserControlCN : UserControl
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


        public myTaskUserControlCN()
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
                gboOrder.Text = "交付订单 ＃" + orderId;
            }
            else
            {
                label2.Text = "安装时间：";
                gboOrder.Text = "安装订单 #" + orderId;
            }

            txtPhone.Text = phone;


            if (timeslot == "1")
            {
                txtDeliverTime.Text = Convert.ToDateTime(deliveryTime).ToShortDateString() + " 第 1 节：（上午 9:00 – 中午 12:00） ";
            }
            else if (timeslot == "2")
            {
                txtDeliverTime.Text = Convert.ToDateTime(deliveryTime).ToShortDateString() + "第 2 节：（下午 1:00 – 下午 5:00）";
            }
            else
            {
                txtDeliverTime.Text = Convert.ToDateTime(deliveryTime).ToShortDateString() + "第 3 节：（下午 6:00 – 晚上 10:00）";
            }
        }

        private void completeOrder()
        {
            if (jobType == "Delivery Worker")
            {
                //Convert.ToDateTime(dt2.Rows[0]["expectdeliverydate"].ToString())
                if (CURRENT_USER.EmpId != workerid)
                {
                    MessageBox.Show("用户不匹配");
                }
                else if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) < Convert.ToDateTime(deliveryTime))
                {
                    MessageBox.Show("早于订单请求时间，更新失败");
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
                        MessageBox.Show("订单完成");
                        lblStatus.Text = "完成";
                        //Refresh parent from
                        btnCOMPLETE.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("状态更新失败");
                    }
                }
                else
                {
                    MessageBox.Show("下单时间已过");
                    //Change the status to expired

                    mySQLStatement = "Update deliveryorder set deliverystatus='Expired' where deliveryid ='" + orderId + "'";
                    if (con.InsertToMySQL(mySQLStatement))
                    {
                        MessageBox.Show("订单更新已过期");
                        lblStatus.Text = "过期";
                        //Refresh parent from
                        btnCOMPLETE.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("状态更新失败");
                    }
                }
            }
            else
            {

                if (CURRENT_USER.EmpId != workerid)
                {
                    MessageBox.Show("用户不匹配");
                }
                else if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) < Convert.ToDateTime(deliveryTime))
                {
                    MessageBox.Show("早于订单请求时间，更新失败");
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
                        MessageBox.Show("订单完成");
                        lblStatus.Text = "完成";
                        //Refresh parent from
                        btnCOMPLETE.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("状态更新失败");
                    }
                }
                else
                {
                    MessageBox.Show("下单时间已过");
                    //Change the status to expired

                    mySQLStatement = "Update installationrequest set installStatus='Expired' where installRequestid ='" + orderId + "'";
                    if (con.InsertToMySQL(mySQLStatement))
                    {
                        MessageBox.Show("订单更新已过期");
                        lblStatus.Text = "过期";
                        //Refresh parent from
                        btnCOMPLETE.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("状态更新失败");
                    }
                }
            }
        }

        private void btnCOMPLETE_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("你确定吗？", "Title", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
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
