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
    public partial class frmCreateCN : Form
    {
        public frmCreateCN(string employeeID, string position)
        {
            InitializeComponent();
            picAlipay.Visible = false;
            picAlipayHK.Visible = false;
            picCash.Visible = false;
            picMaster.Visible = false;
            picVisa.Visible = false;
            txtEID.Text = employeeID;
            txtPosition.Text = position;
        }
        private bool CheckValidOrderID(String OID)
        {
            bool result = false;
            using (var orderContext = new WindowsFormsApp1.better_limitedEntities())
            {
                var ord = from list in orderContext.payment
                           select list;    // select * from employees

                foreach (var ord2 in ord.ToList())
                {
                    if (ord2.Order_ID == OID)
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        private bool CheckValidCustomerID(int CID)
        {
            bool result = false;
            using (var orderContext = new WindowsFormsApp1.better_limitedEntities())
            {
                var cus = from list in orderContext.customer
                          select list;    // select * from employees

                foreach (var cus2 in cus.ToList())
                {
                    if (cus2.Customerid == CID)
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }
        private void InsertRecord()
        {
            using (var orderContext = new WindowsFormsApp1.better_limitedEntities())
            {
                var ord = new WindowsFormsApp1.payment();

                ord.Order_ID= txtOID.Text;
                ord.Payment1 = txtPayment.Text;
                ord.Created_Date = System.DateTime.Now;
                ord.EmpID = txtEID.Text;
                ord.Region = cmBoxRegion.Text;
                ord.TotalPrice = Convert.ToDouble(txtPrice.Text);
                ord.PaymentMethod = cmBoxMethod.Text;
                orderContext.payment.Add(ord);

                try
                {
                    orderContext.SaveChanges();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void InsertPayment()
        {
            using (var orderContext = new WindowsFormsApp1.better_limitedEntities())
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value) > 0)
                    {
                        var payment = new WindowsFormsApp1.payment_receipt();
                        payment.Order_ID = txtOID.Text;
                        payment.itemsID = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                        payment.Items_Name = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                        payment.Quantity = Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                        payment.Item_Price = Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value);
                        payment.Payment_amounts = Convert.ToDouble(txtPrice.Text);
                        payment.Created_Date = System.DateTime.Now;
                        orderContext.payment_receipt.Add(payment);
                    }
                }
                try
                {
                    orderContext.SaveChanges();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void InsertDeposit()
        {
            using (var orderContext = new WindowsFormsApp1.better_limitedEntities())
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value) > 0)
                    {
                        var deposit = new WindowsFormsApp1.deposit_receipt();
                        deposit.Order_ID = txtOID.Text;
                        deposit.itemsID = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                        deposit.Items_Name = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                        deposit.Quantity = Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                        deposit.ItemPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value);
                        deposit.TotalPrice = Convert.ToDouble(txtPrice.Text);
                        deposit.Deposit_Amounts = Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value);
                        deposit.outstanding_amounts = Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value);
                        deposit.Created_Date = System.DateTime.Now;
                        deposit.customerID = Convert.ToInt32(txtCustomer.Text);
                        orderContext.deposit_receipt.Add(deposit);
                    }
                }
                try
                {
                    orderContext.SaveChanges();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        
        private void changeStock()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                using (var productContext = new WindowsFormsApp1.better_limitedEntities())
                {
                    int productID = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                    var results = (from list in productContext.products
                                             where list.productid == productID
                                             select list).ToList();
                    foreach(var product in results)
                    {
                        if (Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value) < Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value))
                        {
                            txtStock.Text = Convert.ToString(Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value) - Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value));
                            product.productUnitQty = Convert.ToInt32(txtStock.Text);
                        }
                        else if(Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value) >= Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value))
                        {
                            txtStock.Text = "0";
                            product.productUnitQty = Convert.ToInt32(txtStock.Text);
                        }
                        try
                        {
                            productContext.SaveChanges();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }
        private void GoToAnotherForm()
        {
            if (checkDelivery.Checked == true)
            {
                string employeeID = txtEID.Text;
                string position = txtPosition.Text;
                frmDeliveryCN delivery = new frmDeliveryCN(employeeID, position);
                delivery.Show();
                this.Hide();
            }
            else
            {
                string employeeID = txtEID.Text;
                string position = txtPosition.Text;
                frmOrderCN order = new frmOrderCN(employeeID, position);
                order.Show();
                this.Hide();
            }
        }
        private void frmCreate_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'better_limitedDataSet.payment' table. You can move, or remove it, as needed.
            this.paymentTableAdapter.Fill(this.better_limitedDataSet.payment);
            using (var ItemContext = new WindowsFormsApp1.better_limitedEntities())
            {
                var item = (from list in ItemContext.products
                           select list);    // select * from product

                foreach (var item2 in item.ToList())
                {
                    dataGridView1.Rows.Add(item2.productid, item2.productname, item2.productUnitQty, item2.productUnitprice, false, "0", "0","0","0");
                }
            }
        }
         private void btnCalculate_Click(object sender, EventArgs e)
        {
            double price = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++) {
                price = price + Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value);
                txtPrice.Text = Convert.ToString(price);
            }
            lblPrice.Text = "价格 = $" + price;
        }
        private void btnFinish_Click(object sender, EventArgs e)
        {
            double price = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                price = price + Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value);
                txtPrice.Text = Convert.ToString(price);
            }
            lblPrice.Text = "价格 = $" + price;

            if (txtPrice.Text == "" || txtPrice.Text == "0")
            {
                MessageBox.Show("请选择一个产品");
            }
            else
            {
                if (!CheckValidOrderID(txtOID.Text) && (txtPayment.Text == "Payment Receipt" || txtPayment.Text == "Deposit Receipt"))
                {
                    if (cmBoxMethod.Text == "")
                    {
                        MessageBox.Show("请选择一个支付方式");
                    }
                    else if (cmBoxRegion.Text == "")
                    {
                        MessageBox.Show("请选择你所在的商店地区");
                    }
                    else if (txtOID.Text == "")
                    {
                        MessageBox.Show("请输入一个新订单号");
                    }
                    else
                    {
                        if (txtPayment.Text == "Payment Receipt")
                        {
                            InsertRecord();
                            InsertPayment();
                            changeStock();
                            MessageBox.Show("订单编号 " + txtOID.Text + " 已经成功记录.");
                            GoToAnotherForm();
                        }
                        if (txtPayment.Text == "Deposit Receipt")
                        {
                            int check;
                            if (!int.TryParse(txtCustomer.Text, out check))
                            {
                                MessageBox.Show("客户ID必须是整数");
                            }
                            else if (txtCustomer.Text == "" || !CheckValidCustomerID(Convert.ToInt32(txtCustomer.Text)))
                            {
                                MessageBox.Show("请输入正确的客户ID");
                            }
                            else
                            {
                                InsertRecord();
                                InsertDeposit();
                                changeStock();
                                MessageBox.Show("订单编号 " + txtOID.Text + " 已经成功记录。");
                                GoToAnotherForm();
                            }
                        }
                    }
                }
                else if (!CheckValidOrderID(txtOID.Text) && txtPayment.Text == "")
                {
                    MessageBox.Show("你需要选择一个订单种类.");
                }
                else
                    MessageBox.Show("订单编号 " + txtOID.Text + " 已存在.");
            }
        }

        private void cmBoxMethod_SelectedIndexChanged(object sender, EventArgs e)
        {   
            if (cmBoxMethod.Text == "Alipay")
            {
                picAlipay.Visible = true;
                picAlipayHK.Visible = false;
                picCash.Visible = false;
                picMaster.Visible = false;
                picVisa.Visible = false;
            }
            else if (cmBoxMethod.Text == "VISA")
            {
                picAlipay.Visible = false;
                picAlipayHK.Visible = false;
                picCash.Visible = false;
                picMaster.Visible = false;
                picVisa.Visible = true;
            }
            else if (cmBoxMethod.Text == "Master")
            {
                picAlipay.Visible = false;
                picAlipayHK.Visible = false;
                picCash.Visible = false;
                picMaster.Visible = true;
                picVisa.Visible = false;
            }
            else if (cmBoxMethod.Text == "AlipayHK")
            {
                picAlipay.Visible = false;
                picAlipayHK.Visible = true;
                picCash.Visible = false;
                picMaster.Visible = false;
                picVisa.Visible = false;
            }
            else
            {
                picAlipay.Visible = false;
                picAlipayHK.Visible = false;
                picCash.Visible = true;
                picMaster.Visible = false;
                picVisa.Visible = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            double checkPayment = 0;
          
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[4].Value) == true)
                {
                    dataGridView1.Rows[i].Cells[6].Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value) * Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                    checkPayment = checkPayment + Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value);
                }
                else
                {
                    dataGridView1.Rows[i].Cells[6].Value = 0;
                }

                if (Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value) > Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value) && Convert.ToBoolean(dataGridView1.Rows[i].Cells[4].Value) == true)
                {
                    if ((Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value) - Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value)) * Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value) >= 5000)
                    {
                        dataGridView1.Rows[i].Cells[7].Value = Convert.ToDouble((Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value) - Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value)) * (Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value) * 0.2) + (Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value) * Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value)));
                        dataGridView1.Rows[i].Cells[8].Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value) - Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value);
                    }
                    if ((Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value) - Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value)) * Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value) < 5000)
                    {
                        dataGridView1.Rows[i].Cells[7].Value = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value) * Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                        dataGridView1.Rows[i].Cells[8].Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value) - Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value);
                    }
                }
                else if (Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value) <= Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value) && Convert.ToBoolean(dataGridView1.Rows[i].Cells[4].Value) == true)
                {
                    dataGridView1.Rows[i].Cells[7].Value = dataGridView1.Rows[i].Cells[6].Value;
                    dataGridView1.Rows[i].Cells[8].Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value) - Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value);
                }
                else
                {
                    dataGridView1.Rows[i].Cells[7].Value = 0;
                    dataGridView1.Rows[i].Cells[8].Value = 0;
                }
            }
            if (checkPayment > 0)
            {
                txtPayment.Text = "Deposit Receipt";
            }
            else
            {
                txtPayment.Text = "Payment Receipt";
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            string employeeID = txtEID.Text;
            string position = txtPosition.Text;
            frmOrderCN order = new frmOrderCN(employeeID, position);
            order.Show();
            this.Hide();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            frmCustomerCN customer = new frmCustomerCN();
            customer.Show();
        }
        private void txtPayment_TextChanged(object sender, EventArgs e)
        {
            if (txtPayment.Text == "Deposit Receipt")
            {
                lblCustomer.Visible = true;
                txtCustomer.Visible = true;
                btnCustomer.Visible = true;
            }

            if (txtPayment.Text == "Payment Receipt")
            {
                lblCustomer.Visible = false;
                txtCustomer.Visible = false;
                btnCustomer.Visible = false;
            }
        }

        public DataGridViewTextBoxEditingControl CellEdit = null;
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.dataGridView1.CurrentCellAddress.X == 5)
            {
                CellEdit = (DataGridViewTextBoxEditingControl)e.Control;
                CellEdit.SelectAll();
                CellEdit.KeyPress += Cells_KeyPress;
            }
        }
        private void Cells_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((this.dataGridView1.CurrentCellAddress.X == 5))
            {
                if (!(e.KeyChar >= '0' && e.KeyChar <= '9')) e.Handled = true;
                if (e.KeyChar == '\b') e.Handled = false;
            }
        }
    }
}
