using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public partial class Form2 : Form
    {


        public Form2()
        {
            InitializeComponent();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CPw_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(usernametxt.Text)
                || string.IsNullOrEmpty(passwordtxt.Text)
                || string.IsNullOrEmpty(security_answertxt.Text)
                || string.IsNullOrEmpty(newpasswordtxt.Text))
            {
                MessageBox.Show("Please enter all your information to change password", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                usernametxt.Focus();
                return;
            }
            try 
            {
                MySqlConnection conn = new MySqlConnection(@"datasource=127.0.0.1;port=3306;SslMode=none;username=root;password=;database=better_limited;");
                MySqlDataAdapter sda = new MySqlDataAdapter("select * from empolyee where account_number='" + 
                    usernametxt.Text.Trim() + "'and password='" + passwordtxt.Text.Trim() + "'and security_question_answer='"+ security_answertxt.Text.Trim() + "'", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (newpasswordtxt.Text.Trim() == newpassword2.Text.Trim())
                {
                    if (dt.Rows.Count == 1)
                    {

                        string MyConnection2 = "datasource=127.0.0.1;port=3306;SslMode=none;username=root;password=;";
                        string Query = "UPDATE better_limited.empolyee SET password='" + this.newpasswordtxt.Text.Trim() +
                            "'WHERE account_number='" + this.usernametxt.Text.Trim() +
                            "'and security_question_answer='" + this.security_answertxt.Text.Trim() + "';";
                        MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                        MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                        MySqlDataReader MyReader2;
                        MyConn2.Open();
                        MyReader2 = MyCommand2.ExecuteReader();
                        MessageBox.Show("Data Updated");
                        MyConn2.Close();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Your information is incorrect.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    MessageBox.Show("Two input newpassword must be consistent", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ClearFields_Click(object sender, EventArgs e)
        {
            usernametxt.Clear();
            passwordtxt.Clear();
            security_answertxt.Clear();
            newpasswordtxt.Clear();
            usernametxt.Focus();
        }


        private void usernametxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void newpasswordtxt_TextChanged(object sender, EventArgs e)
        {
            int score = 0;
            string input = newpasswordtxt.Text;
            if (newpasswordtxt.Text.Length == 0)
                score=0;
            if (newpasswordtxt.Text.Length >= 4)
                score=1;
            if (newpasswordtxt.Text.Length >= 8)
                score=2;
            if (Regex.Match(input, @"\d+").Success)
                score++;
            if (Regex.Match(input, @"[a-z]").Success &&
              Regex.Match(input, @"[A-Z]").Success)
                score++;
            if (Regex.Match(input, @".[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]").Success)
                score++;


            if (score == 0)
            {
                label8.Text = "Null";
            }
            else if (score == 1)
            {
                label8.Text = "VeryWeak";
            }
            else if (score == 2)
            {
                label8.Text = "Weak";
            }
            else if (score == 3)
            {
                label8.Text = "Medium";
            }
            else if (score == 4)
            {
                label8.Text = "Strong";
            }
            else if (score >= 5)
            {
                label8.Text = "VeryStrong";
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
