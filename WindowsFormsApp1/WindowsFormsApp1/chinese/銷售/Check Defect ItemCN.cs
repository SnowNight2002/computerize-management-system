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
    public partial class frmCheckDefectCN : Form
    {
        public frmCheckDefectCN(string employeeID, string position)
        {
            InitializeComponent();
            txtEmpID.Text = employeeID;
            txtPosition.Text = position;
        }
        private void frmCheckDefectCN_Load(object sender, EventArgs e)
        {
            using (var defectContext = new WindowsFormsApp1.better_limitedEntities())
            {
                var defect = (from list in defectContext.defect_items
                              select list);    // select * from defect item

                foreach (var defect2 in defect.ToList())
                {
                    dataGridView1.Rows.Add(defect2.defectID, defect2.itemName, defect2.itemQuantity, defect2.returnPrice, defect2.employeeID);
                }
            }
        }
        private void btnPrint_Click_1(object sender, EventArgs e)
        {
            frmPrintReturnCN print = new frmPrintReturnCN();
            double amount = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[6].Value) == true)
                {
                    print.EmpID = Convert.ToString(dataGridView1.Rows[i].Cells[4].Value);
                    print.DefectID += Convert.ToString(dataGridView1.Rows[i].Cells[0].Value) + ", ";
                    print.ItemName += Convert.ToString(dataGridView1.Rows[i].Cells[1].Value) + "\n";
                    print.Price += "$" + Convert.ToString(dataGridView1.Rows[i].Cells[3].Value) + "\n";
                    print.Quantity += Convert.ToString(dataGridView1.Rows[i].Cells[2].Value) + "\n";
                    amount += Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                }
            }
            print.TotalAmount = "$" + Convert.ToString(amount);
            print.Show();
        }

        private void btnCreate_Click_1(object sender, EventArgs e)
        {
            string employeeID = txtEmpID.Text;
            string position = txtPosition.Text;
            frmCreateDefectCN createDefect = new frmCreateDefectCN(employeeID, position);
            createDefect.Show();
            this.Hide();
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            string employeeID = txtEmpID.Text;
            string position = txtPosition.Text;
            frmOrderCN checkOrder = new frmOrderCN(employeeID, position);
            checkOrder.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            using (var defectItemContext = new WindowsFormsApp1.better_limitedEntities())
            {
                string employeeID = txtEmpID.Text;
                string position = txtPosition.Text;

                if (e.ColumnIndex == 5)
                {
                    DialogResult dialogResult = MessageBox.Show("你想要删除这件缺陷物品记录吗?", "Information", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string defectItemID = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                        int defectItemID1 = Convert.ToInt32(defectItemID);
                        var defectItemDel = (from list in defectItemContext.defect_items where list.defectID == defectItemID1 select list).First();
                        defectItemContext.defect_items.Remove(defectItemDel);
                        defectItemContext.SaveChanges();
                        MessageBox.Show("已成功删除");
                        frmCheckDefect delivery = new frmCheckDefect(employeeID, position);
                        delivery.Show();
                        this.Hide();
                    }
                    return;
                }
            }
        }
    }
}
