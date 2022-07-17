using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Better_Limited
{
    public partial class frmDepositDetailCN : Form
    {
        public frmDepositDetailCN(string orderID, string employeeID, string position, string paymentMethod, string empID, string region, string totalAmount)
        {
            InitializeComponent();
            txtEmpID.Text = employeeID;
            txtPosition.Text = position;
            txtMethod.Text = paymentMethod;
            txtOrderEmpID.Text = empID;
            txtRegion.Text = region;
            txtAmount.Text = totalAmount;
            using (var detailContext = new WindowsFormsApp1.better_limitedEntities())
            {
                var detail = (from list in detailContext.deposit_receipt
                              where list.Order_ID == orderID
                              select list);    // select * from payment_receipts

                foreach (var detail2 in detail.ToList())
                {
                    dataGridView1.Rows.Add(detail2.Order_ID, detail2.itemsID, detail2.Items_Name, detail2.Quantity, detail2.ItemPrice, detail2.TotalPrice, detail2.Deposit_Amounts, detail2.outstanding_amounts, detail2.Created_Date, detail2.customerID);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            string employeeID = txtEmpID.Text;
            string position = txtPosition.Text;
            frmOrderCN order = new frmOrderCN(employeeID, position);
            order.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print_DepositCN deposit = new Print_DepositCN();
            double calculate = 0;
            deposit.OrderID = Convert.ToString(dataGridView1.Rows[0].Cells[0].Value);
            deposit.EmpID = txtOrderEmpID.Text;
            deposit.PaymentMethod = txtMethod.Text;
            deposit.TotalAmount = "$" + txtAmount.Text;
            deposit.StoreRegion = txtRegion.Text;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                deposit.Quantity += Convert.ToString(dataGridView1.Rows[i].Cells[3].Value) + "\n";
                deposit.Price += "$" + Convert.ToString(dataGridView1.Rows[i].Cells[4].Value) + "\n";
                deposit.ItemName += Convert.ToString(dataGridView1.Rows[i].Cells[2].Value) + "\n";
                deposit.Deposit += "$" + Convert.ToString(dataGridView1.Rows[i].Cells[6].Value) + "\n";
                calculate += Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value);
            }
            deposit.OutStanding = "$" + Convert.ToString(calculate);
            deposit.Show();
        }
    }
}
