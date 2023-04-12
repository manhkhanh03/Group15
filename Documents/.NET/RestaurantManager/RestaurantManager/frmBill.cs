using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RestaurantManager
{
    public partial class frmBill : Form
    {
        private string orderID;
        private bool myBool;
        public frmBill(string odID, bool myBool)
        {
            InitializeComponent();
            this.orderID = odID;
            this.myBool = myBool;
        }

        public void setEnable(bool check)
        {
            txtBillId.Enabled = false;
            txtTableNumber.Enabled = false; 
            txtIntoMoney.Enabled = false;
            pkDatePay.Enabled = true;
            cbBookingDate.Enabled = true;
            //dtGridViewFood.Enabled = false;
            cbCustomerName.Enabled = check;
        }

        public void newBill()
        {
            DBServices db = new DBServices();
            int myNumber = Convert.ToInt32(Convert.ToDecimal(db.queryProcedure("Bills", "max(billid) + 1")));
            txtBillId.Text = myNumber < 10 ? "000" + myNumber.ToString() : "00" + myNumber.ToString();
        }

        public void getNameCustomer(bool check)
        {
            string from = "(ORDERS JOIN BOOKINGS ON ORDERS.BOOKID = BOOKINGS.BOOKID) JOIN CUSTOMERS ON CUSTOMERS.CUSTOMERID = BOOKINGS.CUSTOMERID";
            string where = "PAY = N'Chưa thanh toán'";
            string select = "CUSTOMERS.CUSTOMERNAME";
            DBServices db = new DBServices();
            cbCustomerName.DisplayMember = "CUSTOMERNAME";
            cbCustomerName.ValueMember = "CUSTOMERID";
            if (!check)
                cbCustomerName.DataSource = db.querySelect(from, select, where, select);
            else
                cbCustomerName.DataSource = db.querySelect(from, select, $"{where} AND ORDERS.ORDERID= '{this.orderID}'", select);
        }

        public string getOrderID()
        {
            string from = "(ORDERS JOIN BOOKINGS ON ORDERS.BOOKID = BOOKINGS.BOOKID) " +
                "JOIN CUSTOMERS ON CUSTOMERS.CUSTOMERID = BOOKINGS.CUSTOMERID ";
            string where = $"CUSTOMERS.CUSTOMERNAME= N'{cbCustomerName.Text}' and Pay = N'Chưa thanh toán' ";
            string select = "ORDERS.ORDERID";
            DBServices db = new DBServices();

            return db.queryProcedure(from, select, where, select).ToString();
        }

        public int getTableNumber()
        {
            if (this.orderID != null && this.orderID != "")
            {
                string from = "ORDERS JOIN BOOKINGS ON ORDERS.BOOKID = BOOKINGS.BOOKID";
                string where = $"ORDERID = '{this.orderID}'";
                DBServices db = new DBServices();
                return Convert.ToInt32(db.queryProcedure(from, "TABLEID", where, "TABLEID"));
            }
            return 0;
        }

        public void getDate()
        {
            string select = "BOOKINGDATE";
            string from = "ORDERS JOIN BOOKINGS ON ORDERS.BOOKID = BOOKINGS.BOOKID";
            string where = $"ORDERID = '{this.orderID}'";
            DBServices db = new DBServices();
            cbBookingDate.DisplayMember = "BOOKINGDATE";
            cbBookingDate.ValueMember = "BOOKID";
            cbBookingDate.DataSource = db.querySelect(from, select, where, select);
        }

        public string getBookID(string orderId)
        {
            DBServices db = new DBServices();
            string where = $"ORDERS.ORDERID= '{orderId}' ";
            return db.queryProcedure("ORDERS", "BOOKID", where, "BOOKID").ToString();
        }

        public void getFood(string orderId)
        {
            DBServices db = new DBServices();
            string select = "ORDERS.ORDERID, NAMEFOOD, QUANTITY, ORDERS.PRICE";
            string from = "(ORDERS JOIN BOOKINGS ON ORDERS.BOOKID = BOOKINGS.BOOKID) JOIN FOODS ON FOODS.FOODID = ORDERS.FOODID";
            string where = $" ORDERS.BOOKID= '{getBookID(orderId)}'";
            DataTable dt = db.querySelect(from, select, where, select);

            listView1.Columns.AddRange(new[]
            {
                new ColumnHeader { Text = "STT"},
                new ColumnHeader { Text = dt.Columns[0].ColumnName },
                new ColumnHeader { Text = dt.Columns[1].ColumnName, Width = 150 },
                new ColumnHeader { Text = dt.Columns[2].ColumnName },
                new ColumnHeader { Text = dt.Columns[3].ColumnName, Width = 100 }
            });

            int index = 1;
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(index++.ToString());
                item.SubItems.Add(row[0].ToString());
                item.SubItems.Add(row[1].ToString());
                item.SubItems.Add(row[2].ToString());
                item.SubItems.Add(row[3].ToString());
                listView1.Items.Add(item);
            }
        }

        public void getPaymentStaff()
        {
            DBServices db = new DBServices();
            cbPaymentStaff.DisplayMember = "NAMESTAFF";
            cbPaymentStaff.ValueMember = "STAFFID";
            cbPaymentStaff.DataSource = db.querySelect("STAFFS");
        }

        public void handleIntoMoney(string orderId)
        {
            DBServices db = new DBServices();
            string from = "ORDERS";
            string where = $"ORDERS.BOOKID= '{getBookID(orderId)}'";
            string select = "STRING_AGG(CONVERT(VARCHAR, PRICE), ',')";
            string valueReturn = db.queryProcedure(from, select, where).ToString();
            string[] strPrices = valueReturn.Split(',');
            decimal dcmPrices = 0;
            foreach(string key in strPrices)
            {
                dcmPrices += Convert.ToDecimal(key.ToString());
            }
            txtIntoMoney.Text = dcmPrices.ToString();
        }

        public string getCustomerID()
        {
            DBServices db = new DBServices();
            string select = "CustomerID";
            string where = $"CUSTOMERNAME = N'{cbCustomerName.Text}'";
            return db.queryProcedure("CUSTOMERS", select, where).ToString();
        }

        public void addBill()
        {
            dynamic obj = new ExpandoObject();
            obj.billID = txtBillId.Text;
            obj.customerID = getCustomerID();
            obj.staffID = cbPaymentStaff.SelectedValue.ToString();
            obj.bookID = getBookID(this.orderID);
            obj.datePay = pkDatePay.Text;
            obj.money = decimal.Parse(txtIntoMoney.Text);
            DBServices db = new DBServices();
            db.queryInsertInto("BILLS", obj);
        }

        private void frmBill_Load(object sender, EventArgs e)
        {
            newBill();
            getPaymentStaff();
            if(this.myBool)
                getNameCustomer(true);
            else
                getNameCustomer(false);
        }

        private void cbCustomerName_SelectedValueChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView1.Columns.Clear();
            if (!this.myBool)
            {
                setEnable(true);
                this.orderID = getOrderID();
            }else
            {
                setEnable(false);
            }
            handleIntoMoney(this.orderID);
            getFood(this.orderID);
            txtTableNumber.Text = getTableNumber().ToString();
            getDate();
        }

        private void dtGridViewFood_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBillPrinting_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn in hóa đơn không?", "Thông báo!!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                addBill();
                frmDeskManager dm = new frmDeskManager();
                dm.setStatusTable(getTableNumber(), "off");
                setPayBooking();
                this.Close();
            }
            else MessageBox.Show("Hóa đơn đã được hủy!!", "Thông báo!!");
        }

        private void btnEditBill_Click(object sender, EventArgs e)
        {
            this.orderID = getOrderID();
            frmOrders od = new frmOrders(getBookID(this.orderID), false);
            od.Show();
            this.Close();
        }

        public void setPayBooking()
        {
            DBServices db = new DBServices();
            dynamic obj = new ExpandoObject();
            obj.pay = "Đã thanh toán";
            string where = $"BookID = '{getBookID(this.orderID)}'";
            db.queryUpdate("BOOKINGS", obj, where);
        }

        private void pkDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            pkDatePay.MinDate = date;
        }
    }
}
