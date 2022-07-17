using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int ABC = 0;
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            usernametxt.Clear();
            userpasswordtxt.Clear();
            usernametxt.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if ( usernametxt.Text.Length == 0 ) {
                NAMETT.Text = "...";
            }
            if (usernametxt.Text.Length >= 1)
            {
                NAMETT.Text = usernametxt.Text+" !";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ABC == 0)
            {
                if (string.IsNullOrEmpty(usernametxt.Text)
                || string.IsNullOrEmpty(userpasswordtxt.Text))
                {
                    MessageBox.Show("Please enter your username or password.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    usernametxt.Focus();
                    return;
                }
            }else if(ABC == 1)
            {
                if (string.IsNullOrEmpty(usernametxt.Text)
                || string.IsNullOrEmpty(userpasswordtxt.Text))
                {
                    MessageBox.Show("请输入您的用户名或密码。", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    usernametxt.Focus();
                    return;
                }
            }
            if (ABC == 0)
            {
                try
                {
                    MySqlConnection conn = new MySqlConnection(@"datasource=127.0.0.1;port=3306;SslMode=none;username=root;password=;database=better_limited;");
                    MySqlDataAdapter sda = new MySqlDataAdapter("select * from empolyee where account_number='" + usernametxt.Text.Trim() + "'and password='" + userpasswordtxt.Text.Trim() + "'", conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count == 1)
                    {
                        MySqlCommand cmd = new MySqlCommand("select * from empolyee where account_number='" + usernametxt.Text.Trim() + "'and password='" + userpasswordtxt.Text.Trim() + "'", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MySqlDataReader reader;
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            userdetail user = new userdetail();
                            user.setUname((string)reader["EmpName"].ToString());

                            if ((string)reader["Empdepartment"].ToString() == "Delivery Worker" || (string)reader["Empdepartment"].ToString() == "Manager" || (string)reader["Empdepartment"].ToString() == "Technical Manager" || (string)reader["Empdepartment"].ToString() == "Clerk" || (string)reader["Empdepartment"].ToString() == "Technical Support")
                            {
                                BLtd.USER user1 = new BLtd.USER();
                                user1.Name = (string)reader["EmpName"].ToString();
                                user1.Role = (string)reader["Empdepartment"].ToString();
                                user1.EmpId = (string)reader["EmpID"].ToString();
                                BLtd.FrmScheduler Delivery = new BLtd.FrmScheduler(user1);
                                this.Hide(); Delivery.ShowDialog();
                                if (Delivery.DialogResult == DialogResult.Cancel)
                                {
                                    usernametxt.Clear();
                                    userpasswordtxt.Clear();
                                    this.Show();
                                }
                            }
                            if ((string)reader["Empdepartment"].ToString() == "Sales" || (string)reader["Empdepartment"].ToString() == "Sales Manager")
                            {
                                string employeeID = (string)reader["EmpID"].ToString();
                                string position = (string)reader["Empdepartment"].ToString();
                                Better_Limited.frmOrder Sales = new Better_Limited.frmOrder(employeeID, position);
                                this.Hide();
                                Sales.Show();
                            }
                            if ((string)reader["Empdepartment"].ToString() == "Inventory")
                            {
                                StockRecordingWarehouseInventory.InventoryManagementSystem InventoryManagementSystem = new StockRecordingWarehouseInventory.InventoryManagementSystem();
                                this.Hide();
                                InventoryManagementSystem.Show();
                            }
                            if ((string)reader["Empdepartment"].ToString() == "Technical Support")
                            {
                                // no use
                            }
                            if ((string)reader["Empdepartment"].ToString() == "admin")
                            {
                                pepper.admin2 admin = new pepper.admin2();
                                this.Hide();
                                admin.Show();
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("Your username or password is incorrect.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }




                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (ABC == 1)
            {
                try
                {
                    MySqlConnection conn = new MySqlConnection(@"datasource=127.0.0.1;port=3306;SslMode=none;username=root;password=;database=better_limited;");
                    MySqlDataAdapter sda = new MySqlDataAdapter("select * from empolyee where account_number='" + usernametxt.Text.Trim() + "'and password='" + userpasswordtxt.Text.Trim() + "'", conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count == 1)
                    {
                        MySqlCommand cmd = new MySqlCommand("select * from empolyee where account_number='" + usernametxt.Text.Trim() + "'and password='" + userpasswordtxt.Text.Trim() + "'", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MySqlDataReader reader;
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            userdetail user = new userdetail();
                            user.setUname((string)reader["EmpName"].ToString());

                            if ((string)reader["Empdepartment"].ToString() == "Delivery Worker" || (string)reader["Empdepartment"].ToString() == "Manager" || (string)reader["Empdepartment"].ToString() == "Technical Manager" || (string)reader["Empdepartment"].ToString() == "Clerk" || (string)reader["Empdepartment"].ToString() == "Technical Support")
                            {
                                BLtd.USER user1 = new BLtd.USER();
                                user1.Name = (string)reader["EmpName"].ToString();
                                user1.Role = (string)reader["Empdepartment"].ToString();
                                user1.EmpId = (string)reader["EmpID"].ToString();
                                BLtd.FrmSchedulerCN Delivery = new BLtd.FrmSchedulerCN(user1);
                                this.Hide();
                                Delivery.ShowDialog(); 
                                if (Delivery.DialogResult == DialogResult.Cancel)
                                {
                                    usernametxt.Clear();
                                    userpasswordtxt.Clear();
                                    this.Show();
                                }
                            }
                            if ((string)reader["Empdepartment"].ToString() == "Sales" || (string)reader["Empdepartment"].ToString() == "Sales Manager")
                            {
                                string employeeID = (string)reader["EmpID"].ToString();
                                string position = (string)reader["Empdepartment"].ToString();
                                Better_Limited.frmOrderCN Sales = new Better_Limited.frmOrderCN(employeeID, position);
                                this.Hide();
                                Sales.Show();
                            }
                            if ((string)reader["Empdepartment"].ToString() == "Inventory")
                            {
                                StockRecordingWarehouseInventory.InventoryManagementSystemCN InventoryManagementSystem = new StockRecordingWarehouseInventory.InventoryManagementSystemCN();
                                this.Hide();
                                InventoryManagementSystem.Show();
                            }
                            if ((string)reader["Empdepartment"].ToString() == "Technical Support")
                            {
                                // no use
                            }
                            if ((string)reader["Empdepartment"].ToString() == "admin")
                            {
                                pepper.admin2CN admin = new pepper.admin2CN();
                                this.Hide();
                                admin.Show();
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("您的用户名或密码不正确。", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CPw_Click(object sender, EventArgs e)
        {
            if (ABC == 0)
            {
                new Form2().Show();
            }
            else if (ABC == 1)
            {
                new Form2CN().Show();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ABC = 0;
            CPw.Text = "Change Password";
            LOGIN.Text = "Log In";
            ClearFields.Text = "Clear Fields";
            label1.Text = "Welcome";
            label1.Location = new Point(266, 77);

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ABC = 1;
            CPw.Text = "更改密码";
            LOGIN.Text = "登录";
            ClearFields.Text = "清除字";
            label1.Text = "欢迎";
            label1.Location = new Point(373, 77);

        }

        private void eye_Click(object sender, EventArgs e)
        {
            if (userpasswordtxt.PasswordChar == '*') {
                noeye.BringToFront();
                userpasswordtxt.PasswordChar = '\0';
            }
        }

        private void noeye_Click(object sender, EventArgs e)
        {
            if (userpasswordtxt.PasswordChar == '\0')
            {
                eye.BringToFront();
                userpasswordtxt.PasswordChar = '*';
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
