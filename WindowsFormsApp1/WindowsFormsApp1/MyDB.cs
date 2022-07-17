using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;


namespace BLtd
{
    internal class MyDB
    {
        private MySqlConnection con;
        private MySqlCommand cmd;
        private MySqlDataAdapter da;
        private string dtsource;
        private string username;
        private string password;
        private string database;

        public MyDB()
        {
            con = new MySqlConnection();
            dtsource = "127.0.0.1";
            username = "root";
            password = null;
            database = "better_limited";
            SetMySqlConString(dtsource, username, password, database);
        }   

        //Set the information to connection the database
        //It will using the default setting if user skip this method
        public void SetMySqlConString(string datasource, string username, string password, string database)
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            dtsource = datasource;
            this.username = username;
            this.password = password;
            this.database = database;

            if (password == null)
            {
                con.ConnectionString = "Datasource=" + dtsource + ";username=" + username + "; database=" + database + "";
            }
            else
            {
                con.ConnectionString = "Datasource=" + dtsource + ";username=" + username + ";password=" + password + "database=" + database + "";
            }
        }

        private MySqlConnection GetConnection { get { return con; } }

        public void OpenConnection()
        {
            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
            }
            catch (MySqlException)
            {
                System.Windows.Forms.MessageBox.Show("Fail to Connect to MySQL");
            }
            
        }
        public void CloseConnection()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }

        //return a row base on the given mysql statement
        private MySqlCommand GetMySqlCmd(String sqlstr)
        {
            if (con.State == System.Data.ConnectionState.Open)
            {               
                return cmd = new MySqlCommand(sqlstr, con);
            }
            else
            {
                return null;
            }
        }

        //Convert to datatable and dispose mysqlcmd and adapter
        public DataTable MySQLStatementToDatatable(String sqlstr)
        {
            DataTable dt = new DataTable(); ;
            if (con.State == System.Data.ConnectionState.Closed)
            {
                this.OpenConnection();
            }
            da = new MySqlDataAdapter(GetMySqlCmd(sqlstr));
            da.Fill(dt); da.Dispose();
            this.CloseConnection(); this.DisposeMySqlCmd();
            return dt;
        }

        public bool InsertToMySQL(String sqlstr)
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                cmd = new MySqlCommand(sqlstr, con);

                if(cmd.ExecuteNonQuery() == 1)
                {
                    cmd.Dispose();
                    con.Close();
                    return true;
                }
                else
                {
                    cmd.Dispose();
                    con.Close();
                    return false;
                }
            }
            else
            {
                con.Open();
                cmd = new MySqlCommand(sqlstr, con);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    cmd.Dispose();
                    con.Close();
                    return true;
                }
                else
                {
                    cmd.Dispose();
                    con.Close();
                    return false;
                }
            }
        }

        public void DisposeMySqlCmd()
        {
            if (cmd != null)
            {
                cmd.Dispose();
            }
        }

        public string GetConState()
        {
            return con.State.ToString();
        }
    }
}
