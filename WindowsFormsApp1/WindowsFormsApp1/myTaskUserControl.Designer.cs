
namespace BLtd
{
    partial class myTaskUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gboOrder = new System.Windows.Forms.GroupBox();
            this.btnCOMPLETE = new System.Windows.Forms.Button();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtDeliverTime = new System.Windows.Forms.TextBox();
            this.txtReceiverName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gboOrder.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboOrder
            // 
            this.gboOrder.Controls.Add(this.btnCOMPLETE);
            this.gboOrder.Controls.Add(this.txtPhone);
            this.gboOrder.Controls.Add(this.label5);
            this.gboOrder.Controls.Add(this.lblStatus);
            this.gboOrder.Controls.Add(this.txtAddress);
            this.gboOrder.Controls.Add(this.txtDeliverTime);
            this.gboOrder.Controls.Add(this.txtReceiverName);
            this.gboOrder.Controls.Add(this.label3);
            this.gboOrder.Controls.Add(this.label2);
            this.gboOrder.Controls.Add(this.label1);
            this.gboOrder.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboOrder.Location = new System.Drawing.Point(3, 3);
            this.gboOrder.Name = "gboOrder";
            this.gboOrder.Size = new System.Drawing.Size(319, 231);
            this.gboOrder.TabIndex = 0;
            this.gboOrder.TabStop = false;
            this.gboOrder.Text = "Order No";
            // 
            // btnCOMPLETE
            // 
            this.btnCOMPLETE.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCOMPLETE.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCOMPLETE.Location = new System.Drawing.Point(228, 191);
            this.btnCOMPLETE.Name = "btnCOMPLETE";
            this.btnCOMPLETE.Size = new System.Drawing.Size(85, 34);
            this.btnCOMPLETE.TabIndex = 19;
            this.btnCOMPLETE.Text = "COMPLETE";
            this.btnCOMPLETE.UseVisualStyleBackColor = false;
            this.btnCOMPLETE.Click += new System.EventHandler(this.btnCOMPLETE_Click);
            // 
            // txtPhone
            // 
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPhone.Location = new System.Drawing.Point(113, 64);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(119, 20);
            this.txtPhone.TabIndex = 18;
            this.txtPhone.Text = "?????????";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(6, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Receiver Phone:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblStatus.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(210, 8);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(105, 24);
            this.lblStatus.TabIndex = 16;
            this.lblStatus.Text = "Processing";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Roboto Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(81, 120);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(232, 66);
            this.txtAddress.TabIndex = 15;
            // 
            // txtDeliverTime
            // 
            this.txtDeliverTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDeliverTime.Location = new System.Drawing.Point(110, 91);
            this.txtDeliverTime.Name = "txtDeliverTime";
            this.txtDeliverTime.ReadOnly = true;
            this.txtDeliverTime.Size = new System.Drawing.Size(203, 20);
            this.txtDeliverTime.TabIndex = 4;
            this.txtDeliverTime.Text = "??????";
            // 
            // txtReceiverName
            // 
            this.txtReceiverName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtReceiverName.Location = new System.Drawing.Point(113, 36);
            this.txtReceiverName.Name = "txtReceiverName";
            this.txtReceiverName.ReadOnly = true;
            this.txtReceiverName.Size = new System.Drawing.Size(119, 20);
            this.txtReceiverName.TabIndex = 3;
            this.txtReceiverName.Text = "????????????";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(9, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Location:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(6, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Delivery Time:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Receiver Name:";
            // 
            // myTaskUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.gboOrder);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Name = "myTaskUserControl";
            this.Size = new System.Drawing.Size(325, 238);
            this.gboOrder.ResumeLayout(false);
            this.gboOrder.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboOrder;
        private System.Windows.Forms.TextBox txtDeliverTime;
        private System.Windows.Forms.TextBox txtReceiverName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Button btnCOMPLETE;
    }
}
