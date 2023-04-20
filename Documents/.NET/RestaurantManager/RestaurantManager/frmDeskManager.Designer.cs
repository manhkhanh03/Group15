namespace RestaurantManager
{
    partial class frmDeskManager
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBookID = new System.Windows.Forms.TextBox();
            this.cbCustomerID = new System.Windows.Forms.ComboBox();
            this.cbTableID = new System.Windows.Forms.ComboBox();
            this.btnStatus = new System.Windows.Forms.Button();
            this.cbBookingStaff = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCancelTable = new System.Windows.Forms.Button();
            this.txtPay = new System.Windows.Forms.TextBox();
            this.pkDate = new System.Windows.Forms.DateTimePicker();
            this.pkTime = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridView1.Location = new System.Drawing.Point(641, 43);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(934, 674);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNew.Location = new System.Drawing.Point(59, 590);
            this.btnAddNew.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(133, 59);
            this.btnAddNew.TabIndex = 1;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Location = new System.Drawing.Point(273, 590);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 59);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Location = new System.Drawing.Point(477, 590);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(133, 59);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Location = new System.Drawing.Point(477, 657);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(133, 59);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Location = new System.Drawing.Point(273, 657);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(133, 59);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Location = new System.Drawing.Point(59, 657);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(133, 59);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 81);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "BookID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 192);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Customer Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 331);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Booking Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(73, 262);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "TableID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(73, 400);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Time";
            // 
            // txtBookID
            // 
            this.txtBookID.Location = new System.Drawing.Point(215, 73);
            this.txtBookID.Margin = new System.Windows.Forms.Padding(4);
            this.txtBookID.Name = "txtBookID";
            this.txtBookID.Size = new System.Drawing.Size(395, 22);
            this.txtBookID.TabIndex = 12;
            // 
            // cbCustomerID
            // 
            this.cbCustomerID.FormattingEnabled = true;
            this.cbCustomerID.Location = new System.Drawing.Point(215, 188);
            this.cbCustomerID.Name = "cbCustomerID";
            this.cbCustomerID.Size = new System.Drawing.Size(394, 24);
            this.cbCustomerID.TabIndex = 17;
            // 
            // cbTableID
            // 
            this.cbTableID.FormattingEnabled = true;
            this.cbTableID.Location = new System.Drawing.Point(215, 254);
            this.cbTableID.Name = "cbTableID";
            this.cbTableID.Size = new System.Drawing.Size(394, 24);
            this.cbTableID.TabIndex = 18;
            // 
            // btnStatus
            // 
            this.btnStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStatus.Location = new System.Drawing.Point(371, 523);
            this.btnStatus.Margin = new System.Windows.Forms.Padding(4);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(189, 59);
            this.btnStatus.TabIndex = 19;
            this.btnStatus.Text = "Kiểm tra trạng thái bàn";
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // cbBookingStaff
            // 
            this.cbBookingStaff.FormattingEnabled = true;
            this.cbBookingStaff.Location = new System.Drawing.Point(215, 131);
            this.cbBookingStaff.Name = "cbBookingStaff";
            this.cbBookingStaff.Size = new System.Drawing.Size(394, 24);
            this.cbBookingStaff.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(73, 135);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 16);
            this.label6.TabIndex = 20;
            this.label6.Text = "Tên nhân viên";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(73, 463);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 22;
            this.label7.Text = "Thanh Toán";
            // 
            // btnCancelTable
            // 
            this.btnCancelTable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelTable.Location = new System.Drawing.Point(120, 523);
            this.btnCancelTable.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelTable.Name = "btnCancelTable";
            this.btnCancelTable.Size = new System.Drawing.Size(189, 59);
            this.btnCancelTable.TabIndex = 24;
            this.btnCancelTable.Text = "Hủy đặt bàn";
            this.btnCancelTable.UseVisualStyleBackColor = true;
            this.btnCancelTable.Click += new System.EventHandler(this.btnCancelTable_Click);
            // 
            // txtPay
            // 
            this.txtPay.Location = new System.Drawing.Point(215, 457);
            this.txtPay.Margin = new System.Windows.Forms.Padding(4);
            this.txtPay.Name = "txtPay";
            this.txtPay.Size = new System.Drawing.Size(395, 22);
            this.txtPay.TabIndex = 25;
            // 
            // pkDate
            // 
            this.pkDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.pkDate.Location = new System.Drawing.Point(217, 325);
            this.pkDate.MaxDate = new System.DateTime(2024, 12, 31, 0, 0, 0, 0);
            this.pkDate.MinDate = new System.DateTime(2023, 1, 1, 0, 0, 0, 0);
            this.pkDate.Name = "pkDate";
            this.pkDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pkDate.Size = new System.Drawing.Size(393, 22);
            this.pkDate.TabIndex = 26;
            this.pkDate.Value = new System.DateTime(2023, 3, 28, 8, 40, 4, 0);
            this.pkDate.ValueChanged += new System.EventHandler(this.pkDate_ValueChanged);
            // 
            // pkTime
            // 
            this.pkTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.pkTime.Location = new System.Drawing.Point(217, 394);
            this.pkTime.MaxDate = new System.DateTime(2024, 12, 31, 0, 0, 0, 0);
            this.pkTime.MinDate = new System.DateTime(2023, 1, 1, 0, 0, 0, 0);
            this.pkTime.Name = "pkTime";
            this.pkTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pkTime.Size = new System.Drawing.Size(393, 22);
            this.pkTime.TabIndex = 27;
            this.pkTime.Value = new System.DateTime(2023, 3, 28, 8, 40, 4, 0);
            // 
            // frmDeskManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1622, 752);
            this.Controls.Add(this.pkTime);
            this.Controls.Add(this.pkDate);
            this.Controls.Add(this.txtPay);
            this.Controls.Add(this.btnCancelTable);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbBookingStaff);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnStatus);
            this.Controls.Add(this.cbTableID);
            this.Controls.Add(this.cbCustomerID);
            this.Controls.Add(this.txtBookID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmDeskManager";
            this.Text = "Quản lý đặt bàn";
            this.Load += new System.EventHandler(this.frmDeskManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBookID;
        private System.Windows.Forms.ComboBox cbCustomerID;
        private System.Windows.Forms.ComboBox cbTableID;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.ComboBox cbBookingStaff;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCancelTable;
        private System.Windows.Forms.TextBox txtPay;
        private System.Windows.Forms.DateTimePicker pkDate;
        private System.Windows.Forms.DateTimePicker pkTime;
    }
}