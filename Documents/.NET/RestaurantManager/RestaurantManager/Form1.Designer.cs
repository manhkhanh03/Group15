namespace RestaurantManager
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
            this.btnTable = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFinancialManagement = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTable
            // 
            this.btnTable.Location = new System.Drawing.Point(107, 200);
            this.btnTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTable.Name = "btnTable";
            this.btnTable.Size = new System.Drawing.Size(300, 47);
            this.btnTable.TabIndex = 0;
            this.btnTable.Text = "Quản lý bàn";
            this.btnTable.UseVisualStyleBackColor = true;
            this.btnTable.Click += new System.EventHandler(this.btnTable_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(227, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(462, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "HỆ THỐNG QUẢN LÝ NHÀ HÀNG / CAFE";
            // 
            // btnFinancialManagement
            // 
            this.btnFinancialManagement.Location = new System.Drawing.Point(509, 200);
            this.btnFinancialManagement.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFinancialManagement.Name = "btnFinancialManagement";
            this.btnFinancialManagement.Size = new System.Drawing.Size(300, 47);
            this.btnFinancialManagement.TabIndex = 2;
            this.btnFinancialManagement.Text = "Quản lý tài chính";
            this.btnFinancialManagement.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 616);
            this.Controls.Add(this.btnFinancialManagement);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTable);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Quản lý nhà hàng";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFinancialManagement;
    }
}

