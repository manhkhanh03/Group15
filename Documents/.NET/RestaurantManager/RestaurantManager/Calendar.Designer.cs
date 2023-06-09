﻿namespace RestaurantManager
{
    partial class frmCalendar
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCalendarID = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.cbStaffID = new System.Windows.Forms.ComboBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.rbCasang = new System.Windows.Forms.RadioButton();
            this.rbCachieu = new System.Windows.Forms.RadioButton();
            this.rbCatoi = new System.Windows.Forms.RadioButton();
            this.dgvCalendars = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalendars)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CalendarID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "StaffID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 161);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 220);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Shift:";
            // 
            // txtCalendarID
            // 
            this.txtCalendarID.Location = new System.Drawing.Point(159, 40);
            this.txtCalendarID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCalendarID.Name = "txtCalendarID";
            this.txtCalendarID.Size = new System.Drawing.Size(159, 20);
            this.txtCalendarID.TabIndex = 4;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::RestaurantManager.Properties.Resources.rsz_icons8_exit_sign_64;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(981, 384);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(97, 41);
            this.btnExit.TabIndex = 60;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::RestaurantManager.Properties.Resources.rsz_icons8_remove_641;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(806, 385);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(97, 41);
            this.btnDelete.TabIndex = 59;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = global::RestaurantManager.Properties.Resources.rsz_icons8_edit_row_64;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(624, 387);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(97, 39);
            this.btnEdit.TabIndex = 58;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::RestaurantManager.Properties.Resources.rsz_icons8_close_64;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(430, 385);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 39);
            this.btnCancel.TabIndex = 57;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::RestaurantManager.Properties.Resources.rsz_icons8_save_64;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(256, 385);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 38);
            this.btnSave.TabIndex = 56;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.Image = global::RestaurantManager.Properties.Resources.rsz_icons8_add_folder_64__1_;
            this.btnAddNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNew.Location = new System.Drawing.Point(111, 383);
            this.btnAddNew.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(97, 41);
            this.btnAddNew.TabIndex = 55;
            this.btnAddNew.Text = "AddNew";
            this.btnAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // cbStaffID
            // 
            this.cbStaffID.FormattingEnabled = true;
            this.cbStaffID.Location = new System.Drawing.Point(159, 97);
            this.cbStaffID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbStaffID.Name = "cbStaffID";
            this.cbStaffID.Size = new System.Drawing.Size(158, 21);
            this.cbStaffID.TabIndex = 61;
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(159, 161);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(157, 20);
            this.dtpDate.TabIndex = 62;
            // 
            // rbCasang
            // 
            this.rbCasang.AutoSize = true;
            this.rbCasang.Location = new System.Drawing.Point(160, 219);
            this.rbCasang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbCasang.Name = "rbCasang";
            this.rbCasang.Size = new System.Drawing.Size(64, 17);
            this.rbCasang.TabIndex = 63;
            this.rbCasang.TabStop = true;
            this.rbCasang.Text = "Ca sáng";
            this.rbCasang.UseVisualStyleBackColor = true;
            // 
            // rbCachieu
            // 
            this.rbCachieu.AutoSize = true;
            this.rbCachieu.Location = new System.Drawing.Point(230, 219);
            this.rbCachieu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbCachieu.Name = "rbCachieu";
            this.rbCachieu.Size = new System.Drawing.Size(67, 17);
            this.rbCachieu.TabIndex = 64;
            this.rbCachieu.TabStop = true;
            this.rbCachieu.Text = "Ca chiều";
            this.rbCachieu.UseVisualStyleBackColor = true;
            // 
            // rbCatoi
            // 
            this.rbCatoi.AutoSize = true;
            this.rbCatoi.Location = new System.Drawing.Point(306, 220);
            this.rbCatoi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbCatoi.Name = "rbCatoi";
            this.rbCatoi.Size = new System.Drawing.Size(52, 17);
            this.rbCatoi.TabIndex = 65;
            this.rbCatoi.TabStop = true;
            this.rbCatoi.Text = "Ca tối";
            this.rbCatoi.UseVisualStyleBackColor = true;
            // 
            // dgvCalendars
            // 
            this.dgvCalendars.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvCalendars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCalendars.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvCalendars.Location = new System.Drawing.Point(575, 42);
            this.dgvCalendars.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvCalendars.Name = "dgvCalendars";
            this.dgvCalendars.RowHeadersWidth = 51;
            this.dgvCalendars.RowTemplate.Height = 24;
            this.dgvCalendars.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCalendars.Size = new System.Drawing.Size(465, 289);
            this.dgvCalendars.TabIndex = 66;
            this.dgvCalendars.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCalendar_CellEnter);
            // 
            // frmCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 494);
            this.Controls.Add(this.dgvCalendars);
            this.Controls.Add(this.rbCatoi);
            this.Controls.Add(this.rbCachieu);
            this.Controls.Add(this.rbCasang);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.cbStaffID);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.txtCalendarID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmCalendar";
            this.Text = "Calendar";
            this.Load += new System.EventHandler(this.Calendar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalendars)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCalendarID;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.ComboBox cbStaffID;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.RadioButton rbCasang;
        private System.Windows.Forms.RadioButton rbCachieu;
        private System.Windows.Forms.RadioButton rbCatoi;
        private System.Windows.Forms.DataGridView dgvCalendars;
    }
}