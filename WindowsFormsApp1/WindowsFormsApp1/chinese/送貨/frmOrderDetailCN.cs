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
    public partial class frmOrderDetailCN : Form
    {
        private MyDB con;
        private string mySQLStatement;
        private DataTable dt;
        private string orderType;
        private USER CURRENT_USER;
        private bool openFromOrderDetail = false;
        private string deliveryId;
        private string customerId;
        private FrmSchedulerCN frmS;

        private string cusAddressOrignal;
        private string cusPhoneOrignal;

        //variable for 
        public frmOrderDetailCN(string dOrderId, FrmSchedulerCN frm, USER user, string oType)
        {
            InitializeComponent();
            // USER   Worker / Manager / Clerk
            this.CURRENT_USER = user;
            con = new MyDB();
            this.frmS = frm;
            this.deliveryId = dOrderId;
            this.orderType = oType;

            //txtOrdId.Text = deliveryId;
            dgvItemList.Font = new Font("sans serif", 13F, GraphicsUnit.Pixel);
            DisableField();
            SetComboBoxStatus();
            //Retrieve Order detail from MySQL
            RetrieveOrderDetail();
        }

        private void SetOpenFromOrderDetail()
        {
            openFromOrderDetail = true;
        }

        private void DisableField()
        {
            lblInstallID.Hide();
            lblDeliveryId.Hide();
            lblInstallDate.Hide();
            lblDeliveryDate.Hide();

            btnInstall.Hide();
            btnDelivery.Hide();
            btnDelete.Enabled = false;

            //Order 
            cboSlot.Enabled = false;
            dtpDeliveryDate.Enabled = false;
            cboStatus.Enabled = false;
            dtpComplete.Enabled = false;

            //Customer info
            txtCusId.ReadOnly = true;
            txtPhone.ReadOnly = true;
            txtAddress.ReadOnly = true;
            btnSave.Enabled = false;


            if (orderType == "Delivery Worker")
            {
                lblDeliveryId.Show();
                lblDeliveryDate.Show();

                if (CURRENT_USER.Role == "Manager")
                {
                    btnDelete.Enabled = true;
                }

                if (CURRENT_USER.Role == "Manager" || CURRENT_USER.Role == "Clerk")
                {
                    cboSlot.Enabled = true;
                    dtpDeliveryDate.Enabled = true;
                    cboStatus.Enabled = true;
                    btnSave.Enabled = true;
                    txtCusId.ReadOnly = false;
                    txtPhone.ReadOnly = false;
                    txtAddress.ReadOnly = false;
                }
            }
            else
            {
                lblInstallDate.Show();
                lblInstallID.Show();

                if (CURRENT_USER.Role == "Technical Manager" || CURRENT_USER.Role == "Manager")
                {
                    cboSlot.Enabled = true;
                    dtpDeliveryDate.Enabled = true;
                    cboStatus.Enabled = true;
                    btnSave.Enabled = true;
                    btnDelete.Enabled = true;

                    txtCusId.ReadOnly = false;
                    txtPhone.ReadOnly = false;
                    txtAddress.ReadOnly = false;
                }
            }
        }

        private void DisableCrossButton()
        {
            if (openFromOrderDetail)
            {
                btnInstall.Hide();
                btnDelivery.Hide();
            }
        }

        private void SetComboBoxStatus()
        {
            cboStatus.Items.Add("Processing");
            cboStatus.Items.Add("Expired");
            cboStatus.Items.Add("Holding");

            if (orderType == "Delivery Worker")
            {
                cboStatus.Items.Add("Delivered");
            }
            else
            {
                cboStatus.Items.Add("Completed");
            }
        }

        //Retrieve customer / delivery data from MySQL and display on the form
        private void RetrieveOrderDetail()
        {
            //Get Target Delivery/ Installation Order detail
            if (orderType == "Delivery Worker")
            {
                GetOrderDetail();
            }
            else
            {
                GetInstallOrderDetail();
                btnDelivery.Show();
            }
            //Get Customer item list 
            GetCustomerBuyList();
            //Calculator the total weight of the item
            GetTotalItemWeight();
            //Get target customer information 
            GetCustomerInfo();

            DisableCrossButton();
        }

        //Retrieve Order detail from MySQL
        public void GetOrderDetail()
        {
            mySQLStatement =
                "Select * from deliveryorder where deliveryid= '" + deliveryId + "'";
            dt = con.MySQLStatementToDatatable(mySQLStatement);
            txtOrdId.Text = deliveryId;

            if (dt.Rows.Count == 1)
            {
                cboStatus.SelectedItem = dt.Rows[0]["deliverystatus"].ToString();
                cboSlot.SelectedItem = dt.Rows[0]["timeslot"].ToString();
                dtpDeliveryDate.Value = Convert.ToDateTime(dt.Rows[0]["expectdeliverydate"].ToString());

                if (!string.IsNullOrEmpty(dt.Rows[0]["EmpID"].ToString()))
                {
                    txtWorkerId.Text = dt.Rows[0]["EmpID"].ToString();
                }

                if (dt.Rows[0]["deliverystatus"].ToString() != "Delivered")
                {
                    lblCompeteDate.Hide();
                    dtpComplete.Hide();
                }
                else
                {
                    lblCompeteDate.Show();
                    if (string.IsNullOrEmpty(dt.Rows[0]["deliverycompleteDate"].ToString()))
                    {
                        MessageBox.Show("未能获得完成日期");
                    }
                    else
                    {
                        dtpComplete.Value = Convert.ToDateTime(dt.Rows[0]["deliverycompleteDate"].ToString());
                        dtpComplete.Show();
                    }
                }
            }
            else
            {
                MessageBox.Show("Had " + dt.Rows.Count.ToString() + " record!");
            }
            customerId = dt.Rows[0]["Customerid"].ToString();

            //Display the Installation Service
            if ((orderType != "Delivery Worker" || dt.Rows[0]["InstallationNeed"].ToString() != "Y"))
            {
                btnInstall.Hide();
            }
            else
            {
                btnInstall.Show();
            }
        }

        public void GetInstallOrderDetail()
        {
            mySQLStatement =
                "select * from installationrequest NATURAL JOIN deliveryorder where deliveryid='" + deliveryId + "'";
            dt = con.MySQLStatementToDatatable(mySQLStatement);

            if (dt.Rows.Count == 1)
            {
                txtOrdId.Text = dt.Rows[0]["installRequestid"].ToString();
                cboStatus.SelectedItem = dt.Rows[0]["installStatus"].ToString();
                cboSlot.SelectedItem = dt.Rows[0]["installTimeslot"].ToString();
                dtpDeliveryDate.Value = Convert.ToDateTime(dt.Rows[0]["installDate"].ToString());

                if (!string.IsNullOrEmpty(dt.Rows[0]["installEmpID"].ToString()))
                {
                    txtWorkerId.Text = dt.Rows[0]["installEmpID"].ToString();
                }

                if (dt.Rows[0]["installStatus"].ToString() != "Completed")
                {
                    lblCompeteDate.Hide();
                    dtpComplete.Hide();
                }
                else
                {
                    lblCompeteDate.Show();
                    if (string.IsNullOrEmpty(dt.Rows[0]["installComDate"].ToString()))
                    {
                        MessageBox.Show("未能获得完成日期");
                    }
                    else
                    {
                        dtpComplete.Value = Convert.ToDateTime(dt.Rows[0]["installComDate"].ToString());
                        dtpComplete.Show();
                    }
                }
            }
            else
            {
                MessageBox.Show("Had " + dt.Rows.Count.ToString() + " record!");
            }

            customerId = dt.Rows[0]["Customerid"].ToString();
        }

        // Get all target customer information from MySQL
        private void GetCustomerInfo()
        {
            mySQLStatement = "Select * from customer where customerid = '" + customerId + "' ";
            dt = con.MySQLStatementToDatatable(mySQLStatement);

            if (dt.Rows.Count == 1)
            {
                txtCusId.Text = dt.Rows[0]["Customerid"].ToString();
                txtPhone.Text = dt.Rows[0]["PhoneNumber"].ToString();
                txtAddress.Text = dt.Rows[0]["customeraddress"].ToString();
                txtName.Text = dt.Rows[0]["customername"].ToString();

                //Initialize customerinfo for comparison
                cusAddressOrignal = dt.Rows[0]["customeraddress"].ToString();
                cusPhoneOrignal = dt.Rows[0]["PhoneNumber"].ToString();
            }
            else
            {
                MessageBox.Show("错误：客户 " + customerId + " 在数据库中找不到");
            }
        }

        //Get Customer item list 
        private void GetCustomerBuyList()
        {
            dgvItemList.Rows.Clear();

            mySQLStatement =
                "Select * from deliveryorderproduct dp, product p where dp.productid = p.productid and deliveryid ='" + deliveryId + "'";
            dt = con.MySQLStatementToDatatable(mySQLStatement);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgvItemList.Rows.Add(dt.Rows[i]["productname"].ToString(), dt.Rows[i]["buyqty"].ToString());
            }
        }

        //Calculator the total weight of the item
        private void GetTotalItemWeight()
        {
            double totalWeight = 0;

            mySQLStatement =
                    "select * from deliveryorderproduct dp, product p where " +
                    "dp.productid = p.productid and dp.deliveryid = '" + deliveryId + "'";

            dt = con.MySQLStatementToDatatable(mySQLStatement);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                totalWeight += Convert.ToDouble(dt.Rows[i]["productweight"]) * Convert.ToDouble(dt.Rows[i]["buyqty"]);
            }
            totalWeight = Math.Round(totalWeight, 2);
            txtWeight.Text = Convert.ToString(totalWeight);
        }

        //Validating user's change and return a messagebox when error occurs
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (orderType == "Delivery Worker")
            {
                mySQLStatement =
                "Select * from deliveryorder where deliveryid= '" + deliveryId + "'";
                dt = con.MySQLStatementToDatatable(mySQLStatement);
                int errorCode = CheckUpdateValid(dt);

                if (dtpDeliveryDate.Value.DayOfWeek.ToString() == "Sunday")
                {
                    MessageBox.Show("错误，非工作时间");
                }
                else if (errorCode == 0)
                {
                    MessageBox.Show("错误，需要经理帐号");
                }
                else if (errorCode == 1)
                {
                    MessageBox.Show("错误，需要分配工人");
                }
                else if (errorCode == 2)
                {
                    MessageBox.Show("你什么都没改变");
                }
                else if (errorCode == 3)
                {
                    MessageBox.Show("错误，新的安排应该在今天之后");
                }
                else if (errorCode == 4)
                {
                    MessageBox.Show("抱歉，新的预定日期或时间段不可用");
                }
                else if (errorCode == 5)
                {
                    MessageBox.Show("错误，新的交货日期必须早于安装要求");
                }
                else if (errorCode == 6) // Vaild update and require installation
                {
                    DialogResult dr = MessageBox.Show("系统检测到存在安装需求，同步修改？", "Import", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.OK)
                    {
                        //Update installation order 
                        mySQLStatement =
                            "Update installationrequest set installDate = '" + dtpDeliveryDate.Value.ToString("yyyy-MM-dd")
                            + "',  installTimeslot ='" + cboSlot.SelectedItem.ToString() + "' where deliveryid ='" + deliveryId + "'";
                        if (con.InsertToMySQL(mySQLStatement))
                        {
                            //Update delivery order
                            if (String.IsNullOrEmpty(txtWorkerId.Text))
                            {
                                mySQLStatement =
                                    "Update deliveryorder set deliverystatus = '" + cboStatus.SelectedItem.ToString() + "' ,expectdeliverydate " +
                                    "= '" + dtpDeliveryDate.Value.ToString("yyyy-MM-dd") + "' , timeslot = '" + cboSlot.SelectedItem.ToString() + " " +
                                    "',EmpID = NULL where deliveryid = '" + deliveryId + "'";
                            }
                            else
                            {
                                mySQLStatement =
                                    "Update deliveryorder set deliverystatus = '" + cboStatus.SelectedItem.ToString() + "' ,expectdeliverydate " +
                                    "= '" + dtpDeliveryDate.Value.ToString("yyyy-MM-dd") + "' , timeslot = '" + cboSlot.SelectedItem.ToString() + " " +
                                    "',EmpID = '" + txtWorkerId.Text + "' where deliveryid = '" + deliveryId + "'";
                            }


                            if (con.InsertToMySQL(mySQLStatement))
                            {
                                mySQLStatement =
                                    "Update customer set customerAddress = '" + txtAddress.Text + "', " +
                                    "PhoneNumber = '" + txtPhone.Text + "' where customerid = '" + txtCusId.Text + "'";
                                if (con.InsertToMySQL(mySQLStatement))
                                {
                                    MessageBox.Show("订单信息已更新");
                                }
                                else
                                {
                                    MessageBox.Show("客户信息更新失败");
                                }
                            }
                            else
                            {
                                MessageBox.Show("送货单更新失败");
                            }
                        }
                        else
                        {
                            MessageBox.Show("安装请求更新失败");
                        }

                        RetrieveOrderDetail();
                    }
                }
                else if (errorCode == 7)
                {
                    if (string.IsNullOrEmpty(txtWorkerId.Text))
                    {
                        mySQLStatement =
                            "Update deliveryorder set deliverystatus = '" + cboStatus.SelectedItem.ToString() + "' ,expectdeliverydate " +
                            "= '" + dtpDeliveryDate.Value.ToString("yyyy-MM-dd") + "' , timeslot = '" + cboSlot.SelectedItem.ToString() + " " +
                            "' where deliveryid = '" + deliveryId + "'";
                    }
                    else
                    {
                        if (cboStatus.SelectedItem.ToString() == "Delivered")
                        {
                            mySQLStatement =
                            "Update deliveryorder set deliverystatus = '" + cboStatus.SelectedItem.ToString() + "' ,expectdeliverydate " +
                            "= '" + dtpDeliveryDate.Value.ToString("yyyy-MM-dd") + "' , timeslot = '" + cboSlot.SelectedItem.ToString() + " " +
                            "',EmpID = '" + txtWorkerId.Text + "', deliverycompleteDate ='" + DateTime.Today.ToString("yyyy-MM-dd") + "'" +
                            " where deliveryid = '" + deliveryId + "'";
                        }
                        else
                        {
                            mySQLStatement =
                            "Update deliveryorder set deliverystatus = '" + cboStatus.SelectedItem.ToString() + "' ,expectdeliverydate " +
                            "= '" + dtpDeliveryDate.Value.ToString("yyyy-MM-dd") + "' , timeslot = '" + cboSlot.SelectedItem.ToString() + " " +
                            "',EmpID = '" + txtWorkerId.Text + "' where deliveryid = '" + deliveryId + "'";
                        }
                    }

                    if (con.InsertToMySQL(mySQLStatement))
                    {
                        mySQLStatement =
                            "Update customer set customerAddress = '" + txtAddress.Text + "', " +
                            "PhoneNumber = '" + txtPhone.Text + "' where customerid = '" + txtCusId.Text + "'";
                        if (con.InsertToMySQL(mySQLStatement))
                        {
                            mySQLStatement = "INSERT INTO deliverynote (deliverynoteid, deliveryid) VALUES(null,'" + deliveryId + "')";
                            if (con.InsertToMySQL(mySQLStatement))
                            {
                                MessageBox.Show("订单信息已更新#1");
                            }
                            else
                            {
                                MessageBox.Show("创建送货单失败");
                            }
                        }
                        else
                        {
                            MessageBox.Show("客户信息更新失败");
                        }
                    }
                }
                else if (errorCode == 8)
                {
                    if (cboStatus.SelectedItem.ToString() == "Delivered")
                    {
                        mySQLStatement =
                            "Update deliveryorder set deliverystatus = '" + cboStatus.SelectedItem.ToString() + "' ,expectdeliverydate " +
                            "= '" + dtpDeliveryDate.Value.ToString("yyyy-MM-dd") + "' , timeslot = '" + cboSlot.SelectedItem.ToString() + " " +
                            "',EmpID = '" + txtWorkerId.Text + "', deliverycompleteDate ='" + DateTime.Today.ToString("yyyy-MM-dd") + "'" +
                            " where deliveryid = '" + deliveryId + "'";
                        if (con.InsertToMySQL(mySQLStatement))
                        {
                            mySQLStatement = "INSERT INTO deliverynote (deliverynoteid, deliveryid) VALUES(null,'" + deliveryId + "')";
                            if (con.InsertToMySQL(mySQLStatement))
                            {
                                MessageBox.Show("订单状态已更新");
                            }
                            else
                            {
                                MessageBox.Show("创建送货单失败");
                            }
                        }
                        else
                        {
                            MessageBox.Show("无法更新订单状态");
                        }
                    }
                    else if ((cboStatus.SelectedItem.ToString() != "Delivered" && cboStatus.SelectedItem.ToString() != "Processing") && (dt.Rows[0]["deliverystatus"].ToString() == "Delivered" || dt.Rows[0]["deliverystatus"].ToString() == "Processing"))
                    {
                        mySQLStatement =
                                  "Update deliveryorder Set deliverystatus='" + cboStatus.SelectedItem.ToString()
                                 + "', EmpID = NULL where deliveryid = '" + deliveryId + "' ";
                        if (con.InsertToMySQL(mySQLStatement))
                        {
                            MessageBox.Show("订单状态已更新");
                            txtWorkerId.Text = null;
                            RetrieveOrderDetail();
                        }
                        else
                        {
                            MessageBox.Show("更新状态失败");
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(txtWorkerId.Text))
                        {
                            mySQLStatement =
                          "Update deliveryorder set deliverystatus = '" + cboStatus.SelectedItem.ToString() + "' ,expectdeliverydate " +
                          "= '" + dtpDeliveryDate.Value.ToString("yyyy-MM-dd") + "' , timeslot = '" + cboSlot.SelectedItem.ToString() + " " +
                          "' where deliveryid = '" + deliveryId + "'";
                        }
                        else
                        {
                            mySQLStatement =
                          "Update deliveryorder set deliverystatus = '" + cboStatus.SelectedItem.ToString() + "' ,expectdeliverydate " +
                          "= '" + dtpDeliveryDate.Value.ToString("yyyy-MM-dd") + "' , timeslot = ' " + cboSlot.SelectedItem.ToString() + " " +
                          "',EmpID = '" + txtWorkerId.Text + "' where deliveryid = '" + deliveryId + "'";
                        }

                        if (con.InsertToMySQL(mySQLStatement))
                        {
                            MessageBox.Show("订单状态已更新");
                        }
                        else
                        {
                            MessageBox.Show("更新状态失败");
                        }
                    }
                }
                else if (errorCode == 12)
                {
                    MessageBox.Show("无法将状态更新为已过期和扣留，需要经理帐户");

                }
                else if (errorCode == 9)
                {
                    MessageBox.Show("没有现有的交货单");
                }
                else if (errorCode == 10)
                {
                    MessageBox.Show(" 拒绝访问 ");

                }
                else if (errorCode == 13)
                {
                    MessageBox.Show("要求恢复");
                }
                else if (errorCode == 14)//Update Customerinfo success
                {
                    mySQLStatement =
                           "Update customer set customerAddress = '" + txtAddress.Text + "', " +
                           "PhoneNumber = '" + txtPhone.Text + "' where customerid = '" + txtCusId.Text + "'";
                    if (con.InsertToMySQL(mySQLStatement))
                    {
                        MessageBox.Show("客户信息已更新");
                    }
                    else
                    {
                        MessageBox.Show("客户信息更新失败");
                    }
                }
                else
                {
                    MessageBox.Show("遇到未知错误，更新失败");
                }
            }
            else
            {
                //Installation Order Event
                mySQLStatement =
               "SELECT * FROM installationrequest NATURAL JOIN deliveryorder " +
               "where installRequestid='" + txtOrdId.Text + "'";
                DataTable dt3 = con.MySQLStatementToDatatable(mySQLStatement);

                int errorCode = CheckInstallupdateValid(dt3);
                if (errorCode == 0)
                {
                    ////You are not allow to modify the completed order
                    MessageBox.Show("错误，无法修改已完成的订单");
                }
                else if (errorCode == 1)
                {
                    //Need to resume
                    MessageBox.Show("要求恢复");
                }
                else if (errorCode == 2)
                {
                    //You cant complete order without worker
                    MessageBox.Show("错误，需要分配工人");

                }
                else if (errorCode == 3)
                {
                    //Nothing Change
                    MessageBox.Show("你什么都没改变");
                }
                else if (errorCode == 4)
                {
                    //You should set the day after today
                    MessageBox.Show("错误，新的安排应该在今天之后");
                }
                else if (errorCode == 6)
                {
                    // slot is not available , chose other slot
                    MessageBox.Show("抱歉，新的预定日期或时间段不可用");
                }
                else if (errorCode == 7 || errorCode == 5)
                {
                    //Installation time is early than delivery 
                    MessageBox.Show("错误，新的安装日期必须晚于交货单");
                }
                else if (errorCode == 10)
                {
                    MessageBox.Show("错误，订单数据不一致");
                }
                else //8,9,11
                {
                    //Record is ready to inserted
                    UpdateInstallationOrder();
                }
            }

            RetrieveOrderDetail();
        }

        //Return a integer when user meet the constraint
        private int CheckUpdateValid(DataTable dt2)
        {
            bool expectDeliveryDateMatch = Convert.ToDateTime(dt2.Rows[0]["expectdeliverydate"].ToString()) == dtpDeliveryDate.Value;
            bool timeSlotMatch = dt2.Rows[0]["timeslot"].ToString() == cboSlot.SelectedItem.ToString();
            bool statusMatch = dt2.Rows[0]["deliverystatus"].ToString() == cboStatus.SelectedItem.ToString();
            //bool laterThanOldOrderDate = Convert.ToDateTime(dt2.Rows[0]["expectdeliverydate"].ToString()) < dtpDeliveryDate.Value;
            bool beforeToday = dtpDeliveryDate.Value < DateTime.Today;

            bool cusInfoChange = (txtAddress.Text != cusAddressOrignal || txtPhone.Text != cusPhoneOrignal);

            if (CURRENT_USER.Role != "Manager")
            {
                if (CURRENT_USER.Role == "Clerk")
                {
                    if (dt2.Rows[0]["deliverystatus"].ToString() == "Delivered")
                    {
                        return 0;  //You are not allow to modify the completed order
                    }
                    else if (dt2.Rows[0]["deliverystatus"].ToString() == "Expired" || dt2.Rows[0]["deliverystatus"].ToString() == "Holding")
                    {
                        return 13;
                    }
                    else if (cboStatus.SelectedItem.ToString() == "Delivered" && string.IsNullOrEmpty(txtWorkerId.Text))
                    {
                        return 1;  //You cant complete order without worker
                    }
                    else if ((expectDeliveryDateMatch && timeSlotMatch && statusMatch) && cusInfoChange)
                    {
                        return 14; //Order detail unchange but customer info change
                    }
                    else if (expectDeliveryDateMatch && timeSlotMatch && statusMatch)  // Nothing change when all match              
                    {
                        return 2; //Nothing Change
                    }
                    else if (!expectDeliveryDateMatch && beforeToday) // New day before today
                    {
                        return 3; //You should set the day after today
                    }
                    else if (dt2.Rows[0]["deliverystatus"].ToString() == "Processing" && (cboStatus.SelectedItem.ToString() == "Expired" || cboStatus.SelectedItem.ToString() == "Holding"))
                    {
                        return 12;
                    }
                    else if (!expectDeliveryDateMatch || !timeSlotMatch)
                    {
                        mySQLStatement =
                                "select * from deliveryorder d where expectdeliverydate= '" +
                                "" + dtpDeliveryDate.Value.ToString("yyyy-MM-dd") + "' and timeslot ='" +
                                "" + cboSlot.SelectedItem.ToString() + "'";
                        dt = con.MySQLStatementToDatatable(mySQLStatement);

                        if (dt.Rows.Count == 1) // return 1 meaning the slot of that date is not available
                        {
                            return 4; // he slot is not available , chose other slot
                        }
                        else if (dt.Rows.Count == 0)
                        {
                            mySQLStatement =
                                "select InstallationNeed FROM deliveryorder where " +
                                "deliveryid = '" + deliveryId + "'";
                            dt = con.MySQLStatementToDatatable(mySQLStatement);
                            if (dt.Rows[0]["InstallationNeed"].ToString() == "Y")
                            {
                                mySQLStatement =
                                    "select * from installationrequest where " +
                                    "deliveryid = '" + deliveryId + "'";
                                dt = con.MySQLStatementToDatatable(mySQLStatement);

                                try
                                {

                                    if (dtpDeliveryDate.Value > Convert.ToDateTime(dt.Rows[0]["installDate"].ToString())) // Installation time is early than delivery time
                                    {
                                        return 5; //Installation time is early than delivery time
                                    }
                                    else
                                    {
                                        if (cboStatus.SelectedItem.ToString() == "Delivered")
                                        {
                                            return 19; // Date change and status change to delivered
                                        }
                                        return 6; //Record is ready to inserted
                                    }

                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("错误，订单数据不一致（安装请求）");
                                    return 20;
                                }
                            }
                            else
                            {
                                return 7; //No install but valid
                            }
                        }
                    }
                    return 8; // Able to update status
                }
                else if (orderType == "Technical Support")
                {
                    return 9; // Technical 
                }
                else
                {
                    return 10;  // Public User
                }
            }
            else
            {
                //Manager Function
                if (cboStatus.SelectedItem.ToString() == "Delivered" && string.IsNullOrEmpty(txtWorkerId.Text))
                {
                    return 1;  //You cant complete order without worker
                }
                else if ((expectDeliveryDateMatch && timeSlotMatch && statusMatch) && cusInfoChange)
                {
                    return 14; //Order detail unchange but customer info change
                }
                else if (expectDeliveryDateMatch && timeSlotMatch && statusMatch)  // Nothing change when all match              
                {
                    return 2; //Nothing Change
                }
                else if (!expectDeliveryDateMatch || !timeSlotMatch)
                {
                    mySQLStatement =
                            "select * from deliveryorder d where expectdeliverydate= '" +
                            "" + dtpDeliveryDate.Value.ToString("yyyy-MM-dd") + "' and timeslot ='" +
                            "" + cboSlot.SelectedItem.ToString() + "'";
                    dt = con.MySQLStatementToDatatable(mySQLStatement);

                    if (dt.Rows.Count == 1) // return 1 meaning the slot of that date is not available
                    {
                        return 4; // New slot is not available , chose other slot
                    }
                    else if (dt.Rows.Count == 0)
                    {
                        mySQLStatement =
                            "select InstallationNeed FROM deliveryorder where " +
                            "deliveryid = '" + deliveryId + "'";
                        dt = con.MySQLStatementToDatatable(mySQLStatement);
                        if (dt.Rows[0]["InstallationNeed"].ToString() == "Y")
                        {
                            mySQLStatement =
                                "SELECT installRequestid,installDate,deliveryid,installTimeslot,timeslot " +
                                "FROM installationrequest NATURAL JOIN deliveryorder WHERE deliveryid = '" + deliveryId + "'";

                            dt = con.MySQLStatementToDatatable(mySQLStatement);

                            if (dtpDeliveryDate.Value > Convert.ToDateTime(dt.Rows[0]["installDate"].ToString())) // Installation time is early than delivery time
                            {
                                return 5; //Installation time is early than delivery time
                            }
                            else
                            {
                                return 6; //Record is ready to inserted
                            }
                        }
                        else
                        {
                            return 7; //No install but valid
                        }
                    }
                }
                return 8; // Able to update status                
            }
        }

        public int CheckInstallupdateValid(DataTable dt2)
        {

            bool installDateMatch = Convert.ToDateTime(dt2.Rows[0]["installDate"].ToString()) == dtpDeliveryDate.Value;
            bool timeSlotMatch = dt2.Rows[0]["installTimeslot"].ToString() == cboSlot.SelectedItem.ToString();
            bool statusMatch = dt2.Rows[0]["installStatus"].ToString() == cboStatus.SelectedItem.ToString();
            bool beforeToday = dtpDeliveryDate.Value < DateTime.Today;


            if (dt2.Rows[0]["installStatus"].ToString() == "Completed")
            {
                return 0;  //You are not allow to modify the completed order
            }
            else if (dt2.Rows[0]["installStatus"].ToString() == "Expired" || dt2.Rows[0]["installStatus"].ToString() == "Holding" && cboStatus.SelectedItem.ToString() != "Processing")
            {
                return 1;  //Need to resume
            }
            else if (cboStatus.SelectedItem.ToString() == "Completed" && string.IsNullOrEmpty(txtWorkerId.Text))
            {
                return 2;  //You cant complete order without worker
            }
            else if (installDateMatch && timeSlotMatch && statusMatch)  // Nothing change when all match              
            {
                return 3; //Nothing Change
            }
            else if (!installDateMatch && beforeToday) // New day before today
            {
                return 4; //You should set the day after today
            }
            else if (!installDateMatch || !timeSlotMatch)
            {
                mySQLStatement = "SELECT * FROM installationrequest where installDate='" + dtpDeliveryDate.Value.ToString("yyyy-MM-dd") + "' " +
                    "and installTimeslot ='" + cboSlot.SelectedItem.ToString() + "'";
                dt = con.MySQLStatementToDatatable(mySQLStatement);

                if (dt.Rows.Count == 1) // return 1 meaning the slot of that date is not available
                {
                    return 6; // slot is not available , chose other slot
                }
                else if (dt.Rows.Count == 0)
                {
                    mySQLStatement =
                        "SELECT * FROM installationrequest NATURAL JOIN deliveryorder where " +
                        "installRequestid='" + txtOrdId.Text + "'";
                    dt = con.MySQLStatementToDatatable(mySQLStatement);
                    try
                    {
                        if (dtpDeliveryDate.Value < Convert.ToDateTime(dt.Rows[0]["expectdeliverydate"].ToString()))
                        {

                            return 7; //Installation time is early than delivery time
                        }
                        else
                        {
                            if (cboStatus.SelectedItem.ToString() == "Completed")
                            {
                                return 8; // Date change and status change to delivered
                            }
                            else
                            {
                                if (Int32.Parse(cboSlot.SelectedItem.ToString()) < Int32.Parse(dt.Rows[0]["timeslot"].ToString()))
                                {
                                    return 5; //time slot is early than delivery
                                }
                                else
                                {
                                    return 9; //Record is ready to inserted
                                }
                            }

                        }
                    }
                    catch (Exception)
                    {
                        //MessageBox.Show("Error, inconsistent order data (install request)");
                        return 10;
                    }
                }
            }
            return 11; // Able to update status
        }

        // ---------Button Click Event --------- 
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (frmS != null)
            {
                frmS.RefreshSession(deliveryId);
                //frmS.DisplaySelectedSession();
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            else
            {
                this.Close();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (orderType == "Delivery Worker")
            {
                if (CURRENT_USER.Role == "Manager")
                {
                    mySQLStatement =
                        "Select * from deliveryorder where deliveryid= '" + deliveryId + "'";
                    dt = con.MySQLStatementToDatatable(mySQLStatement);

                    if (dt.Rows[0]["InstallationNeed"].ToString() == "Y")
                    {
                        DialogResult dr = MessageBox.Show("您确定删除现有安装请求和相关记录的订单吗？"
                            , "Delivery Order " + deliveryId, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                        if (dr == DialogResult.Yes)
                        {
                            DeleteDeliveryOrder(2);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("无法删除交货单");
                        }
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("您确定要删除订单和相关记录吗？"
                            , "Delivery Order " + deliveryId, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                        if (dr == DialogResult.Yes)
                        {
                            DeleteDeliveryOrder(1);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("删除失败");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("拒绝访问，需要经理");
                }
            }
            else
            {
                if (CURRENT_USER.Role == "Technical Manager" || CURRENT_USER.Role == "Manager")
                {
                    mySQLStatement =
                        "SELECT * FROM installationrequest NATURAL JOIN " +
                        "deliveryorder where installRequestid ='" + txtOrdId.Text + "'";
                    dt = con.MySQLStatementToDatatable(mySQLStatement);

                    if (dt.Rows.Count == 1)
                    {
                        if (dt.Rows[0]["installStatus"].ToString() == "Completed")
                        {
                            MessageBox.Show("无法删除已完成的订单");
                        }
                        else
                        {
                            DialogResult dr = MessageBox.Show("你确定吗？"
                            , "Installation Order " + txtOrdId.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dr == DialogResult.Yes)
                            {
                                mySQLStatement =
                                "Update deliveryorder set InstallationNeed='N' WHERE " +
                                "deliveryid = '" + dt.Rows[0]["deliveryid"].ToString() + "'";

                                if (con.InsertToMySQL(mySQLStatement))
                                {
                                    mySQLStatement =
                                        "DELETE FROM installationrequest WHERE installRequestid ='" + txtOrdId.Text + "'";
                                    if (con.InsertToMySQL(mySQLStatement))
                                    {
                                        MessageBox.Show("订单已删除");
                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("删除订单失败");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("删除订单失败");
                                }
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("检索数据时出错");
                    }
                }
                else
                {
                    MessageBox.Show("拒绝访问，需要技术经理");
                }
            }
        }
        // ---------Button Click Event ---------


        //Deletion Statement for delivery order / installation order / delivery note
        private void DeleteDeliveryOrder(int n)
        {
            // Installation require is N
            if (n == 1)
            {
                mySQLStatement =
                    "DELETE FROM deliverynote where deliveryid = '" + deliveryId + "'";
                con.InsertToMySQL(mySQLStatement);
                mySQLStatement =
                    "DELETE FROM deliveryorderproduct where deliveryid = '" + deliveryId + "'";
                con.InsertToMySQL(mySQLStatement);
                mySQLStatement =
                    "DELETE FROM deliveryorder where deliveryid = '" + deliveryId + "'";
                con.InsertToMySQL(mySQLStatement);
            }
            else if (n == 2)
            {
                mySQLStatement =
                    "DELETE FROM deliveryorderproduct where deliveryid = '" + deliveryId + "'";
                con.InsertToMySQL(mySQLStatement);
                mySQLStatement =
                    "DELETE FROM installationrequest where deliveryid = '" + deliveryId + "'";
                con.InsertToMySQL(mySQLStatement);
                mySQLStatement =
                    "DELETE FROM deliverynote where deliveryid = '" + deliveryId + "'";
                con.InsertToMySQL(mySQLStatement);
                mySQLStatement =
                    "DELETE FROM deliveryorder where deliveryid = '" + deliveryId + "'";
                con.InsertToMySQL(mySQLStatement);
            }
        }

        private void UpdateInstallationOrder()
        {
            if (cboStatus.SelectedItem.ToString() == "Completed")
            {
                mySQLStatement =
                    "Update installationrequest set installStatus='" + cboStatus.SelectedItem.ToString() + "', " +
                    "installTimeslot='" + cboSlot.SelectedItem.ToString() + "',installDate='" + dtpDeliveryDate.Value.ToString("yyyy-MM-dd") + "', " +
                    "installComDate='" + DateTime.Today.ToString("yyyy-MM-dd") + "'Where installRequestid = '" + txtOrdId.Text + "'";

            }
            else if (cboStatus.SelectedItem.ToString() == "Holding" || cboStatus.SelectedItem.ToString() == "Expired")
            {
                mySQLStatement =
                    "Update installationrequest set installStatus='" + cboStatus.SelectedItem.ToString() + "', " +
                    "installTimeslot='" + cboSlot.SelectedItem.ToString() + "',installDate='" + dtpDeliveryDate.Value.ToString("yyyy-MM-dd") + "' " +
                    ", installEmpID=NULL Where installRequestid = '" + txtOrdId.Text + "'";
                txtWorkerId.Text = null;
            }
            else
            {
                mySQLStatement =
                   "Update installationrequest set installStatus='" + cboStatus.SelectedItem.ToString() + "', " +
                   "installTimeslot='" + cboSlot.SelectedItem.ToString() + "',installDate='" + dtpDeliveryDate.Value.ToString("yyyy-MM-dd") + "'" +
                   "Where installRequestid = '" + txtOrdId.Text + "'";
            }

            if (con.InsertToMySQL(mySQLStatement))
                MessageBox.Show("订单信息已更新");
            else
                MessageBox.Show("安装请求更新失败");
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            frmOrderDetailCN frm = new frmOrderDetailCN(deliveryId, frmS, CURRENT_USER, "Technical Support");
            frm.SetOpenFromOrderDetail();
            frm.DisableCrossButton();
            frm.Show();
            DialogResult dr = frm.DialogResult;
            if (dr == DialogResult.Cancel)
            {
                RetrieveOrderDetail();
            }
        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            frmOrderDetailCN frm = new frmOrderDetailCN(deliveryId, frmS, CURRENT_USER, "Delivery Worker");
            frm.SetOpenFromOrderDetail();
            frm.DisableCrossButton();
            frm.Show();
            DialogResult dr = frm.DialogResult;
            if (dr == DialogResult.Cancel)
            {
                RetrieveOrderDetail();
            }
        }
    }
}
