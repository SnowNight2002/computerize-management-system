using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;

namespace StockRecordingWarehouseInventory
{
    public partial class InventoryManagementSystemReceipt : Form
    {
        public InventoryManagementSystemReceipt()
        {

            InitializeComponent();

        }

        public InventoryManagementSystemReceipt(int txtReOrderID1, string txtItemType1, string txtItemBrand1, string txtSupplier1, int txtItemQuantity1, int txtItemPrice1, int txtAmounts1, string txtReceiveDate1,
            int txtReOrderID2, string txtItemType2, string txtItemBrand2, string txtSupplier2, int txtItemQuantity2, int txtItemPrice2, int txtAmounts2, string txtReceiveDate2,
            int txtReOrderID3, string txtItemType3, string txtItemBrand3, string txtSupplier3, int txtItemQuantity3, int txtItemPrice3, int txtAmounts3, string txtReceiveDate3,
            int txtReOrderID4, string txtItemType4, string txtItemBrand4, string txtSupplier4, int txtItemQuantity4, int txtItemPrice4, int txtAmounts4, string txtReceiveDate4,
            int txtReOrderID5, string txtItemType5, string txtItemBrand5, string txtSupplier5, int txtItemQuantity5, int txtItemPrice5, int txtAmounts5, string txtReceiveDate5)
        {
            InitializeComponent();
            //int txtReOrderID1, string txtItemType1, string txtItemBrand1, string txtSupplier1, int txtItemQuantity1, int txtItemPrice1, int txtAmounts1, string txtReceiveDate1,
            //label4.Text = txtReOrderID1.ToString();

            label20.Text = txtReceiveDate1;
            label42.Text = txtSupplier1;


            label10.Text = txtReOrderID1.ToString();
            label11.Text = txtItemType1;
            label12.Text = txtItemBrand1;
            label41.Text = txtItemQuantity1.ToString();
            label14.Text = txtItemPrice1.ToString();
            label15.Text = txtAmounts1.ToString();

            label16.Text = txtReOrderID2.ToString();
            label17.Text = txtItemType2;
            label18.Text = txtItemBrand2;
            label19.Text = txtItemQuantity2.ToString();
            label13.Text = txtItemPrice2.ToString();
            label21.Text = txtAmounts2.ToString();

            label22.Text = txtReOrderID3.ToString();
            label23.Text = txtItemType3;
            label24.Text = txtItemBrand3;
            label25.Text = txtItemQuantity3.ToString();
            label26.Text = txtItemPrice3.ToString();
            label27.Text = txtAmounts3.ToString();

            label28.Text = txtReOrderID4.ToString();
            label29.Text = txtItemType4;
            label30.Text = txtItemBrand4;
            label31.Text = txtItemQuantity4.ToString();
            label32.Text = txtItemPrice4.ToString();
            label33.Text = txtAmounts4.ToString();

            label34.Text = txtReOrderID5.ToString();
            label35.Text = txtItemType5;
            label36.Text = txtItemBrand5;
            label37.Text = txtItemQuantity5.ToString();
            label38.Text = txtItemPrice5.ToString();
            label39.Text = txtAmounts5.ToString();
        }

            private void InventoryManagementSystemReceipt_Load(object sender, EventArgs e)
            {

        }


        private void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;
            Bitmap bmp = new Bitmap(panel1.Width, panel1.Height);
            panel1.DrawToBitmap(bmp, new Rectangle(0, 0, panel1.Width, panel1.Height));
            e.Graphics.DrawImage((Image)bmp, x, y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += this.doc_PrintPage;

            PrintDialog dlg = new PrintDialog();
            dlg.Document = doc;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }
        }

    }
    } 
