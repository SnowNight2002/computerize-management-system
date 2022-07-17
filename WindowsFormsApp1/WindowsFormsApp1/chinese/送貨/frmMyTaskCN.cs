using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BLtd
{
    public partial class frmMyTaskCN : Form
    {
        private USER CURRENT_USER;

        private MyDB con;
        private string mySQLStatement;
        private DataTable dt;
        private myTaskUserControlCN muc;

        public frmMyTaskCN(USER user)
        {
            InitializeComponent();
            con = new MyDB();

            //Initialize USER 
            CURRENT_USER = user;
            lblUserName.Text = CURRENT_USER.Name;

            if (CURRENT_USER.Role == "Technical Support")
            {
                label2.Text = "即将到来的安装请求";
            }
        }

        private void frmMyTask_Load(object sender, EventArgs e)
        {
            GetTodayJob();
        }

        private void GetTodayJob()
        {
            if (CURRENT_USER.Role == "Delivery Worker")
            {
                mySQLStatement =
                    "Select * from deliveryorder d, customer c where d.Customerid = " +
                    "c.Customerid and d.EmpID ='" + CURRENT_USER.EmpId + "' and d.expectdeliverydate = " +
                    "'" + DateTime.Now.ToString("yyyy-MM-dd") + "' and d.deliverystatus = 'Processing' ";

                dt = con.MySQLStatementToDatatable(mySQLStatement);

                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        muc = new myTaskUserControlCN();
                        muc.SetOrderDetail(
                            "Delivery Worker",
                            CURRENT_USER.EmpId,
                            dt.Rows[i]["deliveryid"].ToString(),
                            dt.Rows[i]["customername"].ToString(),
                            dt.Rows[i]["PhoneNumber"].ToString(),
                            dt.Rows[i]["CustomerAddress"].ToString(),
                            dt.Rows[i]["expectdeliverydate"].ToString(),
                            dt.Rows[i]["timeslot"].ToString(),
                            CURRENT_USER
                            );
                        flpTaskContainer.Controls.Add(muc);
                    }
                }
            }
            else
            {
                mySQLStatement =
                     "SELECT * FROM installationrequest NATURAL JOIN deliveryorder NATURAL JOIN customer " +
                     "where InstallationNeed='Y' and deliverystatus='Delivered' and installStatus= 'Processing'" +
                     "and installEmpID = '" + CURRENT_USER.EmpId + "'";

                dt = con.MySQLStatementToDatatable(mySQLStatement);

                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        muc = new myTaskUserControlCN();
                        muc.SetOrderDetail(
                            "Technical Support",
                            CURRENT_USER.EmpId,
                            dt.Rows[i]["installRequestid"].ToString(),
                            dt.Rows[i]["customername"].ToString(),
                            dt.Rows[i]["PhoneNumber"].ToString(),
                            dt.Rows[i]["CustomerAddress"].ToString(),
                            dt.Rows[i]["installDate"].ToString(),
                            dt.Rows[i]["installTimeslot"].ToString(),
                            CURRENT_USER
                            );
                        flpTaskContainer.Controls.Add(muc);
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            flpTaskContainer.Controls.Clear();
            GetTodayJob();
        }
    }
}

