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

namespace StockRecordingWarehouseInventory
{
    public partial class InventoryManagementSystem : Form
    {
        public InventoryManagementSystem()
        {
            InitializeComponent();
            panelAddItems.Show();
            panelAddItems.Focus();
            panelAddItems.BringToFront();


        }

        private void InventoryManagementSystem_Load(object sender, EventArgs e)
        {
            panelAddItems.BringToFront();

            using (var better_limited = new WindowsFormsApp1.better_limitedEntities())
            {
                // Low level product alert
                var emp = (from list in better_limited.inventory_level
                           select list);    // select * from inventory_levels

                foreach (var emp2 in emp.ToList())
                {
                    dataGridView1.Rows.Add(emp2.StockID, emp2.StockName, emp2.StockType, emp2.StockBrand, emp2.StockStatus, emp2.StockQuantity, emp2.RefillLevel, emp2.StockMaxNumber, emp2.EmpID);
                }


                var orderDetail2 = (from list in better_limited.inventory_level
                                    where list.StockStatus.Contains("Out of stock")
                                    select list).Count();


                /*var orderDetail = (from list in better_limited.inventory_levels
                                   where list.StockQuantity < 6
                                   select new
                                   {
                                       list.StockID,
                                       list.StockName
                                   });

                var orderDetail2 = (from list in better_limited.inventory_levels
                                    where list.StockQuantity < 6
                                    select list).Count();*/

                MessageBox.Show("Please note, you have '" + orderDetail2 + "' items whose current stock level is low.");
                btnNumOfReorder.Text = orderDetail2.ToString();

                btnAdditems.BackColor = Color.FromArgb(135, 206, 250);

                txtAddStockID.Enabled = false;
                txtAddStockID.Text = "-----";
                txtDeleteStockID.Enabled = false;
                txtDeleteStockID.Text = "-----";
                txtUpdateStockID.Enabled = false;
                txtUpdateStockID.Text = "-----";

                label6.Visible = false;
                txtAddStockStatus.Visible = false;

                label26.Visible = false;

                txtTopLabel.Text = "Add Item";
            }
        }

        private void btnAdditems_Click_1(object sender, EventArgs e)
        {
            txtTopLabel.Text = "Add Item";
            panelAddItems.BringToFront();

            /*Form1 delete = new Form1();
            delete.Show();
            this.Hide();*/

            using (var better_limited = new WindowsFormsApp1.better_limitedEntities())
            {
                dataGridView1.Rows.Clear();

                // Low level product alert
                var emp = (from list in better_limited.inventory_level
                           select list);    // select * from inventory_levels

                foreach (var emp2 in emp.ToList())
                {
                    dataGridView1.Rows.Add(emp2.StockID, emp2.StockName, emp2.StockType, emp2.StockBrand, emp2.StockStatus, emp2.StockQuantity, emp2.RefillLevel, emp2.StockMaxNumber, emp2.EmpID);
                }


                btnAdditems.Enabled = false;
                btnDeleteitems.Enabled = true;
                btnUpdateitems.Enabled = true;
                btnReorderingitems.Enabled = true;
                btnReordersetting.Enabled = true;

                btnAdditems.BackColor = Color.FromArgb(135, 206, 250);
                btnDeleteitems.BackColor = Color.FromArgb(50, 50, 112);
                btnUpdateitems.BackColor = Color.FromArgb(50, 50, 112);
                btnReorderingitems.BackColor = Color.FromArgb(50, 50, 112);
                btnReordersetting.BackColor = Color.FromArgb(50, 50, 112);

            }

        }

        private void btnDeleteitems_Click_1(object sender, EventArgs e)
        {
            txtTopLabel.Text = "Delete Item";
            using (var better_limited = new WindowsFormsApp1.better_limitedEntities())
            {
                dataGridView2.Rows.Clear();

                // Low level product alert
                var emp = (from list in better_limited.inventory_level
                           select list);    // select * from inventory_levels

                foreach (var emp2 in emp.ToList())
                {
                    dataGridView2.Rows.Add(emp2.StockID, emp2.StockName, emp2.StockType, emp2.StockBrand, emp2.StockStatus, emp2.StockQuantity, emp2.RefillLevel, emp2.StockMaxNumber, emp2.EmpID);
                }


                txtDeleteStockName.Clear();
                comboDeleteStockType.SelectedIndex = -1;
                txtDeleteStockBrand.Clear();
                txtDeleteStockQty.Clear();
                txtDeleteRefillLevel.Clear();
                txtDeleteMaxNo.Clear();
                txtDeleteEmpID.Clear();



                btnAdditems.Enabled = true;
                btnDeleteitems.Enabled = false;
                btnUpdateitems.Enabled = true;
                btnReorderingitems.Enabled = true;
                btnReordersetting.Enabled = true;

                btnAdditems.BackColor = Color.FromArgb(50, 50, 112);
                btnDeleteitems.BackColor = Color.FromArgb(135, 206, 250);
                btnUpdateitems.BackColor = Color.FromArgb(50, 50, 112);
                btnReorderingitems.BackColor = Color.FromArgb(50, 50, 112);
                btnReordersetting.BackColor = Color.FromArgb(50, 50, 112);


                //show the delete panel
                panelDeleteItems.BringToFront();
                label17.Visible = false;
                txtDeleteStockStatus.Visible = false;





            }
        }

        private void btnUpdateitems_Click_1(object sender, EventArgs e)
        {
            txtTopLabel.Text = "Update Item";
            using (var better_limited = new WindowsFormsApp1.better_limitedEntities())
            {
                dataGridView3.Rows.Clear();

                // Low level product alert
                var emp = (from list in better_limited.inventory_level
                           select list);    // select * from inventory_levels

                foreach (var emp2 in emp.ToList())
                {
                    dataGridView3.Rows.Add(emp2.StockID, emp2.StockName, emp2.StockType, emp2.StockBrand, emp2.StockStatus, emp2.StockQuantity, emp2.RefillLevel, emp2.StockMaxNumber, emp2.EmpID);
                }


                txtUpdateStockName.Clear();
                comboUpdateStockType.SelectedIndex = -1;
                txtUpdateStockBrand.Clear();
                txtUpdateStockQty.Clear();
                txtUpdateRefillLevel.Clear();
                txtUpdateMaxNo.Clear();
                txtUpdateEmpID.Clear();


                btnAdditems.Enabled = true;
                btnDeleteitems.Enabled = true;
                btnUpdateitems.Enabled = false;
                btnReorderingitems.Enabled = true;
                btnReordersetting.Enabled = true;

                btnAdditems.BackColor = Color.FromArgb(50, 50, 112);
                btnDeleteitems.BackColor = Color.FromArgb(50, 50, 112);
                btnUpdateitems.BackColor = Color.FromArgb(135, 206, 250);
                btnReorderingitems.BackColor = Color.FromArgb(50, 50, 112);
                btnReordersetting.BackColor = Color.FromArgb(50, 50, 112);

                //show the Update panel
                panelUpdateItems.BringToFront();
                label17.Visible = false;
                txtUpdateStockStatus.Visible = false;
            }
        }


        private void btnReorderingitems_Click_1(object sender, EventArgs e)
        {
            txtTopLabel.Text = "Reorder Item";

            {
                penelReOrderItem.BringToFront();

                using (var better_limited = new WindowsFormsApp1.better_limitedEntities())
                {
                    dataGridView4.Rows.Clear();

                    // Low level product alert
                    var emp = (from list in better_limited.inventory_level
                               where list.StockStatus.Contains("Out of stock")
                               select list);    // select * from inventory_levels

                    foreach (var emp2 in emp.ToList())
                    {
                        dataGridView4.Rows.Add(emp2.StockID, emp2.StockName, emp2.StockType, emp2.StockBrand, emp2.StockStatus, emp2.StockQuantity, emp2.RefillLevel, emp2.StockMaxNumber, emp2.EmpID);
                    }


                    btnAdditems.Enabled = true;
                    btnDeleteitems.Enabled = true;
                    btnUpdateitems.Enabled = true;
                    btnReorderingitems.Enabled = false;
                    btnReordersetting.Enabled = true;

                    btnAdditems.BackColor = Color.FromArgb(50, 50, 112);
                    btnDeleteitems.BackColor = Color.FromArgb(50, 50, 112);
                    btnUpdateitems.BackColor = Color.FromArgb(50, 50, 112);
                    btnReorderingitems.BackColor = Color.FromArgb(135, 206, 250);
                    btnReordersetting.BackColor = Color.FromArgb(50, 50, 112);
                }
            }
        }

        private void btnReordersetting_Click_1(object sender, EventArgs e)
        {
            txtTopLabel.Text = "Supplier";
            {
                panelSupplier.BringToFront();

                using (var better_limited = new WindowsFormsApp1.better_limitedEntities())
                {
                    dataGridView5.Rows.Clear();

                    var emp = (from list in better_limited.supplier
                               select list);    // select * from inventory_levels

                    foreach (var emp2 in emp.ToList())
                    {
                        dataGridView5.Rows.Add(emp2.SupplierName, emp2.SupplierPhoneNumber, emp2.SupplierEmail, emp2.SupplierAddress, emp2.SupplierOther);
                    }
                }
            }


            btnAdditems.Enabled = true;
            btnDeleteitems.Enabled = true;
            btnUpdateitems.Enabled = true;
            btnReorderingitems.Enabled = true;
            btnReordersetting.Enabled = false;

            btnAdditems.BackColor = Color.FromArgb(50, 50, 112);
            btnDeleteitems.BackColor = Color.FromArgb(50, 50, 112);
            btnUpdateitems.BackColor = Color.FromArgb(50, 50, 112);
            btnReorderingitems.BackColor = Color.FromArgb(50, 50, 112);
            btnReordersetting.BackColor = Color.FromArgb(135, 206, 250);
        }




        void FillGridView()
        {
            using (var better_limited = new WindowsFormsApp1.better_limitedEntities())
            {
                dataGridView1.Rows.Clear();

                // Low level product alert
                var emp = (from list in better_limited.inventory_level
                           select list);    // select * from inventory_levels

                foreach (var emp2 in emp.ToList())
                {
                    dataGridView1.Rows.Add(emp2.StockID, emp2.StockName, emp2.StockType, emp2.StockBrand, emp2.StockStatus, emp2.StockQuantity, emp2.RefillLevel, emp2.StockMaxNumber, emp2.EmpID);
                }
            }
        }

        private void btnAddItem_Click_1(object sender, EventArgs e)
        {
            if (txtAddStockName.Text != "" && comboAddStockType.Text != "" && txtAddStockBrand.Text != "" && txtAddStockQty.Text != "" && txtAddRefillLevel.Text != "" && txtAddMaxNo.Text != "" && txtAddEmpID.Text != "")
            {
                try
                {

                    MySqlConnection conn = new MySqlConnection(@"datasource=127.0.0.1;port=3306;SslMode=none;username=root;password=;database=better_limited;");
                    string query = "insert into `inventory level`(`StockName`,`StockType`,`StockBrand`,`StockStatus`,`StockQuantity`,`StockMaxNumber`, `EmpID`, `RefillLevel`) values('" + txtAddStockName.Text.Trim() + "','" + comboAddStockType.Text.Trim() + "','" + txtAddStockBrand.Text.Trim() + "','" + txtAddStockStatus.Text.Trim() + "','" + txtAddStockQty.Text.Trim() + "','" + txtAddMaxNo.Text.Trim() + "','" + txtAddEmpID.Text.Trim() + "','" + txtAddRefillLevel.Text.Trim() + "')";


                    string queryUpdateStockStatus = "update `inventory level` set `StockStatus`= '" + "Out of stock'" + "WHERE" + "`StockQuantity` < `RefillLevel`";
                    string queryUpdateStockStatus2 = "update `inventory level` set `StockStatus`= '" + "Sufficient'" + "WHERE" + "`StockQuantity` > `RefillLevel`";
                    MySqlCommand cmdUpdateStockStatus = new MySqlCommand(queryUpdateStockStatus, conn);
                    MySqlCommand cmdUpdateStockStatus2 = new MySqlCommand(queryUpdateStockStatus2, conn);


                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    cmdUpdateStockStatus.ExecuteNonQuery();
                    cmdUpdateStockStatus2.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("The item has been added successfully!");
                    txtAddStockName.Clear();
                    comboAddStockType.SelectedIndex = -1;
                    txtAddStockBrand.Clear();
                    txtAddStockQty.Clear();
                    txtAddRefillLevel.Clear();
                    txtAddMaxNo.Clear();
                    txtAddEmpID.Clear();


                    panelAddItems.BringToFront();


                    using (var better_limited = new WindowsFormsApp1.better_limitedEntities())
                    {
                        dataGridView1.Rows.Clear();

                        // Low level product alert
                        var emp = (from list in better_limited.inventory_level
                                   select list);    // select * from inventory_levels

                        foreach (var emp2 in emp.ToList())
                        {
                            dataGridView1.Rows.Add(emp2.StockID, emp2.StockName, emp2.StockType, emp2.StockBrand, emp2.StockStatus, emp2.StockQuantity, emp2.RefillLevel, emp2.StockMaxNumber, emp2.EmpID);
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Please make sure all fields are filled in correctly");
            }
            UpdatebtnNumOfReorderNum();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txtAddStockID.Text = row.Cells[0].Value.ToString();
                txtAddStockName.Text = row.Cells[1].Value.ToString();
                comboAddStockType.Text = row.Cells[2].Value.ToString();
                txtAddStockBrand.Text = row.Cells[3].Value.ToString();
                txtAddStockStatus.Text = row.Cells[4].Value.ToString();
                txtAddStockQty.Text = row.Cells[5].Value.ToString();
                txtAddRefillLevel.Text = row.Cells[6].Value.ToString();
                txtAddMaxNo.Text = row.Cells[7].Value.ToString();
                txtAddEmpID.Text = row.Cells[8].Value.ToString();
            }
        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                txtDeleteStockID.Text = row.Cells[0].Value.ToString();
                txtDeleteStockName.Text = row.Cells[1].Value.ToString();
                comboDeleteStockType.Text = row.Cells[2].Value.ToString();
                txtDeleteStockBrand.Text = row.Cells[3].Value.ToString();
                txtDeleteStockStatus.Text = row.Cells[4].Value.ToString();
                txtDeleteStockQty.Text = row.Cells[5].Value.ToString();
                txtDeleteRefillLevel.Text = row.Cells[6].Value.ToString();
                txtDeleteMaxNo.Text = row.Cells[7].Value.ToString();
                txtDeleteEmpID.Text = row.Cells[8].Value.ToString();
            }
        }

        private void dataGridView3_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView3.Rows[e.RowIndex];
                txtUpdateStockID.Text = row.Cells[0].Value.ToString();
                txtUpdateStockName.Text = row.Cells[1].Value.ToString();
                comboUpdateStockType.Text = row.Cells[2].Value.ToString();
                txtUpdateStockBrand.Text = row.Cells[3].Value.ToString();
                txtUpdateStockStatus.Text = row.Cells[4].Value.ToString();
                txtUpdateStockQty.Text = row.Cells[5].Value.ToString();
                txtUpdateRefillLevel.Text = row.Cells[6].Value.ToString();
                txtUpdateMaxNo.Text = row.Cells[7].Value.ToString();
                txtUpdateEmpID.Text = row.Cells[8].Value.ToString();
            }
        }

        private void btnDeleteItem_Click_1(object sender, EventArgs e)
        {
            if (txtAddStockID.Text != "")
            {
                try
                {
                    MySqlConnection conn = new MySqlConnection(@"datasource=127.0.0.1;port=3306;SslMode=none;username=root;password=;database=better_limited;");
                    string query = "delete from `inventory level` where `StockID`= '" + txtDeleteStockID.Text + "' ";


                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("The item has been deleted successfully!");
                    txtDeleteStockName.Clear();
                    comboDeleteStockType.SelectedIndex = -1;
                    txtDeleteStockBrand.Clear();
                    txtDeleteStockQty.Clear();
                    txtDeleteRefillLevel.Clear();
                    txtDeleteMaxNo.Clear();
                    txtDeleteEmpID.Clear();

                    using (var better_limited = new WindowsFormsApp1.better_limitedEntities())
                    {
                        dataGridView2.Rows.Clear();

                        // Low level product alert
                        var emp = (from list in better_limited.inventory_level
                                   select list);    // select * from inventory_levels

                        foreach (var emp2 in emp.ToList())
                        {
                            dataGridView2.Rows.Add(emp2.StockID, emp2.StockName, emp2.StockType, emp2.StockBrand, emp2.StockStatus, emp2.StockQuantity, emp2.RefillLevel, emp2.StockMaxNumber, emp2.EmpID);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Please make sure StockID fields are filled");
            }

            UpdatebtnNumOfReorderNum();
        }

        private void btnUpdateItem_Click_1(object sender, EventArgs e)
        {
            if (txtUpdateStockName.Text != "" && comboUpdateStockType.Text != "" && txtUpdateStockBrand.Text != "" && txtUpdateStockQty.Text != "" && txtUpdateRefillLevel.Text != "" && txtUpdateMaxNo.Text != "" && txtUpdateEmpID.Text != "" && comboUpdateStockType.Text != "")
            {
                try
                {



                    MySqlConnection conn = new MySqlConnection(@"datasource=127.0.0.1;port=3306;SslMode=none;username=root;password=;database=better_limited;");
                    string query = "update `inventory level` set `StockName`= '" + txtUpdateStockName.Text + "',`StockType`='" + comboUpdateStockType.Text + "',`StockBrand`= '" + txtUpdateStockBrand.Text + "',`StockStatus`= '" + txtUpdateStockStatus.Text + "',`StockQuantity`= '" + txtUpdateStockQty.Text + "',`StockMaxNumber`= '" + txtUpdateMaxNo.Text + "',`EmpID`= '" + txtUpdateEmpID.Text + "',`RefillLevel`= '" + txtUpdateRefillLevel.Text + "'where `StockID`= '" + txtUpdateStockID.Text + "' ";


                    string queryUpdateStockStatus = "update `inventory level` set `StockStatus`= '" + "Out of stock'" + "WHERE" + "`StockQuantity` < `RefillLevel`";
                    string queryUpdateStockStatus2 = "update `inventory level` set `StockStatus`= '" + "Sufficient'" + "WHERE" + "`StockQuantity` > `RefillLevel`";
                    MySqlCommand cmdUpdateStockStatus = new MySqlCommand(queryUpdateStockStatus, conn);
                    MySqlCommand cmdUpdateStockStatus2 = new MySqlCommand(queryUpdateStockStatus2, conn);

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    cmdUpdateStockStatus.ExecuteNonQuery();
                    cmdUpdateStockStatus2.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("The item has been updated successfully!");
                    txtUpdateStockName.Clear();
                    comboUpdateStockType.SelectedIndex = -1;
                    txtUpdateStockBrand.Clear();
                    txtUpdateStockQty.Clear();
                    txtUpdateRefillLevel.Clear();
                    txtUpdateMaxNo.Clear();
                    txtUpdateEmpID.Clear();

                    using (var better_limited = new WindowsFormsApp1.better_limitedEntities())
                    {
                        dataGridView3.Rows.Clear();

                        // Low level product alert
                        var emp = (from list in better_limited.inventory_level
                                   select list);    // select * from inventory_levels

                        foreach (var emp2 in emp.ToList())
                        {
                            dataGridView3.Rows.Add(emp2.StockID, emp2.StockName, emp2.StockType, emp2.StockBrand, emp2.StockStatus, emp2.StockQuantity, emp2.RefillLevel, emp2.StockMaxNumber, emp2.EmpID);
                        }
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Please make sure all fields are filled in correctly");
            }
            UpdatebtnNumOfReorderNum();
        }

        private void dataGridView4_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView4.Rows[e.RowIndex];
                txtReorderStockID.Text = row.Cells[0].Value.ToString();
                txtReorderName.Text = row.Cells[1].Value.ToString();
                txtReorderStatus.Text = row.Cells[4].Value.ToString();
                txtReorderType.Text = row.Cells[2].Value.ToString();
                txtReorderBrand.Text = row.Cells[3].Value.ToString();
            }
        }

        private void btnReorderItem_Click_1(object sender, EventArgs e)
        {
            if (txtReorderStockID.Text != "" && txtReorderName.Text != "" && txtReorderStatus.Text != "" && txtReorderType.Text != "" && txtReorderBrand.Text != "" && txtReorderSupplier.Text != "" && txtReorderReceiveDate2.Text != "" && txtReorderPriceUnit.Text != "" && txtReorderQty.Text != "")
            {
                try
                {
                    int Amounts = (Convert.ToInt32(txtReorderPriceUnit.Text)) * (Convert.ToInt32(txtReorderQty.Text));
                    String purchaseAmounts = Amounts.ToString();

                    MySqlConnection conn = new MySqlConnection(@"datasource=127.0.0.1;port=3306;SslMode=none;username=root;password=;database=better_limited;");
                    string query = "insert into `reorderingitem`(`ItemName`,`ItemType`,`ItemBrand`,`Supplier`,`ItemQuantity`, `ItemPrice`, `Amounts`, `ReceiveDate`) values('" + txtReorderName.Text.Trim() + "','" + txtReorderType.Text.Trim() + "','" + txtReorderBrand.Text.Trim() + "','" + txtReorderSupplier.Text.Trim() + "','" + txtReorderQty.Text.Trim() + "','" + txtReorderPriceUnit.Text.Trim() + "','" + purchaseAmounts + "','" + txtReorderReceiveDate.Text.Trim() + "')";


                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("The item has been added successfully!");
                    txtReorderStockID.Clear();
                    txtReorderType.SelectedIndex = -1;
                    txtReorderName.Clear();
                    txtReorderStatus.Clear();
                    txtReorderBrand.Clear();
                    txtReorderSupplier.SelectedIndex = -1;
                    txtReorderReceiveDate.Clear();
                    txtReorderPriceUnit.Clear();
                    txtReorderQty.Clear();
                    txtReorderQty.Clear();

                    using (var better_limited = new WindowsFormsApp1.better_limitedEntities())
                    {
                        dataGridView3.Rows.Clear();

                        // Low level product alert
                        var emp = (from list in better_limited.inventory_level
                                   select list);    // select * from inventory_levels

                        foreach (var emp2 in emp.ToList())
                        {
                            dataGridView3.Rows.Add(emp2.StockID, emp2.StockName, emp2.StockType, emp2.StockBrand, emp2.StockStatus, emp2.StockQuantity, emp2.RefillLevel, emp2.StockMaxNumber, emp2.EmpID);
                        }
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Please make sure all fields are filled in correctly");
            }
        }


        //use to update the btnNumOfReorder that next the Reordering item
        void UpdatebtnNumOfReorderNum()
        {

            using (var better_limited = new WindowsFormsApp1.better_limitedEntities())
            {
                var orderDetail2 = (from list in better_limited.inventory_level
                                    where list.StockStatus.Contains("Out of stock")
                                    select list).Count();

                btnNumOfReorder.Text = orderDetail2.ToString();
            }
        }

        private void btnViewOrderingItem_Click(object sender, EventArgs e)
        {
            {
                InventoryManagementSystemPopUpForm PopupForm = new InventoryManagementSystemPopUpForm();
                PopupForm.Show();
            }
        }

        private void btnSupplierConfirm_Click(object sender, EventArgs e)
        {

            if (txtSupplierPhoneNum.Text != "" && txtSupplierName.Text != "" && txtSupplierAddress.Text != "" && txtSupplierEmail.Text != "")
            {
                try
                {

                    MySqlConnection conn = new MySqlConnection(@"datasource=127.0.0.1;port=3306;SslMode=none;username=root;password=;database=better_limited;");
                    string query = "insert into `supplier`(`SupplierName`,`SupplierPhoneNumber`,`SupplierEmail`,`SupplierAddress`,`SupplierOther`) values('" + txtSupplierName.Text.Trim() + "','" + txtSupplierPhoneNum.Text.Trim() + "','" + txtSupplierEmail.Text.Trim() + "','" + txtSupplierAddress.Text.Trim() + "','" + txtSupplierInfo.Text.Trim() + "')";


                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("The item has been add successfully!");
                    txtSupplierName.Clear();
                    txtSupplierPhoneNum.Clear();
                    txtSupplierAddress.Clear();
                    txtSupplierInfo.Clear();
                    txtSupplierEmail.Clear();

                    using (var better_limited = new WindowsFormsApp1.better_limitedEntities())
                    {
                        dataGridView5.Rows.Clear();

                        // Low level product alert
                        var emp = (from list in better_limited.supplier
                                   select list);    // select * from inventory_levels

                        foreach (var emp2 in emp.ToList())
                        {
                            dataGridView5.Rows.Add(emp2.SupplierName, emp2.SupplierPhoneNumber, emp2.SupplierEmail, emp2.SupplierAddress, emp2.SupplierOther);

                        }
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Please make sure all fields are filled in correctly");
            }
        }

        private void txtReorderReceiveDate2_ValueChanged(object sender, EventArgs e)
        {
            txtReorderReceiveDate.Text = txtReorderReceiveDate2.Value.Date.ToString("yyyy-MM-dd");
        }

        private void txtReorderSupplier_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(@"datasource=127.0.0.1;port=3306;SslMode=none;username=root;password=;database=better_limited;"))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT `SupplierName` FROM `supplier`", conn);

                MySqlDataReader dr = cmd.ExecuteReader();

                IList<string> listName = new List<string>();
                while (dr.Read())
                {
                    listName.Add(dr[0].ToString());
                }
                listName = listName.Distinct().ToList();
                txtReorderSupplier.DataSource = listName;
            }
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView5.Rows[e.RowIndex];
                txtSupplierName.Text = row.Cells[0].Value.ToString();
                txtSupplierEmail.Text = row.Cells[2].Value.ToString();
                txtSupplierPhoneNum.Text = row.Cells[1].Value.ToString();
                txtSupplierAddress.Text = row.Cells[3].Value.ToString();
                if (row.Cells[4].Value.ToString() == "null")
                {
                    txtSupplierInfo.Text = "null";
                }
                else
                {
                    txtSupplierInfo.Text = row.Cells[4].Value.ToString();
                }
            }
        }

        private void btnSupplierDelete_Click(object sender, EventArgs e)
        {
            if (txtSupplierName.Text != "")
            {
                try
                {
                    MySqlConnection conn = new MySqlConnection(@"datasource=127.0.0.1;port=3306;SslMode=none;username=root;password=;database=better_limited;");
                    string query = "delete from `supplier` where `SupplierName`= '" + txtSupplierName.Text + "' ";


                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("The item has been deleted successfully!");
                    txtSupplierName.Clear();
                    txtSupplierPhoneNum.Clear();
                    txtSupplierAddress.Clear();
                    txtSupplierInfo.Clear();
                    txtSupplierEmail.Clear();

                    using (var better_limited = new WindowsFormsApp1.better_limitedEntities())
                    {
                        dataGridView5.Rows.Clear();

                        // Low level product alert
                        var emp = (from list in better_limited.supplier
                                   select list);    // select * from inventory_levels

                        foreach (var emp2 in emp.ToList())
                        {
                            dataGridView5.Rows.Add(emp2.SupplierName, emp2.SupplierPhoneNumber, emp2.SupplierEmail, emp2.SupplierAddress, emp2.SupplierOther);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Please make sure SupplierName fields are filled");
            }
        }


        private void btnSupplierUpdate_Click_1(object sender, EventArgs e)
        {

            if (txtSupplierName.Text != "")
            {
                try
                {
                    MySqlConnection conn = new MySqlConnection(@"datasource=127.0.0.1;port=3306;SslMode=none;username=root;password=;database=better_limited;");
                    string query = "update `supplier` set `SupplierPhoneNumber`= '" + txtSupplierPhoneNum.Text + "',`SupplierEmail`= '" + txtSupplierEmail.Text + "',`SupplierAddress`= '" + txtSupplierAddress.Text + "',`SupplierOther`= '" + txtSupplierInfo.Text + "'where `SupplierName`= '" + txtSupplierName.Text + "' ";


                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("The item has been updated successfully!");
                    txtSupplierName.Clear();
                    txtSupplierPhoneNum.Clear();
                    txtSupplierAddress.Clear();
                    txtSupplierInfo.Clear();
                    txtSupplierEmail.Clear();

                    using (var better_limited = new WindowsFormsApp1.better_limitedEntities())
                    {
                        dataGridView5.Rows.Clear();

                        // Low level product alert
                        var emp = (from list in better_limited.supplier
                                   select list);    // select * from inventory_levels

                        foreach (var emp2 in emp.ToList())
                        {
                            dataGridView5.Rows.Add(emp2.SupplierName, emp2.SupplierPhoneNumber, emp2.SupplierEmail, emp2.SupplierAddress, emp2.SupplierOther);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Please make sure SupplierName fields are filled");
            }
        }


        private void comboUpdateStockType_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(@"datasource=127.0.0.1;port=3306;SslMode=none;username=root;password=;database=better_limited;"))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT `StockType` FROM `inventory level`", conn);

                MySqlDataReader dr = cmd.ExecuteReader();

                IList<string> listName = new List<string>();
                while (dr.Read())
                {
                    listName.Add(dr[0].ToString());
                }
                listName = listName.Distinct().ToList();
                comboUpdateStockType.DataSource = listName;
            }
        }

        private void comboAddStockType_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(@"datasource=127.0.0.1;port=3306;SslMode=none;username=root;password=;database=better_limited;"))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT `StockType` FROM `inventory level`", conn);

                MySqlDataReader dr = cmd.ExecuteReader();

                IList<string> listName = new List<string>();
                while (dr.Read())
                {
                    listName.Add(dr[0].ToString());
                }
                listName = listName.Distinct().ToList();
                comboAddStockType.DataSource = listName;
            }
        }

        private void txtReorderType_Click(object sender, EventArgs e)
        {
            using(MySqlConnection conn = new MySqlConnection(@"datasource=127.0.0.1;port=3306;SslMode=none;username=root;password=;database=better_limited;"))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT `StockType` FROM `inventory level`", conn);

                MySqlDataReader dr = cmd.ExecuteReader();

                IList<string> listName = new List<string>();
                while (dr.Read())
                {
                    listName.Add(dr[0].ToString());
                }
                listName = listName.Distinct().ToList();
                txtReorderType.DataSource = listName;
            }
        }

        private void comboDeleteStockType_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(@"datasource=127.0.0.1;port=3306;SslMode=none;username=root;password=;database=better_limited;"))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT `StockType` FROM `inventory level`", conn);

                MySqlDataReader dr = cmd.ExecuteReader();

                IList<string> listName = new List<string>();
                while (dr.Read())
                {
                    listName.Add(dr[0].ToString());
                }
                listName = listName.Distinct().ToList();
                comboDeleteStockType.DataSource = listName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WindowsFormsApp1.Form1 frmForm = new WindowsFormsApp1.Form1();
            frmForm.Show();
            this.Hide();
        }
    }
}
    
    



