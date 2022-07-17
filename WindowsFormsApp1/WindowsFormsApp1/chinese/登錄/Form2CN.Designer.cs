
namespace WindowsFormsApp1
{
    partial class Form2CN
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
            this.label1 = new System.Windows.Forms.Label();
            this.ClearFields = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.usernametxt = new System.Windows.Forms.TextBox();
            this.CPw = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.passwordtxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.security_answertxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.newpasswordtxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.newpassword2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 40F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(261, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 71);
            this.label1.TabIndex = 12;
            this.label1.Text = "更改密码";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ClearFields
            // 
            this.ClearFields.AutoSize = true;
            this.ClearFields.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.ClearFields.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClearFields.Location = new System.Drawing.Point(551, 338);
            this.ClearFields.Name = "ClearFields";
            this.ClearFields.Size = new System.Drawing.Size(53, 18);
            this.ClearFields.TabIndex = 23;
            this.ClearFields.Text = "清除字";
            this.ClearFields.Click += new System.EventHandler(this.ClearFields_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(272, 153);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 1);
            this.panel1.TabIndex = 21;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(328, 1);
            this.panel2.TabIndex = 8;
            // 
            // usernametxt
            // 
            this.usernametxt.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.usernametxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usernametxt.Font = new System.Drawing.Font("MS Reference Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.usernametxt.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.usernametxt.Location = new System.Drawing.Point(272, 123);
            this.usernametxt.Multiline = true;
            this.usernametxt.Name = "usernametxt";
            this.usernametxt.Size = new System.Drawing.Size(328, 27);
            this.usernametxt.TabIndex = 20;
            this.usernametxt.TextChanged += new System.EventHandler(this.usernametxt_TextChanged);
            // 
            // CPw
            // 
            this.CPw.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.CPw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CPw.Font = new System.Drawing.Font("MS Reference Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.CPw.ForeColor = System.Drawing.Color.White;
            this.CPw.Location = new System.Drawing.Point(145, 362);
            this.CPw.Name = "CPw";
            this.CPw.Size = new System.Drawing.Size(483, 51);
            this.CPw.TabIndex = 19;
            this.CPw.Text = "更改密码";
            this.CPw.UseVisualStyleBackColor = false;
            this.CPw.Click += new System.EventHandler(this.CPw_Click);
            // 
            // cancel
            // 
            this.cancel.AutoSize = true;
            this.cancel.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.cancel.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.cancel.Location = new System.Drawing.Point(365, 423);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(38, 18);
            this.cancel.TabIndex = 25;
            this.cancel.Text = "取消";
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Location = new System.Drawing.Point(170, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 26);
            this.label3.TabIndex = 26;
            this.label3.Text = "用户名：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS Reference Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label4.Location = new System.Drawing.Point(191, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 26);
            this.label4.TabIndex = 29;
            this.label4.Text = "密码：";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(272, 186);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(328, 1);
            this.panel3.TabIndex = 28;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(328, 1);
            this.panel4.TabIndex = 8;
            // 
            // passwordtxt
            // 
            this.passwordtxt.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.passwordtxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordtxt.Font = new System.Drawing.Font("MS Reference Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.passwordtxt.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.passwordtxt.Location = new System.Drawing.Point(272, 157);
            this.passwordtxt.Multiline = true;
            this.passwordtxt.Name = "passwordtxt";
            this.passwordtxt.Size = new System.Drawing.Size(328, 27);
            this.passwordtxt.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS Reference Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label5.Location = new System.Drawing.Point(141, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 26);
            this.label5.TabIndex = 32;
            this.label5.Text = "安全 答案：";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Location = new System.Drawing.Point(272, 219);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(328, 1);
            this.panel5.TabIndex = 31;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(328, 1);
            this.panel6.TabIndex = 8;
            // 
            // security_answertxt
            // 
            this.security_answertxt.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.security_answertxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.security_answertxt.Font = new System.Drawing.Font("MS Reference Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.security_answertxt.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.security_answertxt.Location = new System.Drawing.Point(272, 190);
            this.security_answertxt.Multiline = true;
            this.security_answertxt.Name = "security_answertxt";
            this.security_answertxt.Size = new System.Drawing.Size(328, 27);
            this.security_answertxt.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS Reference Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label6.Location = new System.Drawing.Point(170, 229);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 26);
            this.label6.TabIndex = 35;
            this.label6.Text = "新密码：";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Location = new System.Drawing.Point(272, 257);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(328, 1);
            this.panel7.TabIndex = 34;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(328, 1);
            this.panel8.TabIndex = 8;
            // 
            // newpasswordtxt
            // 
            this.newpasswordtxt.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.newpasswordtxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.newpasswordtxt.Font = new System.Drawing.Font("MS Reference Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.newpasswordtxt.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.newpasswordtxt.Location = new System.Drawing.Point(272, 228);
            this.newpasswordtxt.Multiline = true;
            this.newpasswordtxt.Name = "newpasswordtxt";
            this.newpasswordtxt.Size = new System.Drawing.Size(328, 27);
            this.newpasswordtxt.TabIndex = 33;
            this.newpasswordtxt.TextChanged += new System.EventHandler(this.newpasswordtxt_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(118, 290);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 20);
            this.label2.TabIndex = 38;
            this.label2.Text = "再次输入新密码：";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Location = new System.Drawing.Point(269, 312);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(328, 1);
            this.panel9.TabIndex = 37;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(328, 1);
            this.panel10.TabIndex = 8;
            // 
            // newpassword2
            // 
            this.newpassword2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.newpassword2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.newpassword2.Font = new System.Drawing.Font("MS Reference Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.newpassword2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.newpassword2.Location = new System.Drawing.Point(269, 283);
            this.newpassword2.Multiline = true;
            this.newpassword2.Name = "newpassword2";
            this.newpassword2.Size = new System.Drawing.Size(328, 27);
            this.newpassword2.TabIndex = 36;
            this.newpassword2.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label7.Location = new System.Drawing.Point(461, 262);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 18);
            this.label7.TabIndex = 39;
            this.label7.Text = "密码强度：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label8.Location = new System.Drawing.Point(550, 262);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 18);
            this.label8.TabIndex = 40;
            this.label8.Text = "Null";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // Form2CN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 458);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.newpassword2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.newpasswordtxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.security_answertxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.passwordtxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ClearFields);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.usernametxt);
            this.Controls.Add(this.CPw);
            this.Controls.Add(this.label1);
            this.Name = "Form2CN";
            this.Text = "更改密码";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ClearFields;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox usernametxt;
        private System.Windows.Forms.Button CPw;
        private System.Windows.Forms.Label cancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox passwordtxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox security_answertxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox newpasswordtxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.TextBox newpassword2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}