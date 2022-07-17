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
    public partial class users_listCN : Form
    {
        public users_listCN()
        {
            InitializeComponent();
        }
        void Filluserlist()
        {
            MySqlConnection conn = new MySqlConnection(@"datasource=127.0.0.1;port=3306;SslMode=none;username=root;password=;database=better_limited;");
            MySqlDataAdapter list = new MySqlDataAdapter("select * from empolyee ", conn);
            DataTable dtlist = new DataTable();
            list.Fill(dtlist);
            User_list_View.DataSource = dtlist;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void users_list_Load(object sender, EventArgs e)
        {
            Filluserlist();
        }
    }
}
