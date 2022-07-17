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
using System.Text.RegularExpressions;

namespace WindowsFormsApp1.pepper
{
    public partial class admin2CN : Form
    {
        public admin2CN()
        {
            InitializeComponent();
        }



        void checkIsNullOrEmpty()
        {
            if (string.IsNullOrEmpty(txtEmpID.Text)
               || string.IsNullOrEmpty(txtEmpName.Text)
               || string.IsNullOrEmpty(txtEmpdep.Text)
               || string.IsNullOrEmpty(txtusername.Text)
               || string.IsNullOrEmpty(txtpw.Text)
               || string.IsNullOrEmpty(txtsans.Text))
            {
                MessageBox.Show("Please enter all information.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmpID.Focus();
                return;
            }
        }




        private void button5_Click(object sender, EventArgs e)
        {
            users_listCN users_list = new users_listCN();
            users_list.Show();
        }

        private void update_Click(object sender, EventArgs e)
        {
            checkIsNullOrEmpty();
            try
            {
                MySqlConnection conn = new MySqlConnection(@"datasource=127.0.0.1;port=3306;SslMode=none;username=root;password=;database=better_limited;");
                MySqlDataAdapter sda = new MySqlDataAdapter("select * from empolyee where EmpID='" + txtEmpID.Text + "'and account_number='" + txtusername.Text.Trim() + "'", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    string MyConnection2 = "datasource=127.0.0.1;port=3306;SslMode=none;username=root;password=;";
                    string Query = "UPDATE better_limited.empolyee SET password='" + this.txtpw.Text.Trim() +
                        "', EmpName='" + this.txtEmpName.Text.Trim() +
                        "', Empdepartment='" + this.txtEmpdep.Text +
                        "', security_question_answer='" + this.txtsans.Text.Trim() +
                        "', account_number='" + this.txtusername.Text.Trim() +
                        "'WHERE EmpID='" + this.txtEmpID.Text.Trim() + "';";
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();
                    MessageBox.Show("Data Updated");
                    MyConn2.Close();

                }
                else
                {
                    MessageBox.Show("員工ID不正确。", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Create_Click(object sender, EventArgs e)
        {
            try
            {

                string str = txtEmpID.Text;
                if (str.Length == 0)
                {
                    MessageBox.Show("員工ID是空的", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (str.Length <= 3)
                {
                    MessageBox.Show("員工ID 长度需要大于 4.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (Regex.Match(str, @"!^[A-Z].*").Success)
                {
                    Console.WriteLine(char.ToUpper(str[0]) + str.Substring(1));
                }
                txtEmpID.Text = str;

                if (txtEmpID.Text != "" && txtEmpName.Text != "" && txtEmpdep.Text != "" && txtusername.Text != "" && txtpw.Text != "" && txtsans.Text != "")
                {

                    try
                    {
                        //String status = "manager";
                        MySqlConnection conn = new MySqlConnection(@"datasource=127.0.0.1;port=3306;SslMode=none;username=root;password=;database=better_limited;");
                        string query = "insert into `empolyee`(`EmpID`,`EmpName`,`Empdepartment`,`account_number`,`password`,`security_question_answer`) values('" + txtEmpID.Text.Trim() + "','" + txtEmpName.Text.Trim() + "','" + txtEmpdep.Text.Trim() + "','" + txtusername.Text.Trim() + "','" + txtpw.Text.Trim() + "','" + txtsans.Text.Trim() + "');";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("新员工账号创建成功！");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }



                }
                else
                    MessageBox.Show("请输入所有内容");
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (txtEmpID.Text != "" && txtEmpName.Text != "" && txtEmpdep.Text != "" && txtusername.Text != "" && txtpw.Text != "" && txtsans.Text != "")
            {


                MySqlConnection conn = new MySqlConnection(@"datasource=127.0.0.1;port=3306;SslMode=none;username=root;password=;database=better_limited;");
                MySqlDataAdapter sda = new MySqlDataAdapter("select * from empolyee where EmpID='" + txtEmpID.Text + "'and account_number='" + txtusername.Text.Trim() + "'", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    try
                    {
                        MySqlConnection con = new MySqlConnection(@"datasource=127.0.0.1;port=3306;SslMode=none;username=root;password=;database=better_limited;");
                        string DELETE = "DELETE FROM `empolyee` WHERE EmpID ='" + txtEmpID.Text.Trim() + "' and EmpName='" + txtEmpName.Text.Trim() + "' and Empdepartment='" + txtEmpdep.Text.Trim() + "' and account_number='" + txtusername.Text.Trim() + "' and password='" + txtpw.Text.Trim() + "' and security_question_answer='" + txtsans.Text.Trim() + "';";
                        MySqlCommand cmd = new MySqlCommand(DELETE, con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("删除帐号已成功！");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
                else
                { MessageBox.Show("404 未找到"); }


            }
            else
                MessageBox.Show("请输入所有内容");
        }

        private void Close_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtpw_TextChanged(object sender, EventArgs e)
        {

        }
    }

}

