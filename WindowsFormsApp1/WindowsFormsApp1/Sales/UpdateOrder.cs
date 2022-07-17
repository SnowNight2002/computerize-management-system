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
    public partial class frmUpdate : Form
    {
        public frmUpdate(string orderID, string employeeID, string position)
        {
            InitializeComponent();
            picAlipay.Visible = false;
            picAlipayHK.Visible = false;
            picCash.Visible = false;
            picMaster.Visible = false;
            picVisa.Visible = false;

            textBox1.Text = orderID;
            txtEmpID.Text = employeeID;
            txtPosition.Text = position;

                using (var orderContext = new WindowsFormsApp1.better_limitedEntities())
                {
                    var update = (from list in orderContext.payment where list.Order_ID == orderID select list);
                    foreach (var update2 in update.ToList())
                    {
                        dataGridView1.Rows.Add(update2.Order_ID, update2.Payment1, update2.Created_Date, update2.EmpID, update2.PaymentMethod, update2.Region, update2.TotalPrice);
                    }// select * from payment

                    txtOID.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
                    txtPayment.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                    txtEID.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
                    cmBoxMethod.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
                    cmBoxRegion.Text = dataGridView1.Rows[0].Cells[5].Value.ToString();
                    txtPrice.Text = dataGridView1.Rows[0].Cells[6].Value.ToString();
                    lblPrice.Text = "Price = $" + txtPrice.Text;
                    txtOID.ReadOnly = true;

                    if (Convert.ToString(dataGridView1.Rows[0].Cells[1].Value) == "Payment Receipt")
                    {
                        var item = (from list in orderContext.payment_receipt
                                    where list.Order_ID == orderID
                                    select list);    // select * from payment_receipt
                        foreach (var item2 in item.ToList())
                        {
                            dataGridView2.Rows.Add(item2.itemsID, item2.Items_Name, item2.Quantity, item2.Item_Price, item2.Payment_amounts,"0","0","0");
                        }
                    }

                    if(Convert.ToString(dataGridView1.Rows[0].Cells[1].Value) == "Deposit Receipt")
                    {
                        var item = (from list in orderContext.deposit_receipt
                                    where list.Order_ID == orderID
                                    select list);    // select * from deposit_receipt
                        foreach (var item2 in item.ToList())
                        {
                            dataGridView2.Rows.Add(item2.itemsID, item2.Items_Name, item2.Quantity, item2.ItemPrice, item2.TotalPrice, item2.Deposit_Amounts, item2.outstanding_amounts, item2.customerID);
                        }
                        txtCustomer.Text = Convert.ToString(dataGridView2.Rows[0].Cells[7].Value);
                    }

                    var product = from list in orderContext.products select list;// select * from product
                    foreach (var product2 in product.ToList())
                    {
                        dataGridView3.Rows.Add(product2.productid, product2.productname, product2.productUnitQty, product2.productUnitprice, false, "0" , "0", "0", "0");
                    }

                    for(int i=0; i < dataGridView2.Rows.Count; i++)
                    {
                        for(int j = 0; j<dataGridView3.RowCount; j++)
                        if(dataGridView3.Rows[j].Cells[0].Value.ToString() == dataGridView2.Rows[i].Cells[0].Value.ToString())
                        {
                            dataGridView3.Rows[j].Cells[4].Value = true;
                            dataGridView3.Rows[j].Cells[5].Value = dataGridView2.Rows[i].Cells[2].Value;
                            dataGridView3.Rows[j].Cells[6].Value = dataGridView2.Rows[i].Cells[4].Value;
                            dataGridView3.Rows[j].Cells[7].Value = dataGridView2.Rows[i].Cells[5].Value;
                            dataGridView3.Rows[j].Cells[8].Value = dataGridView2.Rows[i].Cells[6].Value;
                        }
                    }
                
            }
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
        private void UpdateRecord()
        {
            using (var orderContext = new WindowsFormsApp1.better_limitedEntities())
            {
                List<WindowsFormsApp1.payment> results = (from ord in orderContext.payment
                                         where ord.Order_ID == textBox1.Text
                                         select ord).ToList();
                foreach (WindowsFormsApp1.payment ord in results)
                {
                    ord.Order_ID = txtOID.Text;
                    ord.Payment1 = txtPayment.Text;
                    ord.Created_Date = System.DateTime.Now;
                    ord.EmpID = txtEID.Text;

                    ord.TotalPrice = Convert.ToDouble(txtPrice.Text);
                    ord.PaymentMethod = cmBoxMethod.Text;
                }
                if (Convert.ToString(dataGridView1.Rows[0].Cells[1].Value) == txtPayment.Text && txtPayment.Text=="Payment Receipt")
                {
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        string orderID = Convert.ToString(dataGridView1.Rows[0].Cells[0].Value);
                        var itemDel = (from list in orderContext.payment_receipt where list.Order_ID == orderID select list).First();
                        orderContext.payment_receipt.Remove(itemDel);
                        orderContext.SaveChanges();
                    }

                    for (int i = 0; i < dataGridView3.Rows.Count; i++)
                    {
                        if (Convert.ToDouble(dataGridView3.Rows[i].Cells[6].Value) > 0)
                        {
                            var item = new WindowsFormsApp1.payment_receipt();
                            item.Order_ID = txtOID.Text;
                            item.itemsID = Convert.ToInt32(dataGridView3.Rows[i].Cells[0].Value);
                            item.Items_Name = Convert.ToString(dataGridView3.Rows[i].Cells[1].Value);
                            item.Quantity = Convert.ToInt32(dataGridView3.Rows[i].Cells[5].Value);
                            item.Item_Price = Convert.ToDouble(dataGridView3.Rows[i].Cells[6].Value);
                            item.Payment_amounts = Convert.ToDouble(txtPrice.Text);
                            item.Created_Date = System.DateTime.Now;
                            orderContext.payment_receipt.Add(item);
                            orderContext.SaveChanges();
                        }
                    }
                }

                if (Convert.ToString(dataGridView1.Rows[0].Cells[1].Value) == txtPayment.Text && txtPayment.Text == "Deposit Receipt")
                {
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        string orderID = Convert.ToString(dataGridView1.Rows[0].Cells[0].Value);
                        var itemDel = (from list in orderContext.deposit_receipt where list.Order_ID == orderID select list).First();
                        orderContext.deposit_receipt.Remove(itemDel);
                        orderContext.SaveChanges();
                    }

                    for (int i = 0; i < dataGridView3.Rows.Count; i++)
                    {
                        if (Convert.ToDouble(dataGridView3.Rows[i].Cells[6].Value) > 0)
                        {
                            var item = new WindowsFormsApp1.deposit_receipt();
                            item.Order_ID = txtOID.Text;
                            item.itemsID = Convert.ToInt32(dataGridView3.Rows[i].Cells[0].Value);
                            item.Items_Name = Convert.ToString(dataGridView3.Rows[i].Cells[1].Value);
                            item.Quantity = Convert.ToInt32(dataGridView3.Rows[i].Cells[5].Value);
                            item.ItemPrice = Convert.ToDouble(dataGridView3.Rows[i].Cells[6].Value);
                            item.TotalPrice = Convert.ToDouble(txtPrice.Text);
                            item.Deposit_Amounts = Convert.ToDouble(dataGridView3.Rows[i].Cells[7].Value);
                            item.outstanding_amounts = Convert.ToDouble(dataGridView3.Rows[i].Cells[8].Value);
                            item.Created_Date = System.DateTime.Now;
                            item.customerID = Convert.ToInt32(txtCustomer.Text);
                            orderContext.deposit_receipt.Add(item);
                            orderContext.SaveChanges();
                        }
                    }
                }

                if(Convert.ToString(dataGridView1.Rows[0].Cells[1].Value) != txtPayment.Text && txtPayment.Text == "Payment Receipt")
                {
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        string orderID = Convert.ToString(dataGridView1.Rows[0].Cells[0].Value);
                        var itemDel = (from list in orderContext.deposit_receipt where list.Order_ID == orderID select list).First();
                        orderContext.deposit_receipt.Remove(itemDel);
                        orderContext.SaveChanges();
                    }

                    for (int i = 0; i < dataGridView3.Rows.Count; i++)
                    {
                        if (Convert.ToDouble(dataGridView3.Rows[i].Cells[6].Value) > 0)
                        {
                            var item = new WindowsFormsApp1.payment_receipt();
                            item.Order_ID = txtOID.Text;
                            item.itemsID = Convert.ToInt32(dataGridView3.Rows[i].Cells[0].Value);
                            item.Items_Name = Convert.ToString(dataGridView3.Rows[i].Cells[1].Value);
                            item.Quantity = Convert.ToInt32(dataGridView3.Rows[i].Cells[5].Value);
                            item.Item_Price = Convert.ToDouble(dataGridView3.Rows[i].Cells[6].Value);
                            item.Payment_amounts = Convert.ToDouble(txtPrice.Text);
                            item.Created_Date = System.DateTime.Now;
                            orderContext.payment_receipt.Add(item);
                            orderContext.SaveChanges();
                        }
                    }
                }

                if (Convert.ToString(dataGridView1.Rows[0].Cells[1].Value) != txtPayment.Text && txtPayment.Text == "Deposit Receipt")
                {
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        string orderID = Convert.ToString(dataGridView1.Rows[0].Cells[0].Value);
                        var itemDel = (from list in orderContext.payment_receipt where list.Order_ID == orderID select list).First();
                        orderContext.payment_receipt.Remove(itemDel);
                        orderContext.SaveChanges();
                    }

                    for (int i = 0; i < dataGridView3.Rows.Count; i++)
                    {
                        if (Convert.ToDouble(dataGridView3.Rows[i].Cells[6].Value) > 0)
                        {
                            var item = new WindowsFormsApp1.deposit_receipt();
                            item.Order_ID = txtOID.Text;
                            item.itemsID = Convert.ToInt32(dataGridView3.Rows[i].Cells[0].Value);
                            item.Items_Name = Convert.ToString(dataGridView3.Rows[i].Cells[1].Value);
                            item.Quantity = Convert.ToInt32(dataGridView3.Rows[i].Cells[5].Value);
                            item.ItemPrice = Convert.ToDouble(dataGridView3.Rows[i].Cells[6].Value);
                            item.TotalPrice = Convert.ToDouble(txtPrice.Text);
                            item.Deposit_Amounts = Convert.ToDouble(dataGridView3.Rows[i].Cells[7].Value);
                            item.outstanding_amounts = Convert.ToDouble(dataGridView3.Rows[i].Cells[8].Value);
                            item.Created_Date = System.DateTime.Now;
                            item.customerID = Convert.ToInt32(txtCustomer.Text);
                            orderContext.deposit_receipt.Add(item);
                            orderContext.SaveChanges();
                        }
                    }
                }
            }
        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            double price = 0;
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                price = price + Convert.ToDouble(dataGridView3.Rows[i].Cells[6].Value);
                txtPrice.Text = Convert.ToString(price);
            }
            lblPrice.Text = "Price = $" + price;
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

        private void btnFinish_Click(object sender, EventArgs e)
        {
            double price = 0;
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                price = price + Convert.ToDouble(dataGridView3.Rows[i].Cells[6].Value);
                txtPrice.Text = Convert.ToString(price);
            }
            lblPrice.Text = "Price = $" + price;

            if (txtPrice.Text == "" || txtPrice.Text == "0")
            {
                MessageBox.Show("Please select an item!");
            }
            else
            {
                if (txtPayment.Text == "Deposit Receipt")
                {
                    int check;
                    if (!int.TryParse(txtCustomer.Text, out check))
                    {
                        MessageBox.Show("Customer ID must be an integer");
                    }
                    else if (txtCustomer.Text == "" || !CheckValidCustomerID(Convert.ToInt32(txtCustomer.Text)))
                    {
                        MessageBox.Show("Please input a correct customer ID");
                    }
                }
                    UpdateRecord();
                    MessageBox.Show(txtOID.Text + " is updated successful.");
                    string employeeID = txtEmpID.Text;
                    string position = txtPosition.Text;
                    frmOrder order = new frmOrder(employeeID, position);
                    order.Show();
                    this.Hide();
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            double checkPayment = 0;
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                if (Convert.ToInt32(dataGridView3.Rows[i].Cells[5].Value) > Convert.ToInt32(dataGridView3.Rows[i].Cells[2].Value) && Convert.ToBoolean(dataGridView3.Rows[i].Cells[4].Value) == true)
                {
                    if ((Convert.ToDouble(dataGridView3.Rows[i].Cells[5].Value) - Convert.ToDouble(dataGridView3.Rows[i].Cells[2].Value)) * Convert.ToDouble(dataGridView3.Rows[i].Cells[3].Value) >= 5000)
                    {
                        dataGridView3.Rows[i].Cells[7].Value = Convert.ToDouble((Convert.ToInt32(dataGridView3.Rows[i].Cells[5].Value) - Convert.ToInt32(dataGridView3.Rows[i].Cells[2].Value)) * (Convert.ToDouble(dataGridView3.Rows[i].Cells[3].Value) * 0.2) + (Convert.ToInt32(dataGridView3.Rows[i].Cells[2].Value) * Convert.ToDouble(dataGridView3.Rows[i].Cells[3].Value)));
                        dataGridView3.Rows[i].Cells[8].Value = Convert.ToDouble(dataGridView3.Rows[i].Cells[6].Value) - Convert.ToDouble(dataGridView3.Rows[i].Cells[7].Value);
                    }
                    if ((Convert.ToDouble(dataGridView3.Rows[i].Cells[5].Value) - Convert.ToDouble(dataGridView3.Rows[i].Cells[2].Value)) * Convert.ToDouble(dataGridView3.Rows[i].Cells[3].Value) < 5000)
                    {
                        dataGridView3.Rows[i].Cells[7].Value = Convert.ToInt32(dataGridView3.Rows[i].Cells[2].Value) * Convert.ToDouble(dataGridView3.Rows[i].Cells[3].Value);
                        dataGridView3.Rows[i].Cells[8].Value = Convert.ToDouble(dataGridView3.Rows[i].Cells[6].Value) - Convert.ToDouble(dataGridView3.Rows[i].Cells[7].Value);
                    }
                }
                else if (Convert.ToInt32(dataGridView3.Rows[i].Cells[5].Value) <= Convert.ToInt32(dataGridView3.Rows[i].Cells[2].Value) && Convert.ToBoolean(dataGridView3.Rows[i].Cells[4].Value) == true)
                {
                    dataGridView3.Rows[i].Cells[7].Value = dataGridView3.Rows[i].Cells[6].Value;
                    dataGridView3.Rows[i].Cells[8].Value = Convert.ToDouble(dataGridView3.Rows[i].Cells[6].Value) - Convert.ToDouble(dataGridView3.Rows[i].Cells[7].Value);
                }
                else
                {
                    dataGridView3.Rows[i].Cells[7].Value = 0;
                    dataGridView3.Rows[i].Cells[8].Value = 0;
                }

                if (Convert.ToBoolean(dataGridView3.Rows[i].Cells[4].Value) == true)
                {
                    dataGridView3.Rows[i].Cells[6].Value = Convert.ToDouble(dataGridView3.Rows[i].Cells[3].Value) * Convert.ToDouble(dataGridView3.Rows[i].Cells[5].Value);
                    checkPayment = checkPayment + Convert.ToDouble(dataGridView3.Rows[i].Cells[8].Value);
                }
                else
                {
                    dataGridView3.Rows[i].Cells[6].Value = 0;
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
            string employeeID = txtEmpID.Text;
            string position = txtPosition.Text;
            frmOrder order = new frmOrder(employeeID,position);
            order.Show();
            this.Hide();
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
        private void dataGridView3_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.dataGridView3.CurrentCellAddress.X == 5)
            {
                CellEdit = (DataGridViewTextBoxEditingControl)e.Control;
                CellEdit.SelectAll();
                CellEdit.KeyPress += Cells_KeyPress;
            }
        }
        private void Cells_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((this.dataGridView3.CurrentCellAddress.X == 5))
            {
                if (!(e.KeyChar >= '0' && e.KeyChar <= '9')) e.Handled = true;
                if (e.KeyChar == '\b') e.Handled = false;
            }
        }
    }
}
