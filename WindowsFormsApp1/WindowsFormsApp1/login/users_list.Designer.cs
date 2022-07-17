
namespace WindowsFormsApp1
{
    partial class users_list
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
            this.User_list_View = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.User_list_View)).BeginInit();
            this.SuspendLayout();
            // 
            // User_list_View
            // 
            this.User_list_View.BackgroundColor = System.Drawing.Color.White;
            this.User_list_View.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.User_list_View.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.User_list_View.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.User_list_View.Location = new System.Drawing.Point(51, 75);
            this.User_list_View.Margin = new System.Windows.Forms.Padding(2);
            this.User_list_View.Name = "User_list_View";
            this.User_list_View.RowTemplate.Height = 24;
            this.User_list_View.Size = new System.Drawing.Size(712, 364);
            this.User_list_View.TabIndex = 3;
            this.User_list_View.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gadugi", 40F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(278, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 65);
            this.label1.TabIndex = 4;
            this.label1.Text = "users list";
            // 
            // users_list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.User_list_View);
            this.Name = "users_list";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "users list";
            this.Load += new System.EventHandler(this.users_list_Load);
            ((System.ComponentModel.ISupportInitialize)(this.User_list_View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView User_list_View;
        private System.Windows.Forms.Label label1;
    }
}