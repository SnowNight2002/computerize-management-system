
namespace WindowsFormsApp1.pepper
{
    partial class admin2CN
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
            this.txtEmpdep = new System.Windows.Forms.ComboBox();
            this.txtEmpID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Close1 = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Create = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.txtpw = new System.Windows.Forms.TextBox();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.txtsans = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel13.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtEmpdep
            // 
            this.txtEmpdep.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtEmpdep.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtEmpdep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtEmpdep.Font = new System.Drawing.Font("MS Reference Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.txtEmpdep.FormattingEnabled = true;
            this.txtEmpdep.Items.AddRange(new object[] {
            "",
            "Manager",
            "Delivery Worker",
            "Sales",
            "Accounting",
            "Purchase",
            "Inventory",
            "Technical Support",
            "Clerk",
            "admin"});
            this.txtEmpdep.Location = new System.Drawing.Point(364, 202);
            this.txtEmpdep.Name = "txtEmpdep";
            this.txtEmpdep.Size = new System.Drawing.Size(328, 42);
            this.txtEmpdep.TabIndex = 4;
            // 
            // txtEmpID
            // 
            this.txtEmpID.BackColor = System.Drawing.SystemColors.Control;
            this.txtEmpID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmpID.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtEmpID.Font = new System.Drawing.Font("MS Reference Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.txtEmpID.Location = new System.Drawing.Point(364, 83);
            this.txtEmpID.Multiline = true;
            this.txtEmpID.Name = "txtEmpID";
            this.txtEmpID.Size = new System.Drawing.Size(328, 44);
            this.txtEmpID.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(252, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 29);
            this.label1.TabIndex = 10;
            this.label1.Text = "員工ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(233, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 29);
            this.label2.TabIndex = 11;
            this.label2.Text = "員工姓名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(258, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 29);
            this.label3.TabIndex = 12;
            this.label3.Text = "用户名";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.Font = new System.Drawing.Font("MS Reference Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(242, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 29);
            this.label4.TabIndex = 13;
            this.label4.Text = "員工部門";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.label5.Font = new System.Drawing.Font("MS Reference Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(283, 323);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 29);
            this.label5.TabIndex = 14;
            this.label5.Text = "密码";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Cursor = System.Windows.Forms.Cursors.Default;
            this.label6.Font = new System.Drawing.Font("MS Reference Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(233, 375);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 29);
            this.label6.TabIndex = 15;
            this.label6.Text = "安全答案";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel1.Controls.Add(this.Close1);
            this.panel1.Controls.Add(this.Delete);
            this.panel1.Controls.Add(this.Create);
            this.panel1.Controls.Add(this.update);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 454);
            this.panel1.TabIndex = 17;
            // 
            // Close1
            // 
            this.Close1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Close1.FlatAppearance.BorderSize = 0;
            this.Close1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close1.Font = new System.Drawing.Font("MS Reference Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Close1.Image = global::WindowsFormsApp1.Properties.Resources.x_mark_32;
            this.Close1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Close1.Location = new System.Drawing.Point(0, 375);
            this.Close1.Name = "Close1";
            this.Close1.Size = new System.Drawing.Size(200, 75);
            this.Close1.TabIndex = 20;
            this.Close1.Text = "登出";
            this.Close1.UseVisualStyleBackColor = true;
            this.Close1.Click += new System.EventHandler(this.Close_Click);
            // 
            // Delete
            // 
            this.Delete.Dock = System.Windows.Forms.DockStyle.Top;
            this.Delete.FlatAppearance.BorderSize = 0;
            this.Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete.Font = new System.Drawing.Font("MS Reference Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Delete.Image = global::WindowsFormsApp1.Properties.Resources.delete_32;
            this.Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Delete.Location = new System.Drawing.Point(0, 300);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(200, 75);
            this.Delete.TabIndex = 19;
            this.Delete.Text = "删除";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Create
            // 
            this.Create.Dock = System.Windows.Forms.DockStyle.Top;
            this.Create.FlatAppearance.BorderSize = 0;
            this.Create.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Create.Font = new System.Drawing.Font("MS Reference Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Create.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Create.Image = global::WindowsFormsApp1.Properties.Resources.add_32;
            this.Create.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Create.Location = new System.Drawing.Point(0, 225);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(200, 75);
            this.Create.TabIndex = 18;
            this.Create.Text = "创造";
            this.Create.UseVisualStyleBackColor = true;
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // update
            // 
            this.update.Dock = System.Windows.Forms.DockStyle.Top;
            this.update.FlatAppearance.BorderSize = 0;
            this.update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.update.Font = new System.Drawing.Font("MS Reference Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.update.ForeColor = System.Drawing.SystemColors.ControlText;
            this.update.Image = global::WindowsFormsApp1.Properties.Resources.refresh_321;
            this.update.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.update.Location = new System.Drawing.Point(0, 150);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(200, 75);
            this.update.TabIndex = 17;
            this.update.Text = "更新";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Top;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("MS Reference Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button5.Image = global::WindowsFormsApp1.Properties.Resources.user_5_32;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(0, 75);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(200, 75);
            this.button5.TabIndex = 16;
            this.button5.Text = "用户列表";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 75);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel3.Location = new System.Drawing.Point(364, 129);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(328, 1);
            this.panel3.TabIndex = 19;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(328, 1);
            this.panel4.TabIndex = 8;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel5.Location = new System.Drawing.Point(364, 186);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(328, 1);
            this.panel5.TabIndex = 21;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(328, 1);
            this.panel6.TabIndex = 8;
            // 
            // txtEmpName
            // 
            this.txtEmpName.BackColor = System.Drawing.SystemColors.Control;
            this.txtEmpName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmpName.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtEmpName.Font = new System.Drawing.Font("MS Reference Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.txtEmpName.Location = new System.Drawing.Point(364, 140);
            this.txtEmpName.Multiline = true;
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Size = new System.Drawing.Size(328, 44);
            this.txtEmpName.TabIndex = 20;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel9.Location = new System.Drawing.Point(364, 296);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(328, 1);
            this.panel9.TabIndex = 25;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(328, 1);
            this.panel10.TabIndex = 8;
            // 
            // txtusername
            // 
            this.txtusername.BackColor = System.Drawing.SystemColors.Control;
            this.txtusername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtusername.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtusername.Font = new System.Drawing.Font("MS Reference Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.txtusername.Location = new System.Drawing.Point(364, 250);
            this.txtusername.Multiline = true;
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(328, 44);
            this.txtusername.TabIndex = 24;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel11.Controls.Add(this.panel12);
            this.panel11.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel11.Location = new System.Drawing.Point(364, 349);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(328, 1);
            this.panel11.TabIndex = 27;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(328, 1);
            this.panel12.TabIndex = 8;
            // 
            // txtpw
            // 
            this.txtpw.BackColor = System.Drawing.SystemColors.Control;
            this.txtpw.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtpw.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtpw.Font = new System.Drawing.Font("MS Reference Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.txtpw.Location = new System.Drawing.Point(364, 303);
            this.txtpw.Multiline = true;
            this.txtpw.Name = "txtpw";
            this.txtpw.Size = new System.Drawing.Size(328, 44);
            this.txtpw.TabIndex = 26;
            this.txtpw.TextChanged += new System.EventHandler(this.txtpw_TextChanged);
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel13.Controls.Add(this.panel14);
            this.panel13.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel13.Location = new System.Drawing.Point(364, 412);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(328, 1);
            this.panel13.TabIndex = 29;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel14.Location = new System.Drawing.Point(0, 0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(328, 1);
            this.panel14.TabIndex = 8;
            // 
            // txtsans
            // 
            this.txtsans.BackColor = System.Drawing.SystemColors.Control;
            this.txtsans.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtsans.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtsans.Font = new System.Drawing.Font("MS Reference Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.txtsans.Location = new System.Drawing.Point(364, 362);
            this.txtsans.Multiline = true;
            this.txtsans.Name = "txtsans";
            this.txtsans.Size = new System.Drawing.Size(328, 44);
            this.txtsans.TabIndex = 28;
            // 
            // admin2CN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(880, 454);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.txtsans);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.txtpw);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.txtusername);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.txtEmpName);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEmpID);
            this.Controls.Add(this.txtEmpdep);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "admin2CN";
            this.Text = "管理员";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox txtEmpdep;
        private System.Windows.Forms.TextBox txtEmpID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Close1;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Create;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txtEmpName;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.TextBox txtpw;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.TextBox txtsans;
    }
}