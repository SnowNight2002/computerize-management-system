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
    public partial class frmDeliveryDetailCN : Form
    {
        public frmDeliveryDetailCN(string deliveryID, string employeeID, string position)
        {
            InitializeComponent();
            txtEmpID.Text = employeeID;
            txtPosition.Text = position;
            using (var detailContext = new WindowsFormsApp1.better_limitedEntities())
            {
                int deliveryID1= Convert.ToInt32(deliveryID);
                var detail = (from list in detailContext.deliveryorderproduct
                              where list.deliveryid == deliveryID1
                              select list);    // select * from payment_receipts

                foreach (var detail2 in detail.ToList())
                {
                    dataGridView1.Rows.Add(detail2.dopid, detail2.buyqty, detail2.deliveryid, detail2.productid, detail2.amount);
                }
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            string employeeID = txtEmpID.Text;
            string position = txtPosition.Text;
            frmCheckDeliveryCN delivery = new frmCheckDeliveryCN(employeeID, position);
            delivery.Show();
            this.Hide();
        }
    }
}
