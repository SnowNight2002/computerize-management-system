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
    public partial class frmCheckDeliveryCN : Form
    {
        public frmCheckDeliveryCN(string employeeID, string position)
        {
            InitializeComponent();
            label2.Text = employeeID;
            label3.Text = position;
        }

        private void frmCheckDelivery_Load(object sender, EventArgs e)
        {
            using (var deliveryContext = new WindowsFormsApp1.better_limitedEntities())
            {
                var delivery = (from list in deliveryContext.deliveryorder
                           select list);    // select * from payments

                foreach (var delivery2 in delivery.ToList())
                {
                    dataGridView1.Rows.Add(delivery2.deliveryid, delivery2.docreatedate, delivery2.deliverystatus, delivery2.expectdeliverydate, delivery2.timeslot, delivery2.deliverycompleteDate, delivery2.EmpID, delivery2.Customerid, delivery2.InstallationNeed);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (var deliveryContext = new WindowsFormsApp1.better_limitedEntities())
            { //keyword search
                dataGridView1.Rows.Clear();
                if (txtSearch.Text != "")
                {
                    int keyword = Convert.ToInt32(txtSearch.Text);
                    var resultSet = from list in deliveryContext.deliveryorder
                                    where list.deliveryid.Equals(keyword)
                                    select list;
                    foreach (var delivery2 in resultSet.ToList())
                    {
                        dataGridView1.Rows.Add(delivery2.deliveryid, delivery2.docreatedate, delivery2.deliverystatus, delivery2.expectdeliverydate, delivery2.timeslot, delivery2.deliverycompleteDate, delivery2.EmpID, delivery2.Customerid, delivery2.InstallationNeed);
                    }
                }
                else
                {
                    var delivery = (from list in deliveryContext.deliveryorder
                                    select list);    // select * from payments

                    foreach (var delivery2 in delivery.ToList())
                    {
                        dataGridView1.Rows.Add(delivery2.deliveryid, delivery2.docreatedate, delivery2.deliverystatus, delivery2.expectdeliverydate, delivery2.timeslot, delivery2.deliverycompleteDate, delivery2.EmpID, delivery2.Customerid, delivery2.InstallationNeed);
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            using (var deliveryContext = new WindowsFormsApp1.better_limitedEntities())
            {
                string employeeID = label2.Text;
                string position = label3.Text;
                if (e.ColumnIndex == 9)
                {
                    string deliveryID = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                    frmDeliveryDetailCN detail = new frmDeliveryDetailCN(deliveryID, employeeID, position);
                    detail.Show();
                    this.Hide();
                }
                if (e.ColumnIndex == 10)
                {
                    DialogResult dialogResult = MessageBox.Show("您要删除送货记录吗？", "Information", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string deliveryID = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                        int deliveryID1 = Convert.ToInt32(deliveryID);
                        var deliveryDel = (from list in deliveryContext.deliveryorder where list.deliveryid == deliveryID1 select list).First();
                        deliveryContext.deliveryorder.Remove(deliveryDel);
                        deliveryContext.SaveChanges();
                        MessageBox.Show("已成功删除");
                        frmCheckDeliveryCN delivery = new frmCheckDeliveryCN(employeeID, position);
                        delivery.Show();
                        this.Hide();
                    }
                    return;
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            string employeeID = label2.Text;
            string position = label3.Text;
            frmOrderCN order = new frmOrderCN(employeeID, position);
            order.Show();
            this.Hide();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string employeeID = label2.Text;
            string position = label3.Text;
            frmDeliveryCN delivery = new frmDeliveryCN(employeeID, position);
            delivery.Show();
            this.Hide();
        }
    }
}
