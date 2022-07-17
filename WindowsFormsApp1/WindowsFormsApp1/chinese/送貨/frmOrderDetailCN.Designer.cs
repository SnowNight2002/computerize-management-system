
namespace BLtd
{
    partial class frmOrderDetailCN
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
            this.gboOrderdetail = new System.Windows.Forms.GroupBox();
            this.lblCompeteDate = new System.Windows.Forms.Label();
            this.dtpComplete = new System.Windows.Forms.DateTimePicker();
            this.txtOrdId = new System.Windows.Forms.TextBox();
            this.txtWorkerId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInstallID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblInstallDate = new System.Windows.Forms.Label();
            this.lblDeliveryDate = new System.Windows.Forms.Label();
            this.cboSlot = new System.Windows.Forms.ComboBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.dtpDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDeliveryId = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCusId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.dgvItemList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDelivery = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnInstall = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.gboOrderdetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboOrderdetail
            // 
            this.gboOrderdetail.Controls.Add(this.lblCompeteDate);
            this.gboOrderdetail.Controls.Add(this.dtpComplete);
            this.gboOrderdetail.Controls.Add(this.txtOrdId);
            this.gboOrderdetail.Controls.Add(this.txtWorkerId);
            this.gboOrderdetail.Controls.Add(this.label1);
            this.gboOrderdetail.Controls.Add(this.lblInstallID);
            this.gboOrderdetail.Controls.Add(this.label3);
            this.gboOrderdetail.Controls.Add(this.lblInstallDate);
            this.gboOrderdetail.Controls.Add(this.lblDeliveryDate);
            this.gboOrderdetail.Controls.Add(this.cboSlot);
            this.gboOrderdetail.Controls.Add(this.cboStatus);
            this.gboOrderdetail.Controls.Add(this.dtpDeliveryDate);
            this.gboOrderdetail.Controls.Add(this.label6);
            this.gboOrderdetail.Controls.Add(this.lblDeliveryId);
            this.gboOrderdetail.Font = new System.Drawing.Font("Microsoft JhengHei", 15.75F, System.Drawing.FontStyle.Bold);
            this.gboOrderdetail.ForeColor = System.Drawing.SystemColors.Desktop;
            this.gboOrderdetail.Location = new System.Drawing.Point(23, 29);
            this.gboOrderdetail.Name = "gboOrderdetail";
            this.gboOrderdetail.Size = new System.Drawing.Size(784, 164);
            this.gboOrderdetail.TabIndex = 0;
            this.gboOrderdetail.TabStop = false;
            this.gboOrderdetail.Text = "订单详情";
            // 
            // lblCompeteDate
            // 
            this.lblCompeteDate.AutoSize = true;
            this.lblCompeteDate.Font = new System.Drawing.Font("Microsoft JhengHei", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblCompeteDate.Location = new System.Drawing.Point(528, 124);
            this.lblCompeteDate.Name = "lblCompeteDate";
            this.lblCompeteDate.Size = new System.Drawing.Size(96, 26);
            this.lblCompeteDate.TabIndex = 33;
            this.lblCompeteDate.Text = "完成日期";
            // 
            // dtpComplete
            // 
            this.dtpComplete.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpComplete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.dtpComplete.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpComplete.Location = new System.Drawing.Point(633, 124);
            this.dtpComplete.Name = "dtpComplete";
            this.dtpComplete.Size = new System.Drawing.Size(121, 26);
            this.dtpComplete.TabIndex = 32;
            // 
            // txtOrdId
            // 
            this.txtOrdId.BackColor = System.Drawing.SystemColors.Window;
            this.txtOrdId.Location = new System.Drawing.Point(166, 49);
            this.txtOrdId.Name = "txtOrdId";
            this.txtOrdId.ReadOnly = true;
            this.txtOrdId.Size = new System.Drawing.Size(117, 35);
            this.txtOrdId.TabIndex = 1;
            // 
            // txtWorkerId
            // 
            this.txtWorkerId.BackColor = System.Drawing.SystemColors.Window;
            this.txtWorkerId.Location = new System.Drawing.Point(635, 71);
            this.txtWorkerId.Name = "txtWorkerId";
            this.txtWorkerId.ReadOnly = true;
            this.txtWorkerId.Size = new System.Drawing.Size(121, 35);
            this.txtWorkerId.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(528, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 26);
            this.label1.TabIndex = 29;
            this.label1.Text = "工人编号";
            // 
            // lblInstallID
            // 
            this.lblInstallID.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblInstallID.Location = new System.Drawing.Point(6, 45);
            this.lblInstallID.Name = "lblInstallID";
            this.lblInstallID.Size = new System.Drawing.Size(148, 48);
            this.lblInstallID.TabIndex = 26;
            this.lblInstallID.Text = "安装编号";
            this.lblInstallID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei", 15.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(537, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 26);
            this.label3.TabIndex = 22;
            this.label3.Text = "状态";
            // 
            // lblInstallDate
            // 
            this.lblInstallDate.AutoSize = true;
            this.lblInstallDate.Font = new System.Drawing.Font("Microsoft JhengHei", 15F, System.Drawing.FontStyle.Bold);
            this.lblInstallDate.Location = new System.Drawing.Point(22, 97);
            this.lblInstallDate.Name = "lblInstallDate";
            this.lblInstallDate.Size = new System.Drawing.Size(92, 25);
            this.lblInstallDate.TabIndex = 27;
            this.lblInstallDate.Text = "安装日期";
            // 
            // lblDeliveryDate
            // 
            this.lblDeliveryDate.AutoSize = true;
            this.lblDeliveryDate.Font = new System.Drawing.Font("Microsoft JhengHei", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblDeliveryDate.Location = new System.Drawing.Point(22, 95);
            this.lblDeliveryDate.Name = "lblDeliveryDate";
            this.lblDeliveryDate.Size = new System.Drawing.Size(96, 26);
            this.lblDeliveryDate.TabIndex = 19;
            this.lblDeliveryDate.Text = "交货日期";
            // 
            // cboSlot
            // 
            this.cboSlot.BackColor = System.Drawing.SystemColors.Window;
            this.cboSlot.FormattingEnabled = true;
            this.cboSlot.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.cboSlot.Location = new System.Drawing.Point(391, 48);
            this.cboSlot.Name = "cboSlot";
            this.cboSlot.Size = new System.Drawing.Size(76, 34);
            this.cboSlot.TabIndex = 21;
            this.toolTip1.SetToolTip(this.cboSlot, "Delivery Session\r\n1-5:  9:00am - 12:00am\r\n6-10 : 1:00pm - 5:00pm\r\n11-15: 6:00pm -" +
        " 10:00pm\r\n\r\n");
            // 
            // cboStatus
            // 
            this.cboStatus.BackColor = System.Drawing.SystemColors.Window;
            this.cboStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(635, 15);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(119, 28);
            this.cboStatus.TabIndex = 23;
            // 
            // dtpDeliveryDate
            // 
            this.dtpDeliveryDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDeliveryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.dtpDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDeliveryDate.Location = new System.Drawing.Point(166, 96);
            this.dtpDeliveryDate.Name = "dtpDeliveryDate";
            this.dtpDeliveryDate.Size = new System.Drawing.Size(117, 26);
            this.dtpDeliveryDate.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei", 15.75F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(315, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 26);
            this.label6.TabIndex = 20;
            this.label6.Text = "时段";
            // 
            // lblDeliveryId
            // 
            this.lblDeliveryId.AutoSize = true;
            this.lblDeliveryId.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblDeliveryId.Location = new System.Drawing.Point(5, 56);
            this.lblDeliveryId.Name = "lblDeliveryId";
            this.lblDeliveryId.Size = new System.Drawing.Size(100, 25);
            this.lblDeliveryId.TabIndex = 2;
            this.lblDeliveryId.Text = "交货编号";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft JhengHei", 15.75F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(59, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 26);
            this.label7.TabIndex = 25;
            this.label7.Text = "电话";
            // 
            // txtCusId
            // 
            this.txtCusId.BackColor = System.Drawing.SystemColors.Window;
            this.txtCusId.Location = new System.Drawing.Point(152, 31);
            this.txtCusId.Name = "txtCusId";
            this.txtCusId.ReadOnly = true;
            this.txtCusId.Size = new System.Drawing.Size(142, 33);
            this.txtCusId.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei", 15.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(11, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "客户编号";
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.SystemColors.Window;
            this.txtPhone.Location = new System.Drawing.Point(152, 126);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(146, 33);
            this.txtPhone.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei", 15.75F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(343, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 26);
            this.label5.TabIndex = 13;
            this.label5.Text = "地址";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(348, 61);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(420, 94);
            this.txtAddress.TabIndex = 14;
            // 
            // dgvItemList
            // 
            this.dgvItemList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvItemList.Location = new System.Drawing.Point(23, 376);
            this.dgvItemList.Name = "dgvItemList";
            this.dgvItemList.RowTemplate.Height = 24;
            this.dgvItemList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItemList.Size = new System.Drawing.Size(784, 162);
            this.dgvItemList.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "产品名称";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 20F;
            this.Column2.HeaderText = "数量";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // txtWeight
            // 
            this.txtWeight.BackColor = System.Drawing.SystemColors.Window;
            this.txtWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeight.Location = new System.Drawing.Point(143, 557);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.ReadOnly = true;
            this.txtWeight.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtWeight.Size = new System.Drawing.Size(69, 26);
            this.txtWeight.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(34, 562);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 19);
            this.label11.TabIndex = 27;
            this.label11.Text = "总重量";
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F);
            this.btnSave.Location = new System.Drawing.Point(509, 551);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 40);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F);
            this.btnCancel.Location = new System.Drawing.Point(616, 551);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(101, 40);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDelivery);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.btnInstall);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPhone);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtCusId);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(23, 199);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(784, 171);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "顾客信息";
            // 
            // btnDelivery
            // 
            this.btnDelivery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelivery.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F);
            this.btnDelivery.Location = new System.Drawing.Point(631, 24);
            this.btnDelivery.Name = "btnDelivery";
            this.btnDelivery.Size = new System.Drawing.Size(123, 31);
            this.btnDelivery.TabIndex = 36;
            this.btnDelivery.Text = "交货 >";
            this.btnDelivery.UseVisualStyleBackColor = true;
            this.btnDelivery.Click += new System.EventHandler(this.btnDelivery_Click);
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.Window;
            this.txtName.Location = new System.Drawing.Point(152, 78);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(146, 33);
            this.txtName.TabIndex = 32;
            // 
            // btnInstall
            // 
            this.btnInstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstall.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstall.Location = new System.Drawing.Point(631, 24);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(123, 31);
            this.btnInstall.TabIndex = 34;
            this.btnInstall.Text = "安装 >";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei", 15.75F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(59, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 26);
            this.label4.TabIndex = 33;
            this.label4.Text = "姓名";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(218, 562);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 19);
            this.label8.TabIndex = 33;
            this.label8.Text = "磅";
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F);
            this.btnDelete.Location = new System.Drawing.Point(723, 550);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(84, 40);
            this.btnDelete.TabIndex = 35;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmOrderDetailCN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Moccasin;
            this.ClientSize = new System.Drawing.Size(847, 620);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dgvItemList);
            this.Controls.Add(this.gboOrderdetail);
            this.Name = "frmOrderDetailCN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "订单详情";
            this.gboOrderdetail.ResumeLayout(false);
            this.gboOrderdetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gboOrderdetail;
        private System.Windows.Forms.Label lblDeliveryId;
        private System.Windows.Forms.TextBox txtOrdId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboSlot;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDeliveryDate;
        private System.Windows.Forms.DateTimePicker dtpDeliveryDate;
        private System.Windows.Forms.DataGridView dgvItemList;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCusId;
        private System.Windows.Forms.Label lblInstallID;
        private System.Windows.Forms.Label lblInstallDate;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWorkerId;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCompeteDate;
        private System.Windows.Forms.DateTimePicker dtpComplete;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button btnDelivery;
    }
}