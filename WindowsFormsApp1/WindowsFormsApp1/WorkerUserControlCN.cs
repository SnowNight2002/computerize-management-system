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
    public partial class WorkerUserControlCN : UserControl
    {
        //private string CURRENT_USER;
        private USER CURRENT_USER;

        private string controlType;
        private string currentStatus;
        private string cusId;

        //Delivery Order related variable 
        private string deliveryId;
        private string dStatus;
        private string dWorkerid;
        private string createDate;
        private string timeslot;
        private string expectDeliveryDate;

        //Installation Order related variable 
        private string installId;
        private string iStatus;
        private string iWorkerid;

        private MyDB con;
        private string mySQLStatement;
        private FrmSchedulerCN parentFrm;

        public WorkerUserControlCN()
        {
            InitializeComponent();
            con = new MyDB();
        }


        //GET SET METHOD FOR CUSTOMER INFO 
        public string DeliveryId
        {
            get { return deliveryId; }
            set { deliveryId = value; lbld.Text = "送货 ID: " + value; }
        }

        public string InstallId
        {
            get { return installId; ; }
            set { installId = value; lbld.Text = "安装 ID: " + value; }
        }

        public string DworkerId
        {
            get { return dWorkerid; }
            set { dWorkerid = value; cboWorker.SelectedItem = value; }
        }

        public string IworkerId
        {
            get { return iWorkerid; }
            set { iWorkerid = value; cboWorker.SelectedItem = value; }
        }

        public string Dstatus
        {
            get { return dStatus; }
            set { dStatus = value; cboStatus.SelectedItem = value; }
        }

        public string Istatus
        {
            get { return iStatus; }
            set { iStatus = value; cboStatus.SelectedItem = value; }
        }

        public string SetControlType
        {
            get { return controlType; }
            set { controlType = value; }
        }

        // !! Disable completed order option when Worker field is empty
        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (controlType == "Delivery Worker")
            {
                currentStatus = dStatus;
            }
            else
            {
                currentStatus = iStatus;
            }

            if (!String.IsNullOrEmpty(currentStatus))
            {
                if (currentStatus == "Delivered" || currentStatus == "Completed")
                {
                    this.pnlBackground.BackColor = Color.FromArgb(204, 204, 204);
                }
                else if (currentStatus == "Processing")
                {
                    this.pnlBackground.BackColor = Color.FromArgb(92, 184, 92);
                }
                else
                {
                    this.pnlBackground.BackColor = Color.FromArgb(217, 83, 79);
                }
            }
        }
        public void SetOrderDetail(string dOrderId, string expectDdate, string timeslot, string createDate, string cusId, FrmSchedulerCN returnFrm, USER user)
        {
            this.deliveryId = dOrderId;
            this.expectDeliveryDate = expectDdate;
            this.timeslot = timeslot;
            this.createDate = createDate;
            this.cusId = cusId;
            this.parentFrm = returnFrm;
            this.CURRENT_USER = user;


            if (controlType == "Delivery Worker")
            {
                if (CURRENT_USER.Role != "Manager" && CURRENT_USER.Role != "Clerk")
                {
                    cboWorker.Enabled = false;
                    cboStatus.Enabled = false;
                    btnCancelRecord.Enabled = false;
                    btnSave.Enabled = false;

                }
                else if (CURRENT_USER.Role != "Manager")
                {
                    btnCancelRecord.Enabled = false;
                }
            }
            else
            {
                if (CURRENT_USER.Role != "Manager" && CURRENT_USER.Role != "Technical Manager")
                {
                    cboWorker.Enabled = false;
                    cboStatus.Enabled = false;
                    btnCancelRecord.Enabled = false;
                    btnSave.Enabled = false;
                }
   
            }
        }

        public void SetStatus()
        {
            cboStatus.Items.Add("Processing");
            cboStatus.Items.Add("Expired");
            cboStatus.Items.Add("Holding");

            if (controlType == "Delivery Worker")
            {
                cboStatus.Items.Add("Delivered");
            }
            else if (controlType == "Technical Support")
            {
                cboStatus.Items.Add("Completed");
            }
        }

        public void FillWorkerItemList(DataTable workerList)
        {
            for (int i = 0; i < workerList.Rows.Count; i++)
            {
                if (workerList.Rows[i]["Empdepartment"].ToString() == controlType)
                {
                    this.cboWorker.Items.Add(workerList.Rows[i]["EmpID"].ToString());
                }
            }
        }

        private void pnlBackground_MouseClick(object sender, MouseEventArgs e)
        {
            if (controlType == "Delivery Worker")
            {
                if (string.IsNullOrEmpty(dWorkerid))
                {
                    frmOrderDetailCN frm
                    = new frmOrderDetailCN(deliveryId, parentFrm, CURRENT_USER, controlType);

                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.Cancel)
                    {
                        RefreshSession();
                    }
                }
                else
                {
                    frmOrderDetailCN frm
                    = new frmOrderDetailCN(deliveryId, parentFrm, CURRENT_USER, controlType);
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.Cancel)
                    {
                        RefreshSession();
                    }
                }
            }
            else
            {
                frmOrderDetailCN frm
                    = new frmOrderDetailCN(deliveryId, parentFrm, CURRENT_USER, controlType);
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.Cancel)
                {
                    RefreshSession();
                }
            }
        }
        private void cboWorker_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void RefreshSession()
        {
            //parentFrm.RefreshSession(deliveryId);
            parentFrm.RefreshSession();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (controlType == "Delivery Worker")
            {
                currentStatus = dStatus;
            }
            else
            {
                currentStatus = iStatus;
            }

            string currentWorkerSelect;

            if (cboWorker.SelectedItem == null)
            {
                currentWorkerSelect = null;
            }
            else
            {
                currentWorkerSelect = cboWorker.SelectedItem.ToString();
            }

            if (controlType == "Delivery Worker")
            {

                if (dStatus == "Delivered" && !string.IsNullOrEmpty(dWorkerid)) // Check Completed order and have workerid
                {
                    MessageBox.Show("您不能修改已完成的订单");
                    RefreshSession();
                }
                else if (cboStatus.SelectedItem.ToString() != currentStatus) // check status has change
                {
                    if (string.IsNullOrEmpty(currentWorkerSelect) && cboStatus.SelectedItem.ToString() == "Delivered") // Check complete order but worker is empty
                    {
                        MessageBox.Show("没有工人分配，订单状态无法完成");
                        RefreshSession();
                    }
                    else if (cboStatus.SelectedItem.ToString() != "Delivered" && cboStatus.SelectedText != currentStatus) // Check not completed order but status has change
                    {
                        //MessageBox.Show("Check not completed order but status has change");
                        if (cboStatus.SelectedText != "Processing" && cboStatus.SelectedText != "Delivered")
                        {
                            if (CURRENT_USER.Role != "Manager" && (dStatus == "Processing" || dStatus == "Delivered") && dStatus != cboStatus.SelectedItem.ToString())
                            {
                                MessageBox.Show("需要管理员权限");
                            }
                            else
                            {
                                mySQLStatement =
                                   "Update deliveryorder Set deliverystatus='" + cboStatus.SelectedItem.ToString()
                                  + "', EmpID = NULL where deliveryid = '" + deliveryId + "' ";
                                con.InsertToMySQL(mySQLStatement);
                                MessageBox.Show("状态更新成功");
                            }
                        }
                        else
                        {
                            mySQLStatement =
                                  "Update deliveryorder Set  deliverystatus='" + cboStatus.SelectedItem.ToString()
                                  + "' where deliveryid = '" + deliveryId + "' ";
                            con.InsertToMySQL(mySQLStatement);
                            MessageBox.Show("状态更新成功");
                        }

                        RefreshSession();
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("您要更新状态吗？", "Update",
                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                        if (dr == DialogResult.Yes)
                        {
                            // Do something
                            string oldStatus = currentStatus;
                            if (cboStatus.SelectedItem.ToString() == "Delivered" && cboStatus.SelectedItem.ToString() != oldStatus)
                            {
                                if (currentWorkerSelect == dWorkerid)
                                {
                                    mySQLStatement =
                                    "Update deliveryorder Set deliverycompleteDate='" + DateTime.Today.ToString("yyyy-MM-dd")
                                    + "' , deliverystatus='" + cboStatus.SelectedItem.ToString() + "' where deliveryid = '" +
                                    deliveryId + "'";
                                }
                                else
                                {
                                    mySQLStatement =
                                    "Update deliveryorder Set deliverycompleteDate='" + DateTime.Today.ToString("yyyy-MM-dd")
                                    + "' , deliverystatus='" + cboStatus.SelectedItem.ToString() + "', EmpID='" + currentWorkerSelect + "' where deliveryid = '" +
                                    deliveryId + "'";
                                }
                                con.InsertToMySQL(mySQLStatement);
                                mySQLStatement =
                                    "INSERT INTO deliverynote (deliverynoteid, deliveryid) VALUES " +
                                    "(null," + deliveryId + ")";
                                con.InsertToMySQL(mySQLStatement);
                                RefreshSession();
                            }
                            else
                            {
                                mySQLStatement =
                                    "Update deliveryorder Set  deliverystatus='" + cboStatus.SelectedItem.ToString()
                                    + "' where deliveryid = '" + deliveryId + "'";
                                con.InsertToMySQL(mySQLStatement);
                                RefreshSession();
                                /*
                                DworkerId = cboWorker.SelectedItem.ToString();
                                Dstatus = cboStatus.SelectedItem.ToString();
                                */
                            }
                        }
                        else
                        {
                            MessageBox.Show("选择取消");
                            RefreshSession();
                        }
                    }
                }
                else
                {
                    if (Dstatus != "Processing")
                    {
                        MessageBox.Show("您需要恢复交货订单才能继续您的流程");
                        /*
                        if (!string.IsNullOrEmpty(dWorkerid))
                        {
                            cboWorker.SelectedItem = dWorkerid;
                        }
                        else
                        {
                            cboWorker.SelectedItem = null;
                        }

                        cboStatus.SelectedItem = dStatus;
                        */
                        RefreshSession();
                    }
                    else
                    {
                        mySQLStatement =
                                    "Update deliveryorder Set EmpID='" + cboWorker.SelectedItem.ToString()
                                    + "' where deliveryid = '" + deliveryId + "'";
                        if (con.InsertToMySQL(mySQLStatement))
                        {
                            MessageBox.Show("工人已被分配");
                            RefreshSession();
                        }
                        else
                        {
                            MessageBox.Show("分配失败");
                            RefreshSession();
                        }
                    }
                }
            }
            else
            {

                if (iStatus == "Completed" && !string.IsNullOrEmpty(iWorkerid)) // Check Completed order and have workerid
                {
                    MessageBox.Show("您不能修改已完成的订单");
                    RefreshSession();
                }
                else if (cboStatus.SelectedItem.ToString() != currentStatus) // check status has change
                {
                    if (string.IsNullOrEmpty(currentWorkerSelect) && cboStatus.SelectedItem.ToString() == "Completed") // Check complete order but worker is empty
                    {
                        MessageBox.Show("没有工人分配，订单状态无法完成");
                        RefreshSession();
                    }
                    else if (cboStatus.SelectedItem.ToString() != "Completed" && cboStatus.SelectedText != currentStatus) // Check not completed order but status has change
                    {
                        //MessageBox.Show("Check not completed order but status has change");
                        if (cboStatus.SelectedText != "Processing" && cboStatus.SelectedText != "Completed")
                        {
                            if (CURRENT_USER.Role != "Technical Manager" && (dStatus == "Processing" || dStatus == "Completed") && dStatus != cboStatus.SelectedItem.ToString())
                            {
                                MessageBox.Show("需要管理员权限");
                            }
                            else
                            {
                                mySQLStatement =
                               "Update installationrequest Set installStatus='" + cboStatus.SelectedItem.ToString()
                              + "', installEmpID = NULL where installRequestid = '" + installId + "' ";
                                con.InsertToMySQL(mySQLStatement);
                                MessageBox.Show("状态更新成功");
                            }
                        }
                        else
                        {
                            mySQLStatement =
                              "Update installationrequest Set  installStatus='" + cboStatus.SelectedItem.ToString()
                              + "' where installRequestid = '" + installId + "' ";
                            con.InsertToMySQL(mySQLStatement);
                            MessageBox.Show("状态更新成功");
                        }

                        RefreshSession();//--------->correct
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("Do you want to update the status?", "Update",
                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                        if (dr == DialogResult.Yes)
                        {
                            // Do something
                            string oldStatus = currentStatus;
                            if (cboStatus.SelectedItem.ToString() == "Completed" && cboStatus.SelectedItem.ToString() != oldStatus)
                            {
                                if (currentWorkerSelect == iWorkerid)
                                {
                                    mySQLStatement =
                                    "Update installationrequest Set installComDate='" + DateTime.Today.ToString("yyyy-MM-dd")
                                    + "' , installStatus='" + cboStatus.SelectedItem.ToString() + "' where installRequestid = '" +
                                    installId + "'";
                                }
                                else
                                {
                                    mySQLStatement =
                                    "Update installationrequest Set installComDate='" + DateTime.Today.ToString("yyyy-MM-dd")
                                    + "' , installStatus='" + cboStatus.SelectedItem.ToString() + "', installEmpID='" + currentWorkerSelect + "' where installRequestid = '" +
                                    installId + "'";
                                }
                                con.InsertToMySQL(mySQLStatement);
                                RefreshSession();
                            }
                            else
                            {
                                mySQLStatement =
                                    "Update installationrequest Set  installStatus='" + cboStatus.SelectedItem.ToString()
                                    + "' where installRequestid = '" + installId + "'";
                                con.InsertToMySQL(mySQLStatement);
                                RefreshSession();
                            }
                        }
                        else
                        {
                            MessageBox.Show("选择取消");
                            RefreshSession();
                        }
                    }
                }
                else
                {
                    if (iStatus != "Processing")
                    {
                        MessageBox.Show("您需要恢复安装顺序才能继续您的过程");
                        RefreshSession();
                    }
                    else
                    {
                        mySQLStatement =
                                    "Update installationrequest Set installEmpID='" + cboWorker.SelectedItem.ToString()
                                    + "' where installRequestid = '" + installId + "'";
                        if (con.InsertToMySQL(mySQLStatement))
                        {
                            MessageBox.Show("工人已被分配");
                            RefreshSession();
                        }
                        else
                        {
                            MessageBox.Show("工人分配失败");
                            RefreshSession();
                        }
                    }
                }

            }
        }

        private void btnCancelRecord_Click(object sender, EventArgs e)
        {

            if (controlType == "Delivery Worker")
            {
                if (CURRENT_USER.Role == "Manager")
                {
                    if (dStatus == "Delivered")
                    {
                        DialogResult dr = MessageBox.Show("您确定要删除已完成的订单吗？", "Delivery Order " + deliveryId, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                        if (dr == DialogResult.Yes)
                        {
                            DeleteDeliveryOrder();
                            RefreshSession();
                        }
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("您确定要删除订单吗？ ", "Delivery Order " +
                            deliveryId, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                        if (dr == DialogResult.Yes)
                        {
                            mySQLStatement = "Select * from installationrequest where deliveryid ='" + deliveryId + "'";
                            DataTable dt = con.MySQLStatementToDatatable(mySQLStatement);
                            if (dt.Rows.Count > 0)
                            {
                                DeleteDeliveryOrder();
                            }
                            else
                            {
                                DeleteDeliveryOrder();
                            }
                        }
                        RefreshSession();
                    }
                }
                else
                {
                    if (dStatus != "Processing")
                    {
                        MessageBox.Show("您无权修改此记录", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("你确定吗？", "Delivery Order " + deliveryId, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dr == DialogResult.Yes)
                        {
                            DeleteDeliveryOrder();
                            RefreshSession();
                        }
                    }
                }
            }
            else
            {
                if (CURRENT_USER.Role == "Manager" || CURRENT_USER.Role == "Technical Manager")
                {
                    DialogResult dr = MessageBox.Show("您确定要删除订单吗？", "Installation Order " + installId, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                    {
                        DeleteInstallOrder();
                        RefreshSession();
                    }
                }
                else
                {
                    if (iStatus != "Processing")
                    {
                        MessageBox.Show("您无权修改此记录", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("你确定吗？", "Installation Order " + deliveryId, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dr == DialogResult.Yes)
                        {
                            DeleteInstallOrder();
                            RefreshSession();
                        }
                    }
                }

            }
        }

        private void DeleteDeliveryOrder()
        {
            // Installation require is N
            mySQLStatement =
           "DELETE FROM deliverynote where deliveryid = '" + deliveryId + "'";
            con.InsertToMySQL(mySQLStatement);
            mySQLStatement =
                "DELETE FROM deliveryorderproduct where deliveryid = '" + deliveryId + "'";
            con.InsertToMySQL(mySQLStatement);
            mySQLStatement =
                "DELETE FROM installationrequest where deliveryid = '" + deliveryId + "'";
            con.InsertToMySQL(mySQLStatement);
            mySQLStatement =
                "DELETE FROM deliveryorder where deliveryid = '" + deliveryId + "'";
            con.InsertToMySQL(mySQLStatement);
        }

        private void DeleteInstallOrder()
        {
            mySQLStatement =
            "Update deliveryorder set installationNeed = 'N' where deliveryid = '" + deliveryId + "'";
            con.InsertToMySQL(mySQLStatement);

            mySQLStatement =
                "DELETE FROM installationrequest where installRequestid = '" + installId + "'";
            con.InsertToMySQL(mySQLStatement);
        }


    }
}

