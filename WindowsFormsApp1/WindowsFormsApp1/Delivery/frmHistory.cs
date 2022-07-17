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
    public partial class frmHistory : Form
    {
        //private String CURRENT_USER = "Manager";

        // USER OBJECT 
        private USER CURRENT_USER;

        private MySqlConnection conn;
        private string mySQLStatement;
        private DataTable dt;


        public frmHistory(USER user)
        {
            InitializeComponent();

            // USER OBJECT 
            CURRENT_USER = user;
            lblUserName.Text = CURRENT_USER.Name;

            ckbStatus.BackColor = System.Drawing.Color.Transparent;
            ckbDate.BackColor = System.Drawing.Color.Transparent;

        }

        private void frmHistory_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection();
            conn.ConnectionString = "Datasource=127.0.0.1;username=root;password=;database=better_limited";

            //Select deliveryid, docreatedate,expectdeliverydate,deliverystatus, Customerid, InstallationNeed from deliveryorder order by deliveryid asc
            GetOrderDetail();
            CountDgvRows();
        }

        private void GetOrderDetail()
        {
            conn.Open();

            try
            {

                mySQLStatement =
                    "Select deliveryid, docreatedate,expectdeliverydate,deliverystatus, " +
                    "deliverycompleteDate, Customerid, InstallationNeed from deliveryorder order by deliveryid asc";
                MySqlDataAdapter da = new MySqlDataAdapter(mySQLStatement, conn);
                dt = new DataTable();
                da.Fill(dt);
                dgvHistory.DataSource = dt;
                conn.Close();
                da.Dispose();

                dgvHistory.Columns["deliveryid"].HeaderText = "Delivery ID";
                dgvHistory.Columns["docreatedate"].HeaderText = "Creation Date";
                dgvHistory.Columns["expectdeliverydate"].HeaderText = "Delivery Date ";
                dgvHistory.Columns["deliverystatus"].HeaderText = "Status";
                dgvHistory.Columns["deliverycompleteDate"].HeaderText = "Completed Date";
                dgvHistory.Columns["Customerid"].HeaderText = "Customer ID";
                dgvHistory.Columns["InstallationNeed"].HeaderText = "Installation Request";

                foreach (DataGridViewColumn dgwCol in dgvHistory.Columns)
                {
                    dgwCol.HeaderCell.Style.Font = new Font("sans serif", 12.5F, GraphicsUnit.Pixel);
                    dgwCol.DefaultCellStyle.Font = new Font("sans serif", 13.5F, GraphicsUnit.Pixel);

                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Fail to Retrieve data from Database");
            }

        }

        private void dgvHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //PASS TO USER TO OTHER FORM
            DialogResult dr = new frmOrderDetail(dgvHistory.CurrentRow.Cells[0].Value.ToString(), null, CURRENT_USER, "Delivery Worker").ShowDialog();

            //Get the last MySQLstatement to update the datatable
            if (dr == DialogResult.OK || dr == DialogResult.Cancel)
            {
                ExecuteLastMySQLstatement();
            }
        }

        // Method to get mutiple combination of mySQL Statement base on Checkbox selection
        private void GetSearchResult()
        {
            try
            {
                mySQLStatement =
                    "Select deliveryid, docreatedate,expectdeliverydate,deliverystatus,deliverycompleteDate," +
                    "Customerid, InstallationNeed From deliveryorder";

                bool haveWhere = false;
                if (!string.IsNullOrEmpty(txtSearchId.Text))
                {
                    haveWhere = true;
                    mySQLStatement += " Where  deliveryid LIKE '%" + txtSearchId.Text + "%'";
                }

                if (ckbStatus.Checked && cboStatus.SelectedIndex > -1)
                {
                    if (haveWhere)
                    {
                        mySQLStatement += " and ";
                    }
                    else
                    {
                        mySQLStatement += " where ";
                        haveWhere = true;
                    }
                    mySQLStatement += " deliverystatus = '" + cboStatus.SelectedItem.ToString() + "' ";
                }

                if (ckbDate.Checked)
                {
                    if (haveWhere)
                    {
                        mySQLStatement += " and ";
                        if (dtpFrom.Value > dtpEnd.Value)
                        {
                            mySQLStatement += " expectdeliverydate = '" + dtpFrom.Value.ToString("yyyy-MM-dd") + "'";
                        }
                        else
                        {
                            mySQLStatement += " expectdeliverydate between '" + dtpFrom.Value.ToString("yyyy-MM-dd") + "' " +
                                "and '" + dtpEnd.Value.ToString("yyyy-MM-dd") + "'";
                        }
                    }
                    else
                    {
                        mySQLStatement += " WHERE ";
                        if (dtpFrom.Value > dtpEnd.Value)
                        {
                            mySQLStatement += " expectdeliverydate = '" + dtpFrom.Value.ToString("yyyy-MM-dd") + "'";
                        }
                        else
                        {
                            mySQLStatement += " expectdeliverydate between '" + dtpFrom.Value.ToString("yyyy-MM-dd") + "' " +
                                "and '" + dtpEnd.Value.ToString("yyyy-MM-dd") + "'";
                        }
                    }
                }

                mySQLStatement += " Order by deliveryid ASC";
                MySqlDataAdapter da = new MySqlDataAdapter(mySQLStatement, conn);
                dt = new DataTable();
                da.Fill(dt);
                dgvHistory.DataSource = dt;
                conn.Close();
                da.Dispose();

                dgvHistory.Columns["deliveryid"].HeaderText = "Delivery ID";
                dgvHistory.Columns["docreatedate"].HeaderText = "Creation Date";
                dgvHistory.Columns["expectdeliverydate"].HeaderText = "Delivery Date ";
                dgvHistory.Columns["deliverystatus"].HeaderText = "Status";
                dgvHistory.Columns["deliverycompleteDate"].HeaderText = "Completed Date";
                dgvHistory.Columns["Customerid"].HeaderText = "Customer ID";
                dgvHistory.Columns["InstallationNeed"].HeaderText = "Installation Request";
                this.dgvHistory.Invalidate();

                foreach (DataGridViewColumn dgwCol in dgvHistory.Columns)
                {
                    dgwCol.HeaderCell.Style.Font = new Font("sans serif", 12.5F, GraphicsUnit.Pixel);
                    dgwCol.DefaultCellStyle.Font = new Font("sans serif", 13.5F, GraphicsUnit.Pixel);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            CountDgvRows();
        }


        private void brnSearch_Click(object sender, EventArgs e)
        {
            GetSearchResult();
        }

        //Execute the statement inorder to refresh the datatable
        private void ExecuteLastMySQLstatement()
        {
            try
            {
                conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(mySQLStatement, conn);
                dt = new DataTable();
                da.Fill(dt);
                dgvHistory.DataSource = dt;
                conn.Close();
                da.Dispose();

                dgvHistory.Columns["deliveryid"].HeaderText = "Delivery ID";
                dgvHistory.Columns["docreatedate"].HeaderText = "Creation Date";
                dgvHistory.Columns["expectdeliverydate"].HeaderText = "Delivery Date ";
                dgvHistory.Columns["deliverystatus"].HeaderText = "Status";
                dgvHistory.Columns["deliverycompleteDate"].HeaderText = "Completed Date";
                dgvHistory.Columns["Customerid"].HeaderText = "Customer ID";
                dgvHistory.Columns["InstallationNeed"].HeaderText = "Installation Request";

                foreach (DataGridViewColumn dgwCol in dgvHistory.Columns)
                {
                    dgwCol.HeaderCell.Style.Font = new Font("sans serif", 12.5F, GraphicsUnit.Pixel);
                    dgwCol.DefaultCellStyle.Font = new Font("sans serif", 13.5F, GraphicsUnit.Pixel);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Count data grid view rows number
        private void CountDgvRows()
        {
            lblNoFound.Text = dgvHistory.Rows.Count.ToString() + " Record Found";
        }
    }
}
