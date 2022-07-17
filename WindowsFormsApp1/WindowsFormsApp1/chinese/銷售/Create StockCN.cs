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
    public partial class frmCreateItemCN : Form
    {
        public frmCreateItemCN(string employeeID, string position)
        {
            InitializeComponent();
            txtEmpID.Text = employeeID;
            txtPosition.Text = position;
        }

        private void Create_StockCN_Load(object sender, EventArgs e)
        {

        }

        private void InsertRecord()
        {
            using (var stockContext = new WindowsFormsApp1.better_limitedEntities())
            {
                var stock = new WindowsFormsApp1.product();

                stock.productname = txtProName.Text;
                stock.productType = txtProType.Text;
                stock.productUnitprice = Convert.ToDouble(txtProPrice.Text);
                stock.productUnitQty = Convert.ToInt32(txtProQty.Text);
                stock.StockMaxNumber = Convert.ToInt32(txtProMax.Text);
                stock.productbrand = txtProBrand.Text;
                stock.EmpID = txtEmpID.Text;
                string weight = Convert.ToString(txtWeight.Text);//add weight
                float w = float.Parse(weight);
                stock.productweight = w;

                stockContext.products.Add(stock);

                try
                {
                    stockContext.SaveChanges();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            string employeeID = txtEmpID.Text;
            string position = txtPosition.Text;
            frmStockCN stock = new frmStockCN(employeeID, position);
            stock.Show();
            this.Hide();
        }
        private void btnFinish_Click(object sender, EventArgs e)
        {
            int check;
            double check2;
            if (txtProBrand.Text == "" || txtProName.Text == "" || txtProQty.Text == "" || txtProMax.Text == "" || txtProPrice.Text == "" || txtProType.Text == "" || txtWeight.Text == "")
            {
                MessageBox.Show("请输入新物品的所有信息");
            }
            else if (!int.TryParse(txtProQty.Text, out check) || !int.TryParse(txtProMax.Text, out check))
            {
                MessageBox.Show("物品数量和库存最大数量必须为整数");
            }
            else if (!double.TryParse(txtProPrice.Text, out check2) || !double.TryParse(txtWeight.Text, out check2))
            {
                MessageBox.Show("物品价格或物品重量必须是数字");
            }
            else
            {
                InsertRecord();
                MessageBox.Show("一个新物品创建完成");
                string employeeID = txtEmpID.Text;
                string position = txtPosition.Text;
                frmStockCN stock = new frmStockCN(employeeID, position);
                stock.Show();
                this.Hide();
            }
        }
    }
}
