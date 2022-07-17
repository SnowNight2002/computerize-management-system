
namespace WindowsFormsApp1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.CPw = new System.Windows.Forms.Button();
            this.usernametxt = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LOGIN = new System.Windows.Forms.Button();
            this.ClearFields = new System.Windows.Forms.Label();
            this.userpasswordtxt = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.eye = new System.Windows.Forms.Button();
            this.noeye = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NAMETT = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // CPw
            // 
            this.CPw.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.CPw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CPw.Font = new System.Drawing.Font("MS Reference Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.CPw.ForeColor = System.Drawing.Color.White;
            this.CPw.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CPw.Location = new System.Drawing.Point(287, 330);
            this.CPw.Name = "CPw";
            this.CPw.Size = new System.Drawing.Size(483, 51);
            this.CPw.TabIndex = 3;
            this.CPw.Text = "Change Password";
            this.CPw.UseVisualStyleBackColor = false;
            this.CPw.Click += new System.EventHandler(this.CPw_Click);
            // 
            // usernametxt
            // 
            this.usernametxt.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.usernametxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usernametxt.Font = new System.Drawing.Font("MS Reference Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.usernametxt.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.usernametxt.Location = new System.Drawing.Point(349, 192);
            this.usernametxt.Multiline = true;
            this.usernametxt.Name = "usernametxt";
            this.usernametxt.Size = new System.Drawing.Size(276, 44);
            this.usernametxt.TabIndex = 6;
            this.usernametxt.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(297, 238);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 1);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(328, 1);
            this.panel2.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel3.Location = new System.Drawing.Point(297, 307);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(328, 1);
            this.panel3.TabIndex = 8;
            // 
            // LOGIN
            // 
            this.LOGIN.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.LOGIN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LOGIN.Font = new System.Drawing.Font("MS Reference Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LOGIN.ForeColor = System.Drawing.Color.White;
            this.LOGIN.Location = new System.Drawing.Point(287, 387);
            this.LOGIN.Name = "LOGIN";
            this.LOGIN.Size = new System.Drawing.Size(483, 51);
            this.LOGIN.TabIndex = 10;
            this.LOGIN.Text = "Log In";
            this.LOGIN.UseVisualStyleBackColor = false;
            this.LOGIN.Click += new System.EventHandler(this.button2_Click);
            // 
            // ClearFields
            // 
            this.ClearFields.AutoSize = true;
            this.ClearFields.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.ClearFields.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClearFields.Location = new System.Drawing.Point(683, 307);
            this.ClearFields.Name = "ClearFields";
            this.ClearFields.Size = new System.Drawing.Size(99, 18);
            this.ClearFields.TabIndex = 11;
            this.ClearFields.Text = "Clear Fields";
            this.ClearFields.Click += new System.EventHandler(this.label2_Click);
            // 
            // userpasswordtxt
            // 
            this.userpasswordtxt.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.userpasswordtxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.userpasswordtxt.Font = new System.Drawing.Font("MS Reference Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.userpasswordtxt.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.userpasswordtxt.Location = new System.Drawing.Point(349, 260);
            this.userpasswordtxt.Multiline = true;
            this.userpasswordtxt.Name = "userpasswordtxt";
            this.userpasswordtxt.PasswordChar = '*';
            this.userpasswordtxt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.userpasswordtxt.Size = new System.Drawing.Size(276, 46);
            this.userpasswordtxt.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button1.Location = new System.Drawing.Point(567, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 39);
            this.button1.TabIndex = 13;
            this.button1.Text = "English";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button2.Location = new System.Drawing.Point(653, 14);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 39);
            this.button2.TabIndex = 14;
            this.button2.Text = "中文";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.GhostWhite;
            this.panel4.Controls.Add(this.pictureBox3);
            this.panel4.Location = new System.Drawing.Point(-7, -4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(267, 468);
            this.panel4.TabIndex = 17;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Image = global::WindowsFormsApp1.Properties.Resources._70b95afee6134704837c80a1ed784d08__1_;
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(267, 468);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // eye
            // 
            this.eye.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.eye.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.eye.Cursor = System.Windows.Forms.Cursors.Default;
            this.eye.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eye.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.eye.Image = global::WindowsFormsApp1.Properties.Resources.eye_32;
            this.eye.Location = new System.Drawing.Point(631, 271);
            this.eye.Name = "eye";
            this.eye.Size = new System.Drawing.Size(41, 30);
            this.eye.TabIndex = 16;
            this.eye.UseVisualStyleBackColor = false;
            this.eye.Click += new System.EventHandler(this.eye_Click);
            // 
            // noeye
            // 
            this.noeye.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.noeye.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.noeye.Cursor = System.Windows.Forms.Cursors.Default;
            this.noeye.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.noeye.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.noeye.Image = global::WindowsFormsApp1.Properties.Resources.noeye_32;
            this.noeye.Location = new System.Drawing.Point(631, 270);
            this.noeye.Name = "noeye";
            this.noeye.Size = new System.Drawing.Size(41, 30);
            this.noeye.TabIndex = 15;
            this.noeye.UseVisualStyleBackColor = false;
            this.noeye.Click += new System.EventHandler(this.noeye_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(297, 260);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(46, 41);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(297, 188);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft New Tai Lue", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(266, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 63);
            this.label1.TabIndex = 18;
            this.label1.Text = "Welcome";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NAMETT
            // 
            this.NAMETT.AutoSize = true;
            this.NAMETT.Font = new System.Drawing.Font("Microsoft New Tai Lue", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NAMETT.ForeColor = System.Drawing.SystemColors.Highlight;
            this.NAMETT.Location = new System.Drawing.Point(497, 77);
            this.NAMETT.Name = "NAMETT";
            this.NAMETT.Size = new System.Drawing.Size(66, 63);
            this.NAMETT.TabIndex = 19;
            this.NAMETT.Text = "...";
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button3.Image = global::WindowsFormsApp1.Properties.Resources.x_mark_5_32;
            this.button3.Location = new System.Drawing.Point(744, 8);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(44, 43);
            this.button3.TabIndex = 20;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.NAMETT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.eye);
            this.Controls.Add(this.noeye);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.userpasswordtxt);
            this.Controls.Add(this.ClearFields);
            this.Controls.Add(this.LOGIN);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.usernametxt);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.CPw);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CPw;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox usernametxt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button LOGIN;
        private System.Windows.Forms.Label ClearFields;
        private System.Windows.Forms.TextBox userpasswordtxt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button eye;
        private System.Windows.Forms.Button noeye;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label NAMETT;
        private System.Windows.Forms.Button button3;
    }
}

