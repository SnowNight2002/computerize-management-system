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

namespace Better_Limited
{
    public partial class frmPrintReturnCN : Form
    {
        public string Date, DefectID, EmpID, TotalAmount, Quantity, Price, ItemName;

        private void frmPrintReturnCN_Load(object sender, EventArgs e)
        {
            labelDate.Text = Date;
            labelAmount.Text = TotalAmount;
            labelPrice.Text = Price;
            labelItem.Text = ItemName;
            labelDID.Text = DefectID;
            labelQty.Text = Quantity;
            labelEmpID.Text = EmpID;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnPrint, "Print");
            Print(this.panelPrint);
        }

        public frmPrintReturnCN()
        {
            InitializeComponent();
            Date = DateTime.Now.ToString("M/d/yyyy");
        }
        private void Print(Panel pnl)
        {
            PrinterSettings ps = new PrinterSettings();
            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("custom", pnl.Width, pnl.Height + 100);
            panelPrint = pnl;
            getPrintArea(pnl);
            printPreviewDialog1.Document = printDocument1;
            printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDoucment1_PrintPage);
            printPreviewDialog1.ShowDialog();
        }

        private void printDoucment1_PrintPage(Object sender, PrintPageEventArgs e)
        {
            Rectangle pageArea = e.PageBounds;
            e.Graphics.DrawImage(memoryimg, (pageArea.Width / 2) - (this.panelPrint.Width / 2), this.panelPrint.Location.Y);
        }

        private Bitmap memoryimg;

        private void getPrintArea(Panel pnl)
        {
            memoryimg = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(memoryimg, new Rectangle(0, 0, pnl.Width, pnl.Height));
        }
    }
}
