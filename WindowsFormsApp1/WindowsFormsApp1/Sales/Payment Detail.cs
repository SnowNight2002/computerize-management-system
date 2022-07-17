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
    public partial class frmPayDetail : Form
    {
        public frmPayDetail(string orderID, string employeeID, string position, string paymentMethod, string empID, string region, string totalAmount)
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
                var detail = (from list in detailContext.payment_receipt
                              where list.Order_ID == orderID
                              select list) ;    // select * from payment_receipts

                foreach (var detail2 in detail.ToList())
                {
                    dataGridView1.Rows.Add(detail2.Order_ID, detail2.itemsID, detail2.Items_Name, detail2.Quantity, detail2.Item_Price, detail2.Payment_amounts, detail2.Created_Date);
                }
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            string employeeID = txtEmpID.Text;
            string position = txtPosition.Text;
            frmOrder order = new frmOrder(employeeID,position);
            order.Show();
            this.Hide();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmPrint print = new frmPrint();
            print.OrderID = Convert.ToString(dataGridView1.Rows[0].Cells[0].Value);
            print.EmpID = txtOrderEmpID.Text;
            print.PaymentMethod = txtMethod.Text;
            print.TotalAmount = "$"+txtAmount.Text;
            print.StoreRegion = txtRegion.Text;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                print.Quantity += Convert.ToString(dataGridView1.Rows[i].Cells[3].Value) + "\n";
                print.Price += "$" + Convert.ToString(dataGridView1.Rows[i].Cells[4].Value) + "\n";
                print.ItemName += Convert.ToString(dataGridView1.Rows[i].Cells[2].Value) + "\n";
            }
            print.Show();
        }
    }
}
