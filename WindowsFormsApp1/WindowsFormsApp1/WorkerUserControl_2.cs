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
    public partial class WorkerUserControl : UserControl
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
        private FrmScheduler parentFrm;

        public WorkerUserControl()
        {
            InitializeComponent();
            con = new MyDB();
        }


        //GET SET METHOD FOR CUSTOMER INFO 
        public string DeliveryId
        {
            get { return deliveryId; }
            set { deliveryId = value; lbld.Text = "Delivery ID: " + value; }
        }

        public string InstallId
        {
            get { return installId; ; }
            set { installId = value; lbld.Text = "Installation ID: " + value; }
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
        //--


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

            /*
            // !! Disable completed order option when Worker field is empty
            if (cboWorker.SelectedIndex == -1 && (cboStatus.SelectedItem.ToString() == "Delivered" 
                || cboStatus.SelectedItem.ToString() == "Completed"))
            {               
                cboStatus.SelectedIndex +=-1;
            }
            */
        }
        public void SetOrderDetail(string dOrderId, string expectDdate, string timeslot, string createDate, string cusId, FrmScheduler returnFrm, USER user)
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
                    frmOrderDetail frm
                    = new frmOrderDetail(deliveryId, parentFrm, CURRENT_USER, controlType);

                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.Cancel)
                    {
                        RefreshSession();
                    }
                }
                else
                {
                    frmOrderDetail frm
                    = new frmOrderDetail(deliveryId, parentFrm, CURRENT_USER, controlType);
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.Cancel)
                    {
                        RefreshSession();
                    }
                }
            }
            else
            {
                frmOrderDetail frm
                    = new frmOrderDetail(deliveryId, parentFrm, CURRENT_USER, controlType);
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
                    MessageBox.Show("You cannot modify completed orders");
                    RefreshSession();
                }
                else if (cboStatus.SelectedItem.ToString() != currentStatus) // check status has change
                {
                    if (string.IsNullOrEmpty(currentWorkerSelect) && cboStatus.SelectedItem.ToString() == "Delivered") // Check complete order but worker is empty
                    {
                        MessageBox.Show("Order status cannot be complete without worker assignment");
                        RefreshSession();
                    }
                    else if (cboStatus.SelectedItem.ToString() != "Delivered" && cboStatus.SelectedText != currentStatus) // Check not completed order but status has change
                    {
                        //MessageBox.Show("Check not completed order but status has change");
                        if (cboStatus.SelectedText != "Processing" && cboStatus.SelectedText != "Delivered")
                        {
                            if (CURRENT_USER.Role != "Manager" && (dStatus == "Processing" || dStatus == "Delivered") && dStatus != cboStatus.SelectedItem.ToString())
                            {
                                MessageBox.Show("Requires manager privileges");
                            }
                            else
                            {
                                mySQLStatement =
                                   "Update deliveryorder Set deliverystatus='" + cboStatus.SelectedItem.ToString()
                                  + "', EmpID = NULL where deliveryid = '" + deliveryId + "' ";
                                con.InsertToMySQL(mySQLStatement);
                                MessageBox.Show("You've successfully updated your order information");
                            }
                        }
                        else
                        {
                            mySQLStatement =
                                  "Update deliveryorder Set  deliverystatus='" + cboStatus.SelectedItem.ToString()
                                  + "' where deliveryid = '" + deliveryId + "' ";
                            con.InsertToMySQL(mySQLStatement);
                            MessageBox.Show("You've successfully updated your order information");
                        }

                        RefreshSession();
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("Do you want to update the status?", "Update",
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
                            MessageBox.Show("Cancel Success");
                            RefreshSession();
                        }
                    }
                }
                else
                {
                    if (Dstatus != "Processing")
                    {
                        MessageBox.Show("Resume status to Processing inorder to continue your process");
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
                            MessageBox.Show("Worker has been assigned");
                            RefreshSession();
                        }
                        else
                        {
                            MessageBox.Show("Worker assign fail");
                            RefreshSession();
                        }
                    }
                }
            }
            else
            {

                if (iStatus == "Completed" && !string.IsNullOrEmpty(iWorkerid)) // Check Completed order and have workerid
                {
                    MessageBox.Show("Cannot modify completed orders");
                    RefreshSession();
                }
                else if (cboStatus.SelectedItem.ToString() != currentStatus) // check status has change
                {
                    if (string.IsNullOrEmpty(currentWorkerSelect) && cboStatus.SelectedItem.ToString() == "Completed") // Check complete order but worker is empty
                    {
                        MessageBox.Show("Order status cannot be complete without a worker assignment");
                        RefreshSession();
                    }
                    else if (cboStatus.SelectedItem.ToString() != "Completed" && cboStatus.SelectedText != currentStatus) // Check not completed order but status has change
                    {
                        //MessageBox.Show("Check not completed order but status has change");
                        if (cboStatus.SelectedText != "Processing" && cboStatus.SelectedText != "Completed")
                        {
                            if (CURRENT_USER.Role != "Technical Manager" && (dStatus == "Processing" || dStatus == "Completed") && dStatus != cboStatus.SelectedItem.ToString())
                            {
                                MessageBox.Show("Requires manager privileges");
                            }
                            else
                            {
                                mySQLStatement =
                               "Update installationrequest Set installStatus='" + cboStatus.SelectedItem.ToString()
                              + "', installEmpID = NULL where installRequestid = '" + installId + "' ";
                                con.InsertToMySQL(mySQLStatement);
                                MessageBox.Show("You've successfully updated your order information!");
                            }
                        }
                        else
                        {
                            mySQLStatement =
                              "Update installationrequest Set  installStatus='" + cboStatus.SelectedItem.ToString()
                              + "' where installRequestid = '" + installId + "' ";
                            con.InsertToMySQL(mySQLStatement);
                            MessageBox.Show("You've successfully updated your order information!");
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
                            MessageBox.Show("Select Cancel");
                            RefreshSession();
                        }
                    }
                }
                else
                {
                    if (iStatus != "Processing")
                    {
                        MessageBox.Show("Resume Installation order to Processing in order to continue your process");
                        RefreshSession();
                    }
                    else
                    {
                        mySQLStatement =
                                    "Update installationrequest Set installEmpID='" + cboWorker.SelectedItem.ToString()
                                    + "' where installRequestid = '" + installId + "'";
                        if (con.InsertToMySQL(mySQLStatement))
                        {
                            MessageBox.Show("Worker has been assigned");
                            RefreshSession();
                        }
                        else
                        {
                            MessageBox.Show("Worker assign fail.");
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
                        DialogResult dr = MessageBox.Show("Are you sure you want to delete the completed order?", "Delivery Order " + deliveryId, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                        if (dr == DialogResult.Yes)
                        {
                            DeleteDeliveryOrder();
                            RefreshSession();
                        }
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("Are you sure you want to delete the order ? ", "Delivery Order " +
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
                        MessageBox.Show("You do not have permission to modify this record", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("Are you sure?", "Delivery Order " + deliveryId, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
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
                    DialogResult dr = MessageBox.Show("Are you sure to delete the order?", "Installation Order " + installId, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
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
                        MessageBox.Show("You do not have permission to modify this record", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("Are you sure?", "Installation Order " + deliveryId, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
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

