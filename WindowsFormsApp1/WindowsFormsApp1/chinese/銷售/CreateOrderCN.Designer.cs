
namespace Better_Limited
{
    partial class frmCreateCN
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateCN));
            this.lblOID = new System.Windows.Forms.Label();
            this.txtOID = new System.Windows.Forms.TextBox();
            this.lblPayment = new System.Windows.Forms.Label();
            this.txtEID = new System.Windows.Forms.TextBox();
            this.lblEID = new System.Windows.Forms.Label();
            this.btnFinish = new System.Windows.Forms.Button();
            this.better_limitedDataSet = new WindowsFormsApp1.better_limitedDataSet();
            this.betterlimitedDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.paymentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.paymentTableAdapter = new WindowsFormsApp1.better_limitedDataSetTableAdapters.paymentTableAdapter();
            this.lblNew = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblPriceText = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.cmBoxMethod = new System.Windows.Forms.ComboBox();
            this.lblMethod = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmBoxRegion = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBack = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkDelivery = new System.Windows.Forms.CheckBox();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtPayment = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.picVisa = new System.Windows.Forms.PictureBox();
            this.picMaster = new System.Windows.Forms.PictureBox();
            this.picCash = new System.Windows.Forms.PictureBox();
            this.picAlipayHK = new System.Windows.Forms.PictureBox();
            this.picAlipay = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.better_limitedDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.betterlimitedDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVisa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAlipayHK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAlipay)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOID
            // 
            resources.ApplyResources(this.lblOID, "lblOID");
            this.lblOID.Name = "lblOID";
            // 
            // txtOID
            // 
            resources.ApplyResources(this.txtOID, "txtOID");
            this.txtOID.Name = "txtOID";
            // 
            // lblPayment
            // 
            resources.ApplyResources(this.lblPayment, "lblPayment");
            this.lblPayment.Name = "lblPayment";
            // 
            // txtEID
            // 
            resources.ApplyResources(this.txtEID, "txtEID");
            this.txtEID.Name = "txtEID";
            this.txtEID.ReadOnly = true;
            // 
            // lblEID
            // 
            resources.ApplyResources(this.lblEID, "lblEID");
            this.lblEID.Name = "lblEID";
            // 
            // btnFinish
            // 
            this.btnFinish.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.btnFinish, "btnFinish");
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.UseVisualStyleBackColor = false;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // better_limitedDataSet
            // 
            this.better_limitedDataSet.DataSetName = "better_limitedDataSet";
            this.better_limitedDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // betterlimitedDataSetBindingSource
            // 
            this.betterlimitedDataSetBindingSource.DataSource = this.better_limitedDataSet;
            this.betterlimitedDataSetBindingSource.Position = 0;
            // 
            // paymentBindingSource
            // 
            this.paymentBindingSource.DataMember = "payment";
            this.paymentBindingSource.DataSource = this.better_limitedDataSet;
            // 
            // paymentTableAdapter
            // 
            this.paymentTableAdapter.ClearBeforeFill = true;
            // 
            // lblNew
            // 
            resources.ApplyResources(this.lblNew, "lblNew");
            this.lblNew.Name = "lblNew";
            // 
            // btnCalculate
            // 
            resources.ApplyResources(this.btnCalculate, "btnCalculate");
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // lblPrice
            // 
            this.lblPrice.BackColor = System.Drawing.Color.White;
            this.lblPrice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPrice.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblPrice, "lblPrice");
            this.lblPrice.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblPrice.Name = "lblPrice";
            // 
            // lblPriceText
            // 
            resources.ApplyResources(this.lblPriceText, "lblPriceText");
            this.lblPriceText.Name = "lblPriceText";
            // 
            // txtPrice
            // 
            resources.ApplyResources(this.txtPrice, "txtPrice");
            this.txtPrice.Name = "txtPrice";
            // 
            // cmBoxMethod
            // 
            resources.ApplyResources(this.cmBoxMethod, "cmBoxMethod");
            this.cmBoxMethod.FormattingEnabled = true;
            this.cmBoxMethod.Items.AddRange(new object[] {
            resources.GetString("cmBoxMethod.Items"),
            resources.GetString("cmBoxMethod.Items1"),
            resources.GetString("cmBoxMethod.Items2"),
            resources.GetString("cmBoxMethod.Items3"),
            resources.GetString("cmBoxMethod.Items4")});
            this.cmBoxMethod.Name = "cmBoxMethod";
            this.cmBoxMethod.SelectedIndexChanged += new System.EventHandler(this.cmBoxMethod_SelectedIndexChanged);
            // 
            // lblMethod
            // 
            resources.ApplyResources(this.lblMethod, "lblMethod");
            this.lblMethod.Name = "lblMethod";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cmBoxRegion
            // 
            resources.ApplyResources(this.cmBoxRegion, "cmBoxRegion");
            this.cmBoxRegion.FormattingEnabled = true;
            this.cmBoxRegion.Items.AddRange(new object[] {
            resources.GetString("cmBoxRegion.Items"),
            resources.GetString("cmBoxRegion.Items1"),
            resources.GetString("cmBoxRegion.Items2"),
            resources.GetString("cmBoxRegion.Items3")});
            this.cmBoxRegion.Name = "cmBoxRegion";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column1,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            // 
            // Column2
            // 
            resources.ApplyResources(this.Column2, "Column2");
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            resources.ApplyResources(this.Column3, "Column3");
            this.Column3.Name = "Column3";
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            resources.ApplyResources(this.Column4, "Column4");
            this.Column4.Name = "Column4";
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            resources.ApplyResources(this.Column5, "Column5");
            this.Column5.Name = "Column5";
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column1
            // 
            this.Column1.FalseValue = "false";
            resources.ApplyResources(this.Column1, "Column1");
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.TrueValue = "true";
            // 
            // Column6
            // 
            resources.ApplyResources(this.Column6, "Column6");
            this.Column6.Name = "Column6";
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column7
            // 
            resources.ApplyResources(this.Column7, "Column7");
            this.Column7.Name = "Column7";
            this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column8
            // 
            resources.ApplyResources(this.Column8, "Column8");
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            resources.ApplyResources(this.Column9, "Column9");
            this.Column9.Name = "Column9";
            // 
            // btnBack
            // 
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.btnBack, "btnBack");
            this.btnBack.Name = "btnBack";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // checkDelivery
            // 
            resources.ApplyResources(this.checkDelivery, "checkDelivery");
            this.checkDelivery.Name = "checkDelivery";
            this.checkDelivery.UseVisualStyleBackColor = true;
            // 
            // btnCustomer
            // 
            resources.ApplyResources(this.btnCustomer, "btnCustomer");
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // lblCustomer
            // 
            resources.ApplyResources(this.lblCustomer, "lblCustomer");
            this.lblCustomer.Name = "lblCustomer";
            // 
            // txtCustomer
            // 
            resources.ApplyResources(this.txtCustomer, "txtCustomer");
            this.txtCustomer.Name = "txtCustomer";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // txtPayment
            // 
            resources.ApplyResources(this.txtPayment, "txtPayment");
            this.txtPayment.Name = "txtPayment";
            this.txtPayment.ReadOnly = true;
            this.txtPayment.TextChanged += new System.EventHandler(this.txtPayment_TextChanged);
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            // 
            // txtStock
            // 
            resources.ApplyResources(this.txtStock, "txtStock");
            this.txtStock.Name = "txtStock";
            // 
            // txtPosition
            // 
            resources.ApplyResources(this.txtPosition, "txtPosition");
            this.txtPosition.Name = "txtPosition";
            // 
            // picVisa
            // 
            resources.ApplyResources(this.picVisa, "picVisa");
            this.picVisa.Name = "picVisa";
            this.picVisa.TabStop = false;
            // 
            // picMaster
            // 
            this.picMaster.Image = global::WindowsFormsApp1.Properties.Resources.master1;
            resources.ApplyResources(this.picMaster, "picMaster");
            this.picMaster.Name = "picMaster";
            this.picMaster.TabStop = false;
            // 
            // picCash
            // 
            resources.ApplyResources(this.picCash, "picCash");
            this.picCash.Name = "picCash";
            this.picCash.TabStop = false;
            // 
            // picAlipayHK
            // 
            resources.ApplyResources(this.picAlipayHK, "picAlipayHK");
            this.picAlipayHK.Name = "picAlipayHK";
            this.picAlipayHK.TabStop = false;
            // 
            // picAlipay
            // 
            resources.ApplyResources(this.picAlipay, "picAlipay");
            this.picAlipay.Name = "picAlipay";
            this.picAlipay.TabStop = false;
            // 
            // frmCreateCN
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.Controls.Add(this.txtPosition);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.txtPayment);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.btnCustomer);
            this.Controls.Add(this.checkDelivery);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cmBoxRegion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picVisa);
            this.Controls.Add(this.picMaster);
            this.Controls.Add(this.picCash);
            this.Controls.Add(this.picAlipayHK);
            this.Controls.Add(this.picAlipay);
            this.Controls.Add(this.cmBoxMethod);
            this.Controls.Add(this.lblMethod);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblPriceText);
            this.Controls.Add(this.lblNew);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.txtEID);
            this.Controls.Add(this.lblEID);
            this.Controls.Add(this.lblPayment);
            this.Controls.Add(this.txtOID);
            this.Controls.Add(this.lblOID);
            this.Name = "frmCreateCN";
            this.Load += new System.EventHandler(this.frmCreate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.better_limitedDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.betterlimitedDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVisa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAlipayHK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAlipay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOID;
        private System.Windows.Forms.TextBox txtOID;
        private System.Windows.Forms.Label lblPayment;
        private System.Windows.Forms.TextBox txtEID;
        private System.Windows.Forms.Label lblEID;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.BindingSource betterlimitedDataSetBindingSource;
        private WindowsFormsApp1.better_limitedDataSet better_limitedDataSet;
        private System.Windows.Forms.BindingSource paymentBindingSource;
        private WindowsFormsApp1.better_limitedDataSetTableAdapters.paymentTableAdapter paymentTableAdapter;
        private System.Windows.Forms.Label lblNew;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblPriceText;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.ComboBox cmBoxMethod;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.PictureBox picAlipay;
        private System.Windows.Forms.PictureBox picAlipayHK;
        private System.Windows.Forms.PictureBox picCash;
        private System.Windows.Forms.PictureBox picMaster;
        private System.Windows.Forms.PictureBox picVisa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmBoxRegion;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkDelivery;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox txtPayment;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.TextBox txtPosition;
    }
}