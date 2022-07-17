using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockRecordingWarehouseInventory
{
    public partial class InventoryManagementSystemPopUpForm : Form
    {
        public InventoryManagementSystemPopUpForm()
        {

            // ItemName`, `ItemType`, `ItemBrand`, `Supplier`, `ItemQuantity`, `ItemPrice`, `Amounts`, `ReceiveDate`
            InitializeComponent();
        }

        private void InventoryManagementSystemPopUpForm_Load(object sender, EventArgs e)
        {
            {
                dataGridView4.Rows.Clear();
                MySqlConnection conn = new MySqlConnection(@"datasource=127.0.0.1;port=3306;SslMode=none;username=root;password=;database=better_limited; convert zero datetime=True");
                MySqlDataAdapter unp_sda = new MySqlDataAdapter("select * from reorderingitem ", conn);
                DataTable unp_dt = new DataTable();
                unp_sda.Fill(unp_dt);
                dataGridView4.DataSource = unp_dt;

                cboReceipt2.Visible = false;
                cboReceipt3.Visible = false;
                cboReceipt4.Visible = false;
                cboReceipt5.Visible = false;

            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            {
                MySqlConnection conn = new MySqlConnection(@"datasource=127.0.0.1;port=3306;SslMode=none;username=root;password=;database=better_limited; convert zero datetime=True");
                MySqlDataAdapter unp_sda = new MySqlDataAdapter("select * from reorderingitem ", conn);
                DataTable unp_dt = new DataTable();
                unp_sda.Fill(unp_dt);
                dataGridView4.DataSource = unp_dt;
            }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView4.Rows[e.RowIndex];
                txtAddStockID.Text = row.Cells[0].Value.ToString();
                txtAddStockName.Text = row.Cells[1].Value.ToString();
                comboAddStockType.Text = row.Cells[2].Value.ToString();
                txtAddStockBrand.Text = row.Cells[3].Value.ToString();
                txtAddStockStatus.Text = row.Cells[4].Value.ToString();
                txtAddStockQty.Text = row.Cells[5].Value.ToString();
                txtAddRefillLevel.Text = row.Cells[6].Value.ToString();
                txtAddMaxNo.Text = row.Cells[7].Value.ToString();
                txtAddEmpID.Text = row.Cells[8].Value.ToString();
            }*/

        }


        int txtReOrderID1 = 0;
        String txtItemType1 = "";
        String txtItemBrand1 = "";
        String txtSupplier1 = "";
        int txtItemQuantity1 = 0;
        int txtItemPrice1 = 0;
        int txtAmounts1 = 0;
        String txtReceiveDate1 = "";

        int txtReOrderID2 = 0;
        String txtItemType2 = "";
        String txtItemBrand2 = "";
        String txtSupplier2 = "";
        int txtItemQuantity2 = 0;
        int txtItemPrice2 = 0;
        int txtAmounts2 = 0;
        String txtReceiveDate2 = "";

        int txtReOrderID3 = 0;
        String txtItemType3 = "";
        String txtItemBrand3 = "";
        String txtSupplier3 = "";
        int txtItemQuantity3 = 0;
        int txtItemPrice3 = 0;
        int txtAmounts3 = 0;
        String txtReceiveDate3 = "";

        int txtReOrderID4 = 0;
        String txtItemType4 = "";
        String txtItemBrand4 = "";
        String txtSupplier4 = "";
        int txtItemQuantity4 = 0;
        int txtItemPrice4 = 0;
        int txtAmounts4 = 0;
        String txtReceiveDate4 = "";

        int txtReOrderID5 = 0;
        String txtItemType5 = "";
        String txtItemBrand5 = "";
        String txtSupplier5 = "";
        int txtItemQuantity5 = 0;
        int txtItemPrice5 = 0;
        int txtAmounts5 = 0;
        String txtReceiveDate5 = "";


        void printReceipt()
        {
            /*var txtReOrderID = "";
            var txtItemType = "";
            var txtItemBrand = "";
            var txtSupplier = "";
            var txtItemQuantity = "";
            var txtItemPrice = "";
            var txtAmounts = "";
            var txtReceiveDate = "";*/

            if (cboReceipt1.SelectedItem != null)
            {

                using (var better_limited = new WindowsFormsApp1.better_limitedEntities())
                {
                    int code1 = Convert.ToInt32(cboReceipt1.Text);
                    var emp = (from list in better_limited.reorderingitem
                               where list.ReOrderID == code1
                               //== Int16.Parse(cboReceipt1.Text)
                               select list);    // select * from inventory_levels

                    foreach (var emp2 in emp.ToList())
                    {
                        txtReOrderID1 = emp2.ReOrderID;
                        txtItemType1 = emp2.ItemType;
                        txtItemBrand1 = emp2.ItemBrand;
                        txtSupplier1 = emp2.Supplier;
                        txtItemQuantity1 = (int)emp2.ItemQuantity;
                        txtItemPrice1 = (int)emp2.ItemPrice;
                        txtAmounts1 = (int)emp2.Amounts;
                        txtReceiveDate1 = (emp2.ReceiveDate).Value.ToString("dd MMMM yyyy");
                    }
                }

            }

            if (cboReceipt2.Text.Length != 0)
            {
                using (var better_limited = new WindowsFormsApp1.better_limitedEntities())
                {
                    int code2 = Convert.ToInt32(cboReceipt2.Text);
                    var emp = (from list in better_limited.reorderingitem
                               where list.ReOrderID == code2
                               //where list.ReOrderID.Equals(cboReceipt1.Text)
                               select list);    // select * from inventory_levels

                    foreach (var emp2 in emp.ToList())
                    {
                        txtReOrderID2 = emp2.ReOrderID;
                        txtItemType2 = emp2.ItemType;
                        txtItemBrand2 = emp2.ItemBrand;
                        txtSupplier2 = emp2.Supplier;
                        txtItemQuantity2 = (int)emp2.ItemQuantity;
                        txtItemPrice2 = (int)emp2.ItemPrice;
                        txtAmounts2 = (int)emp2.Amounts;
                        txtReceiveDate2 = (emp2.ReceiveDate).Value.ToString("dd MMMM yyyy");
                    }
                }

            }
            if (cboReceipt3.Text.Length != 0)
            {

                using (var better_limited = new WindowsFormsApp1.better_limitedEntities())
                {
                    int code3 = Convert.ToInt32(cboReceipt3.Text);
                    var emp = (from list in better_limited.reorderingitem
                               where list.ReOrderID == code3
                               //where list.ReOrderID.Equals(cboReceipt1.Text)
                               select list);    // select * from inventory_levels

                    foreach (var emp2 in emp.ToList())
                    {
                        txtReOrderID3 = emp2.ReOrderID;
                        txtItemType3 = emp2.ItemType;
                        txtItemBrand3 = emp2.ItemBrand;
                        txtSupplier3 = emp2.Supplier;
                        txtItemQuantity3 = (int)emp2.ItemQuantity;
                        txtItemPrice3 = (int)emp2.ItemPrice;
                        txtAmounts3 = (int)emp2.Amounts;
                        txtReceiveDate3 = (emp2.ReceiveDate).Value.ToString("dd MMMM yyyy");
                    }
                }

            }

            if (cboReceipt4.Text.Length != 0)
            {
                using (var better_limited = new WindowsFormsApp1.better_limitedEntities())
                {
                    int code4 = Convert.ToInt32(cboReceipt4.Text);
                    var emp = (from list in better_limited.reorderingitem
                               where list.ReOrderID == code4
                               //where list.ReOrderID.Equals(cboReceipt1.Text)
                               select list);    // select * from inventory_levels

                    foreach (var emp2 in emp.ToList())
                    {
                        txtReOrderID4 = emp2.ReOrderID;
                        txtItemType4 = emp2.ItemType;
                        txtItemBrand4 = emp2.ItemBrand;
                        txtSupplier4 = emp2.Supplier;
                        txtItemQuantity4 = (int)emp2.ItemQuantity;
                        txtItemPrice4 = (int)emp2.ItemPrice;
                        txtAmounts4 = (int)emp2.Amounts;
                        txtReceiveDate4 = (emp2.ReceiveDate).Value.ToString("dd MMMM yyyy");
                    }
                }

            }
            if (cboReceipt5.Text.Length != 0)
            {
                using (var better_limited = new WindowsFormsApp1.better_limitedEntities())
                {
                    int code5 = Convert.ToInt32(cboReceipt5.Text);
                    var emp = (from list in better_limited.reorderingitem
                               where list.ReOrderID == code5
                               //where list.ReOrderID.Equals(cboReceipt1.Text)
                               select list);    // select * from inventory_levels

                    foreach (var emp2 in emp.ToList())
                    {
                        txtReOrderID5 = emp2.ReOrderID;
                        txtItemType5 = emp2.ItemType;
                        txtItemBrand5 = emp2.ItemBrand;
                        txtSupplier5 = emp2.Supplier;
                        txtItemQuantity5 = (int)emp2.ItemQuantity;
                        txtItemPrice5 = (int)emp2.ItemPrice;
                        txtAmounts5 = (int)emp2.Amounts;
                        txtReceiveDate5 = (emp2.ReceiveDate).Value.ToString("dd MMMM yyyy");
                    }
                }

            }
        }


        private void cboReceipt1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(@"datasource=127.0.0.1;port=3306;SslMode=none;username=root;password=;database=better_limited;"))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT `ReOrderID` FROM `reorderingitem`", conn);

                MySqlDataReader dr = cmd.ExecuteReader();

                IList<string> listName = new List<string>();
                while (dr.Read())
                {
                    listName.Add(dr[0].ToString());
                }
                listName = listName.Distinct().ToList();
                cboReceipt1.DataSource = listName;
            }

            //printReceipt();

            cboReceipt2.Visible = true;

        }

        private void cboReceipt2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(@"datasource=127.0.0.1;port=3306;SslMode=none;username=root;password=;database=better_limited;"))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT `ReOrderID` FROM `reorderingitem`", conn);

                MySqlDataReader dr = cmd.ExecuteReader();

                IList<string> listName = new List<string>();
                while (dr.Read())
                {
                    listName.Add(dr[0].ToString());
                }
                listName = listName.Distinct().ToList();
                cboReceipt2.DataSource = listName;
            }
            //printReceipt();

            cboReceipt3.Visible = true;
        }

        private void cboReceipt3_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(@"datasource=127.0.0.1;port=3306;SslMode=none;username=root;password=;database=better_limited;"))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT `ReOrderID` FROM `reorderingitem`", conn);

                MySqlDataReader dr = cmd.ExecuteReader();

                IList<string> listName = new List<string>();
                while (dr.Read())
                {
                    listName.Add(dr[0].ToString());
                }
                listName = listName.Distinct().ToList();
                cboReceipt3.DataSource = listName;
            }
            //printReceipt();

            cboReceipt4.Visible = true;
        }

        private void cboReceipt4_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(@"datasource=127.0.0.1;port=3306;SslMode=none;username=root;password=;database=better_limited;"))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT `ReOrderID` FROM `reorderingitem`", conn);

                MySqlDataReader dr = cmd.ExecuteReader();

                IList<string> listName = new List<string>();
                while (dr.Read())
                {
                    listName.Add(dr[0].ToString());
                }
                listName = listName.Distinct().ToList();
                cboReceipt4.DataSource = listName;
            }
            //printReceipt();

            cboReceipt5.Visible = true;
        }

        private void cboReceipt5_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(@"datasource=127.0.0.1;port=3306;SslMode=none;username=root;password=;database=better_limited;"))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT `ReOrderID` FROM `reorderingitem`", conn);

                MySqlDataReader dr = cmd.ExecuteReader();

                IList<string> listName = new List<string>();
                while (dr.Read())
                {
                    listName.Add(dr[0].ToString());
                }
                listName = listName.Distinct().ToList();
                cboReceipt5.DataSource = listName;
            }
            //printReceipt();

        }

        // print button
        private void button2_Click(object sender, EventArgs e)
        {
            InventoryManagementSystemReceipt form = new InventoryManagementSystemReceipt(txtReOrderID1, txtItemType1, txtItemBrand1, txtSupplier1, txtItemQuantity1, txtItemPrice1, txtAmounts1, txtReceiveDate1,
                txtReOrderID2, txtItemType2, txtItemBrand2, txtSupplier2, txtItemQuantity2, txtItemPrice2, txtAmounts2, txtReceiveDate2,
                txtReOrderID3, txtItemType3, txtItemBrand3, txtSupplier3, txtItemQuantity3, txtItemPrice3, txtAmounts3, txtReceiveDate3,
                txtReOrderID4, txtItemType4, txtItemBrand4, txtSupplier4, txtItemQuantity4, txtItemPrice4, txtAmounts4, txtReceiveDate4,
                txtReOrderID5, txtItemType5, txtItemBrand5, txtSupplier5, txtItemQuantity5, txtItemPrice5, txtAmounts5, txtReceiveDate5);
            form.Show();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            int size = -1;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string text = System.IO.File.ReadAllText(file);
                    size = text.Length;
                }
                catch (IOException)
                {
                }
            }
            Console.WriteLine(size); // <-- Shows file size in debugging mode.
            Console.WriteLine(result); // <-- For debugging use.
        }

        private void cboReceipt1_TextUpdate(object sender, EventArgs e)
        {
            if (cboReceipt1.Text.Length == 0)
            {
                txtReOrderID1 = 0;
                txtItemType1 = "";
                txtItemBrand1 = "";
                txtSupplier1 = "";
                txtItemQuantity1 = 0;
                txtItemPrice1 = 0;
                txtAmounts1 = 0;
                txtReceiveDate1 = "";
            }
        }

        private void cboReceipt2_TextUpdate(object sender, EventArgs e)
        {
            if (cboReceipt2.Text.Length == 0)
            {
                txtReOrderID2 = 0;
                txtItemType2 = "";
                txtItemBrand2 = "";
                txtSupplier2 = "";
                txtItemQuantity2 = 0;
                txtItemPrice2 = 0;
                txtAmounts2 = 0;
                txtReceiveDate2 = "";
            }
        }

        private void cboReceipt3_TextUpdate(object sender, EventArgs e)
        {
            if (cboReceipt3.Text.Length == 0)
            {
                txtReOrderID3 = 0;
                txtItemType3 = "";
                txtItemBrand3 = "";
                txtSupplier3 = "";
                txtItemQuantity3 = 0;
                txtItemPrice3 = 0;
                txtAmounts3 = 0;
                txtReceiveDate3 = "";
            }
        }

        private void cboReceipt4_TextUpdate(object sender, EventArgs e)
        {
            if (cboReceipt4.Text.Length == 0)
            {
                txtReOrderID4 = 0;
                txtItemType4 = "";
                txtItemBrand4 = "";
                txtSupplier4 = "";
                txtItemQuantity4 = 0;
                txtItemPrice4 = 0;
                txtAmounts4 = 0;
                txtReceiveDate4 = "";
            }
        }

        private void cboReceipt5_TextUpdate(object sender, EventArgs e)
        {
            if (cboReceipt5.Text.Length == 0)
            {
                txtReOrderID5 = 0;
                txtItemType5 = "";
                txtItemBrand5 = "";
                txtSupplier5 = "";
                txtItemQuantity5 = 0;
                txtItemPrice5 = 0;
                txtAmounts5 = 0;
                txtReceiveDate5 = "";
            }
        }

        private void cboReceipt1_SelectedIndexChanged(object sender, EventArgs e)
        {
            printReceipt();
        }

        private void cboReceipt2_SelectedIndexChanged(object sender, EventArgs e)
        {
            printReceipt();
        }

        private void cboReceipt3_SelectedIndexChanged(object sender, EventArgs e)
        {
            printReceipt();
        }

        private void cboReceipt4_SelectedIndexChanged(object sender, EventArgs e)
        {
            printReceipt();
        }

        private void cboReceipt5_SelectedIndexChanged(object sender, EventArgs e)
        {
            printReceipt();
        }

        private void DeleteItem_Click(object sender, EventArgs e)
        {
            if (DeleteItem.Text != "")
            {
                try
                {
                    MySqlConnection conn = new MySqlConnection(@"datasource=127.0.0.1;port=3306;SslMode=none;username=root;password=;database=better_limited;");
                    string query = "delete from `reorderingitem` where `ReOrderID`= '" + txtDeleteItem.Text + "' ";


                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("The item has been deleted successfully!");
                    txtDeleteItem.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Please make sure OrderID fields are filled");
            }
        }
    }
}
