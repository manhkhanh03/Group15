namespace RestaurantManager
{
    partial class frmBill
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
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBillId = new System.Windows.Forms.TextBox();
            this.txtIntoMoney = new System.Windows.Forms.TextBox();
            this.cbCustomerName = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTableNumber = new System.Windows.Forms.TextBox();
            this.txtDatePay = new System.Windows.Forms.TextBox();
            this.btnBillPrinting = new System.Windows.Forms.Button();
            this.btnEditBill = new System.Windows.Forms.Button();
            this.cbBookingDate = new System.Windows.Forms.ComboBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.cbPaymentStaff = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã hóa đơn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(234, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "CẢM ƠN QUÝ KHÁCH";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(54, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Bàn số";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(55, 329);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ngày thanh toán";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(54, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Tên khách hàng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(55, 681);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Thành tiền";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(55, 432);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "Món ăn";
            // 
            // txtBillId
            // 
            this.txtBillId.Location = new System.Drawing.Point(180, 121);
            this.txtBillId.Name = "txtBillId";
            this.txtBillId.Size = new System.Drawing.Size(478, 22);
            this.txtBillId.TabIndex = 7;
            // 
            // txtIntoMoney
            // 
            this.txtIntoMoney.Location = new System.Drawing.Point(181, 675);
            this.txtIntoMoney.Name = "txtIntoMoney";
            this.txtIntoMoney.Size = new System.Drawing.Size(478, 22);
            this.txtIntoMoney.TabIndex = 10;
            this.txtIntoMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbCustomerName
            // 
            this.cbCustomerName.FormattingEnabled = true;
            this.cbCustomerName.Location = new System.Drawing.Point(181, 168);
            this.cbCustomerName.Name = "cbCustomerName";
            this.cbCustomerName.Size = new System.Drawing.Size(477, 24);
            this.cbCustomerName.TabIndex = 14;
            this.cbCustomerName.SelectedValueChanged += new System.EventHandler(this.cbCustomerName_SelectedValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(54, 384);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "Ngày đặt";
            // 
            // txtTableNumber
            // 
            this.txtTableNumber.Location = new System.Drawing.Point(181, 219);
            this.txtTableNumber.Name = "txtTableNumber";
            this.txtTableNumber.Size = new System.Drawing.Size(478, 22);
            this.txtTableNumber.TabIndex = 16;
            // 
            // txtDatePay
            // 
            this.txtDatePay.Location = new System.Drawing.Point(181, 323);
            this.txtDatePay.Name = "txtDatePay";
            this.txtDatePay.Size = new System.Drawing.Size(478, 22);
            this.txtDatePay.TabIndex = 18;
            // 
            // btnBillPrinting
            // 
            this.btnBillPrinting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBillPrinting.Location = new System.Drawing.Point(531, 728);
            this.btnBillPrinting.Name = "btnBillPrinting";
            this.btnBillPrinting.Size = new System.Drawing.Size(127, 53);
            this.btnBillPrinting.TabIndex = 20;
            this.btnBillPrinting.Text = "In Bill";
            this.btnBillPrinting.UseVisualStyleBackColor = true;
            this.btnBillPrinting.Click += new System.EventHandler(this.btnBillPrinting_Click);
            // 
            // btnEditBill
            // 
            this.btnEditBill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditBill.Location = new System.Drawing.Point(372, 728);
            this.btnEditBill.Name = "btnEditBill";
            this.btnEditBill.Size = new System.Drawing.Size(127, 53);
            this.btnEditBill.TabIndex = 21;
            this.btnEditBill.Text = "Sửa hóa đơn";
            this.btnEditBill.UseVisualStyleBackColor = true;
            this.btnEditBill.Click += new System.EventHandler(this.btnEditBill_Click);
            // 
            // cbBookingDate
            // 
            this.cbBookingDate.FormattingEnabled = true;
            this.cbBookingDate.Location = new System.Drawing.Point(181, 376);
            this.cbBookingDate.Name = "cbBookingDate";
            this.cbBookingDate.Size = new System.Drawing.Size(479, 24);
            this.cbBookingDate.TabIndex = 22;
            // 
            // listView1
            // 
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(58, 474);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(601, 172);
            this.listView1.TabIndex = 23;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // cbPaymentStaff
            // 
            this.cbPaymentStaff.FormattingEnabled = true;
            this.cbPaymentStaff.Location = new System.Drawing.Point(180, 269);
            this.cbPaymentStaff.Name = "cbPaymentStaff";
            this.cbPaymentStaff.Size = new System.Drawing.Size(477, 24);
            this.cbPaymentStaff.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(53, 277);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 16);
            this.label9.TabIndex = 24;
            this.label9.Text = "NV thanh toán";
            // 
            // frmBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 803);
            this.Controls.Add(this.cbPaymentStaff);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.cbBookingDate);
            this.Controls.Add(this.btnEditBill);
            this.Controls.Add(this.btnBillPrinting);
            this.Controls.Add(this.txtDatePay);
            this.Controls.Add(this.txtTableNumber);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbCustomerName);
            this.Controls.Add(this.txtIntoMoney);
            this.Controls.Add(this.txtBillId);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmBill";
            this.Text = "Hóa đơn";
            this.Load += new System.EventHandler(this.frmBill_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBillId;
        private System.Windows.Forms.TextBox txtIntoMoney;
        private System.Windows.Forms.ComboBox cbCustomerName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTableNumber;
        private System.Windows.Forms.TextBox txtDatePay;
        private System.Windows.Forms.Button btnBillPrinting;
        private System.Windows.Forms.Button btnEditBill;
        private System.Windows.Forms.ComboBox cbBookingDate;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ComboBox cbPaymentStaff;
        private System.Windows.Forms.Label label9;
    }
}