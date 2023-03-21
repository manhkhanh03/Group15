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
            this.dtGridViewFood = new System.Windows.Forms.DataGridView();
            this.btnBillPrinting = new System.Windows.Forms.Button();
            this.btnEditBill = new System.Windows.Forms.Button();
            this.cbBookingDate = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridViewFood)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(87, 127);
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
            this.label3.Location = new System.Drawing.Point(87, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Bàn số";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(87, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ngày thanh toán";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(87, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Tên khách hàng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(87, 622);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Thành tiền";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(87, 373);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "Món ăn";
            // 
            // txtBillId
            // 
            this.txtBillId.Location = new System.Drawing.Point(224, 121);
            this.txtBillId.Name = "txtBillId";
            this.txtBillId.Size = new System.Drawing.Size(339, 22);
            this.txtBillId.TabIndex = 7;
            // 
            // txtIntoMoney
            // 
            this.txtIntoMoney.Location = new System.Drawing.Point(222, 616);
            this.txtIntoMoney.Name = "txtIntoMoney";
            this.txtIntoMoney.Size = new System.Drawing.Size(341, 22);
            this.txtIntoMoney.TabIndex = 10;
            // 
            // cbCustomerName
            // 
            this.cbCustomerName.FormattingEnabled = true;
            this.cbCustomerName.Location = new System.Drawing.Point(225, 168);
            this.cbCustomerName.Name = "cbCustomerName";
            this.cbCustomerName.Size = new System.Drawing.Size(338, 24);
            this.cbCustomerName.TabIndex = 14;
            this.cbCustomerName.SelectedValueChanged += new System.EventHandler(this.cbCustomerName_SelectedValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(86, 325);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "Ngày đặt";
            // 
            // txtTableNumber
            // 
            this.txtTableNumber.Location = new System.Drawing.Point(225, 219);
            this.txtTableNumber.Name = "txtTableNumber";
            this.txtTableNumber.Size = new System.Drawing.Size(339, 22);
            this.txtTableNumber.TabIndex = 16;
            // 
            // txtDatePay
            // 
            this.txtDatePay.Location = new System.Drawing.Point(224, 264);
            this.txtDatePay.Name = "txtDatePay";
            this.txtDatePay.Size = new System.Drawing.Size(339, 22);
            this.txtDatePay.TabIndex = 18;
            // 
            // dtGridViewFood
            // 
            this.dtGridViewFood.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtGridViewFood.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridViewFood.Location = new System.Drawing.Point(222, 373);
            this.dtGridViewFood.Name = "dtGridViewFood";
            this.dtGridViewFood.RowHeadersWidth = 51;
            this.dtGridViewFood.RowTemplate.Height = 24;
            this.dtGridViewFood.Size = new System.Drawing.Size(342, 219);
            this.dtGridViewFood.TabIndex = 19;
            this.dtGridViewFood.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridViewFood_CellEnter);
            // 
            // btnBillPrinting
            // 
            this.btnBillPrinting.Location = new System.Drawing.Point(508, 695);
            this.btnBillPrinting.Name = "btnBillPrinting";
            this.btnBillPrinting.Size = new System.Drawing.Size(127, 53);
            this.btnBillPrinting.TabIndex = 20;
            this.btnBillPrinting.Text = "In Bill";
            this.btnBillPrinting.UseVisualStyleBackColor = true;
            this.btnBillPrinting.Click += new System.EventHandler(this.btnBillPrinting_Click);
            // 
            // btnEditBill
            // 
            this.btnEditBill.Location = new System.Drawing.Point(349, 695);
            this.btnEditBill.Name = "btnEditBill";
            this.btnEditBill.Size = new System.Drawing.Size(127, 53);
            this.btnEditBill.TabIndex = 21;
            this.btnEditBill.Text = "Sửa hóa đơn";
            this.btnEditBill.UseVisualStyleBackColor = true;
            // 
            // cbBookingDate
            // 
            this.cbBookingDate.FormattingEnabled = true;
            this.cbBookingDate.Location = new System.Drawing.Point(226, 317);
            this.cbBookingDate.Name = "cbBookingDate";
            this.cbBookingDate.Size = new System.Drawing.Size(338, 24);
            this.cbBookingDate.TabIndex = 22;
            // 
            // frmBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 785);
            this.Controls.Add(this.cbBookingDate);
            this.Controls.Add(this.btnEditBill);
            this.Controls.Add(this.btnBillPrinting);
            this.Controls.Add(this.dtGridViewFood);
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
            ((System.ComponentModel.ISupportInitialize)(this.dtGridViewFood)).EndInit();
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
        private System.Windows.Forms.DataGridView dtGridViewFood;
        private System.Windows.Forms.Button btnBillPrinting;
        private System.Windows.Forms.Button btnEditBill;
        private System.Windows.Forms.ComboBox cbBookingDate;
    }
}