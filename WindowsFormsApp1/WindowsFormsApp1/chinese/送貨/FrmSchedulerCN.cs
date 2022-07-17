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


//4 status summary

//Worker update function and verfie 

//Notification for installation staff when Delivery order complete

namespace BLtd
{
    public partial class FrmSchedulerCN : Form
    {
        private MyDB con;
        private DataTable dt;
        private DataTable dt2;
        private string mySQLStatement;

        //USER OBJECT
        private USER CURRENT_USER;

        private int sessionCount = 1;
        private string currentDate;

        public FrmSchedulerCN(USER user)
        {

            InitializeComponent();

            //CREATE NEW USER OBJECT WHEN THE FIRST FROM START
            CURRENT_USER = user;
            lblUserName.Text = CURRENT_USER.Name;

            lblTime1.BackColor = System.Drawing.Color.Transparent;
            lblTime2.BackColor = System.Drawing.Color.Transparent;
            lblTime3.BackColor = System.Drawing.Color.Transparent;

            con = new MyDB();
            lblNoRecord.Hide();

            // Update overdate delivery order to expired when program start
            UpdateMySQLExpiredOrder();

            SetSummaryPanel();
            ShowSessionDuration();
            DisplaySelectedSession();
        }

        private void SetSummaryPanel()
        {
            mySQLStatement = "select count(*) from deliveryorder where deliverystatus = 'Processing'";
            dt = con.MySQLStatementToDatatable(mySQLStatement);
            lblProcess.Text = dt.Rows[0]["count(*)"].ToString();

            mySQLStatement = "select count(*) from deliveryorder where deliverystatus = 'Delivered'";
            dt = con.MySQLStatementToDatatable(mySQLStatement);
            lblDelivered.Text = dt.Rows[0]["count(*)"].ToString();

            mySQLStatement = "select count(*) from deliveryorder where deliverystatus = 'Expired'";
            dt = con.MySQLStatementToDatatable(mySQLStatement);
            lblExpired.Text = dt.Rows[0]["count(*)"].ToString();
        }


        private void UpdateMySQLExpiredOrder()
        {
            mySQLStatement =
                "Select * from deliveryorder where expectdeliverydate " +
                "< '" + DateTime.Today.ToString("yyyy-MM-dd") + "'";
            //DateTime.Today.ToString("yyyy-MM-dd")
            dt = con.MySQLStatementToDatatable(mySQLStatement);

            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["deliverystatus"].ToString() == "Processing")
                    {
                        mySQLStatement =
                            "Update deliveryorder SET deliverystatus= 'Expired', " +
                            "EmpID=NULL WHERE deliveryid='" + dt.Rows[i]["deliveryid"].ToString() + "'";
                        if (!con.InsertToMySQL(mySQLStatement))
                        {
                            MessageBox.Show("订单状态更新失败");
                        }
                    }
                }
            }
        }

        public void DisplaySelectedSession()
        {
            ClearPanel();
            currentDate = dtpTimePick.Value.ToString("yyyy-MM-dd");

            //Get the data from MySQL for specify date
            mySQLStatement =
                "select * from deliveryorder where expectdeliverydate " +
                "= '" + currentDate + "'";
            dt = con.MySQLStatementToDatatable(mySQLStatement);
            RetrieveDeliveryOrder(dt);

            mySQLStatement =
                "select * from installationrequest i, deliveryorder d WHERE " +
                "i.deliveryid = d.deliveryid and installDate = '" + currentDate + "'";

            dt = con.MySQLStatementToDatatable(mySQLStatement);
            RetrieveInstallOrder(dt);
        }


        private void MydisplaySelectedSession(string orderID)
        {
            ClearPanel();
            mySQLStatement =
                "select * from deliveryorder where deliveryid ='" + orderID + "'";
            dt2 = con.MySQLStatementToDatatable(mySQLStatement);

            if (dt2.Rows.Count == 1)
            {
                lblNoRecord.Hide();

                dtpTimePick.Value = Convert.ToDateTime(dt2.Rows[0]["expectdeliverydate"]);
                ClearPanel();
                currentDate = dt2.Rows[0]["expectdeliverydate"].ToString();
                sessionCount = 1;
                while (!CheckTimeSlotBelong(Convert.ToInt32(dt2.Rows[0]["timeslot"])))
                {
                    sessionCount++;
                }
                ShowSessionDuration();
                RetrieveDeliveryOrder(dt2);
            }
            else
            {
                mySQLStatement =
                   "select * from installationrequest i, deliveryorder d WHERE " +
                   "i.deliveryid = d.deliveryid and installRequestid ='" + orderID + "'";

                dt2 = con.MySQLStatementToDatatable(mySQLStatement);

                if (dt2.Rows.Count == 1)
                {
                    lblNoRecord.Hide();

                    dtpTimePick.Value = Convert.ToDateTime(dt2.Rows[0]["installDate"]);
                    ClearPanel();

                    currentDate = dt2.Rows[0]["installDate"].ToString();
                    sessionCount = 1;
                    while (!CheckTimeSlotBelong(Convert.ToInt32(dt2.Rows[0]["installTimeslot"])))
                    {
                        sessionCount++;
                    }
                    ShowSessionDuration();
                    RetrieveInstallOrder(dt2);
                }
                else
                {
                    lblNoRecord.Show();
                }
            }
        }

        private void RetrieveDeliveryOrder(DataTable DeliveryList)
        {
            WorkerUserControlCN workerUc;
            // Insert data to the Worker User Control and add to the layoutgridview
            mySQLStatement =
                "SELECT * FROM `empolyee` WHERE Empdepartment = 'Delivery Worker'" +
                " or Empdepartment = 'Technical Support'";

            DataTable WorkerList = con.MySQLStatementToDatatable(mySQLStatement);
            for (int i = 0; i < DeliveryList.Rows.Count; i++)
            {
                workerUc = new WorkerUserControlCN();
                workerUc.SetControlType = "Delivery Worker";
                workerUc.FillWorkerItemList(WorkerList);
                workerUc.SetStatus();

                workerUc.Dstatus = DeliveryList.Rows[i]["deliverystatus"].ToString();
                workerUc.DeliveryId = DeliveryList.Rows[i]["deliveryid"].ToString();
                workerUc.DworkerId = DeliveryList.Rows[i]["EmpID"].ToString();

                int targetTimeSlot = int.Parse(DeliveryList.Rows[i]["timeslot"].ToString());
                workerUc.SetOrderDetail(
                    DeliveryList.Rows[i]["deliveryid"].ToString(),
                    DeliveryList.Rows[i]["expectdeliverydate"].ToString(),
                    DeliveryList.Rows[i]["timeslot"].ToString(),
                    DeliveryList.Rows[i]["docreatedate"].ToString(),
                    DeliveryList.Rows[i]["Customerid"].ToString(),
                    this,
                    CURRENT_USER
                    );
                if (CheckTimeSlotBelong(targetTimeSlot))
                {
                    AddToTimeTable(DeliveryList.Rows[i]["timeslot"].ToString(), workerUc, true);
                }
            }
        }


        private void RetrieveInstallOrder(DataTable DeliveryList)
        {
            WorkerUserControlCN workerUc;

            mySQLStatement =
                "SELECT * FROM `empolyee` WHERE Empdepartment = 'Delivery Worker'" +
                " or Empdepartment = 'Technical Support'";

            DataTable WorkerList2 = con.MySQLStatementToDatatable(mySQLStatement);

            for (int i = 0; i < DeliveryList.Rows.Count; i++)
            {
                workerUc = new WorkerUserControlCN();
                workerUc.SetControlType = "Technical Support";
                workerUc.SetStatus();

                workerUc.FillWorkerItemList(WorkerList2);
                workerUc.Istatus = dt.Rows[i]["installStatus"].ToString();
                workerUc.InstallId = dt.Rows[i]["installRequestid"].ToString();
                workerUc.IworkerId = dt.Rows[i]["installEmpID"].ToString();

                int targetTimeSlot2 = int.Parse(DeliveryList.Rows[i]["installTimeslot"].ToString());

                workerUc.SetOrderDetail(
                    DeliveryList.Rows[i]["deliveryid"].ToString(),
                    DeliveryList.Rows[i]["installDate"].ToString(),
                    DeliveryList.Rows[i]["timeslot"].ToString(),
                    DeliveryList.Rows[i]["docreatedate"].ToString(),
                    DeliveryList.Rows[i]["Customerid"].ToString(),
                    this,
                    CURRENT_USER);

                if (CheckTimeSlotBelong(targetTimeSlot2))
                {
                    AddToTimeTable(DeliveryList.Rows[i]["installTimeslot"].ToString(), workerUc, false);
                }
            }
        }


        //Checking which Session the order belongs to
        private bool CheckTimeSlotBelong(int ts)
        {
            int belongSession = 0;

            if (ts > 0 && ts <= 5)
            {
                belongSession = 1;
            }
            else if (ts > 5 && ts <= 10)
            {
                belongSession = 2;
            }
            else
            {
                belongSession = 3;
            }
            return (sessionCount == belongSession);
        }

        //Add the User control to the Layoutgridview
        private void AddToTimeTable(string slotNo, WorkerUserControlCN uc, bool isDelivery)
        {
            if (slotNo == "1" || slotNo == "6" || slotNo == "11")
            {
                if (isDelivery)
                    pnlDelivery1.Controls.Add(uc);
                else
                    pnlInstall1.Controls.Add(uc);
            }
            else if (slotNo == "2" || slotNo == "7" || slotNo == "12")
            {
                if (isDelivery)
                    pnlDelivery2.Controls.Add(uc);
                else
                    pnlInstall2.Controls.Add(uc);
            }
            else if (slotNo == "3" || slotNo == "8" || slotNo == "13")
            {
                if (isDelivery)
                    pnlDelivery3.Controls.Add(uc);
                else
                    pnlInstall3.Controls.Add(uc);
            }
            else if (slotNo == "4" || slotNo == "9" || slotNo == "14")
            {
                if (isDelivery)
                    pnlDelivery4.Controls.Add(uc);
                else
                    pnlInstall4.Controls.Add(uc);
            }
            else
            {
                if (isDelivery)
                    pnlDelivery5.Controls.Add(uc);
                else
                    pnlInstall5.Controls.Add(uc);
            }
        }

        //Clear all Delivery and installation UserControl 
        private void ClearPanel()
        {
            pnlDelivery1.Controls.Clear();
            pnlDelivery2.Controls.Clear();
            pnlDelivery3.Controls.Clear();
            pnlDelivery4.Controls.Clear();
            pnlDelivery5.Controls.Clear();
            pnlInstall1.Controls.Clear();
            pnlInstall2.Controls.Clear();
            pnlInstall3.Controls.Clear();
            pnlInstall4.Controls.Clear();
            pnlInstall5.Controls.Clear();
        }

        //Display Time duration for each session
        private void ShowSessionDuration()
        {
            lblTime1.Hide();
            lblTime2.Hide();
            lblTime3.Hide();

            if (sessionCount == 1)
            {
                lblTime1.Show();

                lblTime1.Visible = true;
                lblRow1.Text = Convert.ToString(1);
                lblRow2.Text = Convert.ToString(2);
                lblRow3.Text = Convert.ToString(3);
                lblRow4.Text = Convert.ToString(4);
                lblRow5.Text = Convert.ToString(5);
            }
            else if (sessionCount == 2)
            {
                lblTime2.Show();

                lblRow1.Text = Convert.ToString(6);
                lblRow2.Text = Convert.ToString(7);
                lblRow3.Text = Convert.ToString(8);
                lblRow4.Text = Convert.ToString(9);
                lblRow5.Text = Convert.ToString(10);
            }
            else
            {
                lblTime3.Show();
                lblRow1.Text = Convert.ToString(11);
                lblRow2.Text = Convert.ToString(12);
                lblRow3.Text = Convert.ToString(13);
                lblRow4.Text = Convert.ToString(14);
                lblRow5.Text = Convert.ToString(15);
            }
        }

        //Display Time duration for each session
        private void ShowSessionDuration(int setCount)
        {
            this.sessionCount = setCount;
            lblTime1.Hide();
            lblTime2.Hide();
            lblTime3.Hide();
            if (sessionCount == 1)
            {
                lblTime1.Show();

                lblTime1.Visible = true;
                lblRow1.Text = Convert.ToString(1);
                lblRow2.Text = Convert.ToString(2);
                lblRow3.Text = Convert.ToString(3);
                lblRow4.Text = Convert.ToString(4);
                lblRow5.Text = Convert.ToString(5);
            }
            else if (sessionCount == 2)
            {
                lblTime2.Show();

                lblRow1.Text = Convert.ToString(6);
                lblRow2.Text = Convert.ToString(7);
                lblRow3.Text = Convert.ToString(8);
                lblRow4.Text = Convert.ToString(9);
                lblRow5.Text = Convert.ToString(10);
            }
            else
            {
                lblTime3.Show();
                lblRow1.Text = Convert.ToString(11);
                lblRow2.Text = Convert.ToString(12);
                lblRow3.Text = Convert.ToString(13);
                lblRow4.Text = Convert.ToString(14);
                lblRow5.Text = Convert.ToString(15);
            }
        }

        //Restrict users to select Sundays and +1day when user select it
        private void dtpTimePick_ValueChanged(object sender, EventArgs e)
        {
            if (!(dtpTimePick.Value.DayOfWeek.ToString() == "Sunday"))
            {
                DisplaySelectedSession();
            }
            else
            {
                dtpTimePick.Value = dtpTimePick.Value.AddDays(1);
            }
        }

        private void btnNextSession_Click(object sender, EventArgs e)
        {
            if (sessionCount == 3)
                MessageBox.Show("Max");
            else
                sessionCount++;

            ShowSessionDuration();
            DisplaySelectedSession();
        }

        private void btnPrevSession_Click(object sender, EventArgs e)
        {
            if (sessionCount == 1)
                MessageBox.Show("Min");
            else
                sessionCount--;

            ShowSessionDuration();
            DisplaySelectedSession();
        }

        private void btnTrack_Click(object sender, EventArgs e)
        {
            MydisplaySelectedSession(txtSearch.Text);
        }

        private void btnAllList_Click(object sender, EventArgs e)
        {

        }

        //RefreshSession Overload Method
        public void RefreshSession(string ordId)
        {
            /*
            if (this.sessionCount == 1)
            {
                sessionCount++;
                sessionCount--;   
            }
            else if(this.sessionCount == 2)
            {
                sessionCount++;
                sessionCount--;    
            }
            else if (this.sessionCount == 3)
            {
                sessionCount--;
                sessionCount++;         
            }
            */
            ShowSessionDuration();
            MydisplaySelectedSession(ordId);
        }

        private void btnAutoAssign_Click(object sender, EventArgs e)
        {
            if (CURRENT_USER.Role != "Manager" && CURRENT_USER.Role != "Clerk" && CURRENT_USER.Role != "Technical Manager")
            {
                MessageBox.Show("您没有分配工人的权限！", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int j = AutoWorkerAssignment();
                for (int k = 0; k < j - 1; k++)
                {
                    AutoWorkerAssignment();
                }
                DisplaySelectedSession();
            }
        }

        public void RefreshSession()
        {
            ShowSessionDuration();
            DisplaySelectedSession();
        }

        private int AutoWorkerAssignment()
        {

            if (CURRENT_USER.Role != "Technical Manager")
            {
                mySQLStatement = "Select * from empolyee where Empdepartment='Delivery Worker'";

                //Worker list
                dt = con.MySQLStatementToDatatable(mySQLStatement);

                if (sessionCount == 1)
                {
                    mySQLStatement =
                        "Select * from deliveryorder where expectdeliverydate = " +
                        "'" + dtpTimePick.Value.ToString("yyyy-MM-dd") + "' and timeslot BETWEEN 1 and 5;";
                }
                else if (sessionCount == 2)
                {
                    mySQLStatement =
                        "Select * from deliveryorder where expectdeliverydate = " +
                        "'" + dtpTimePick.Value.ToString("yyyy-MM-dd") + "' and timeslot BETWEEN 6 and 10;";
                }
                else
                {
                    mySQLStatement =
                        "Select * from deliveryorder where expectdeliverydate = " +
                        "'" + dtpTimePick.Value.ToString("yyyy-MM-dd") + "' and timeslot BETWEEN 11 and 15;";
                }
                //Order list
                dt2 = con.MySQLStatementToDatatable(mySQLStatement);
                if (dt2.Rows.Count != 0)
                {
                    //Emp no 
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        bool assigned = false;

                        for (int j = 0; j < dt2.Rows.Count; j++)
                        {
                            if (dt.Rows[i]["EmpID"].ToString() == dt2.Rows[j]["EmpID"].ToString())
                            {
                                assigned = true;
                            }
                        }
                        if (assigned == false)
                        {
                            for (int k = 0; k < dt2.Rows.Count; k++)
                            {
                                if (string.IsNullOrEmpty(dt2.Rows[k]["EmpID"].ToString()) && dt2.Rows[k]["deliverystatus"].ToString() == "Processing")
                                {
                                    mySQLStatement = "Update deliveryorder set EmpID = '" + dt.Rows[i]["EmpID"].ToString() + "' where deliveryid = '" + dt2.Rows[k]["deliveryid"].ToString() + "'";
                                    con.InsertToMySQL(mySQLStatement);
                                    return dt2.Rows.Count;// Orders existing in target Slot
                                }
                            }
                        }
                    }
                }
                return 0; // No Order require worker arrange
            }
            else
            {
                mySQLStatement = "Select * from empolyee where Empdepartment='Technical Support'";
                //Emplist 
                dt = con.MySQLStatementToDatatable(mySQLStatement);

                if (sessionCount == 1)
                {
                    mySQLStatement =
                        "Select * from installationrequest where installDate = " +
                        "'" + dtpTimePick.Value.ToString("yyyy-MM-dd") + "' and installTimeslot BETWEEN 1 and 5;";
                }
                else if (sessionCount == 2)
                {
                    mySQLStatement =
                        "Select * from installationrequest where installDate = " +
                        "'" + dtpTimePick.Value.ToString("yyyy-MM-dd") + "' and installTimeslot BETWEEN 6 and 10;";
                }
                else
                {
                    mySQLStatement =
                        "Select * from installationrequest where installDate = " +
                        "'" + dtpTimePick.Value.ToString("yyyy-MM-dd") + "' and installTimeslot BETWEEN 11 and 15;";
                }

                // Installation request list
                dt2 = con.MySQLStatementToDatatable(mySQLStatement);

                if (dt2.Rows.Count != 0)
                {
                    //Emp no 
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        bool assigned = false;

                        for (int j = 0; j < dt2.Rows.Count; j++)
                        {
                            if (dt.Rows[i]["EmpID"].ToString() == dt2.Rows[j]["installEmpID"].ToString())
                            {
                                assigned = true;
                            }
                        }
                        if (assigned == false)
                        {
                            for (int k = 0; k < dt2.Rows.Count; k++)
                            {
                                if (string.IsNullOrEmpty(dt2.Rows[k]["installEmpID"].ToString()) && dt2.Rows[k]["installStatus"].ToString() == "Processing")
                                {
                                    mySQLStatement = "Update installationrequest set installEmpID = '" + dt.Rows[i]["EmpID"].ToString() + "' where installRequestid = '" + dt2.Rows[k]["installRequestid"].ToString() + "'";
                                    con.InsertToMySQL(mySQLStatement);
                                    return dt2.Rows.Count;// Orders existing in target Slot
                                }
                            }
                        }
                    }
                }
                return 0; // No Order require worker arrange
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            this.Hide();
            DialogResult dr = new frmHistoryCN(CURRENT_USER).ShowDialog();
            if (dr == DialogResult.Cancel)
            {
                this.Show();
            }
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            this.Hide();
            DialogResult dr = new frmMyTaskCN(CURRENT_USER).ShowDialog();
            if (dr == DialogResult.Cancel)
            {
                this.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


