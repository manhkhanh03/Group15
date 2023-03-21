using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            txtDatePay.Enabled = true;
            cbBookingDate.Enabled = true;
            //dtGridViewFood.Enabled = false;
            cbCustomerName.Enabled = check;
        }

        public void newBill()
        {
            string sql = "declare @id int " +
                "select @id = substring(max(billid), 2, 2) + 1 from bills " +
                "select @id";
            frmDeskManager dm = new frmDeskManager();
            txtBillId.Text = "B" + dm.getValue(sql, "1");
        }

        public void getNameCustomer(bool check)
        {
            string sql;
            if(!check)
            {
                sql = "SELECT CustomerName from(orders join Booking on Orders.BookID = Booking.BookID)" +
                "join Customers on Customers.CustomerID = Booking.CustomerID " +
                "group by CustomerName";
            }
            else
            {
                sql = "SELECT CustomerName from(orders join Booking on Orders.BookID = Booking.BookID)" +
                "join Customers on Customers.CustomerID = Booking.CustomerID " +
                $"Where Orders.OrderID = '{this.orderID}' " +
                "group by CustomerName";
            }
            
            DBServices db = new DBServices();
            cbCustomerName.DisplayMember = "CustomerName";
            cbCustomerName.ValueMember = "CustomerID";
            cbCustomerName.DataSource= db.getData(sql);
        }

        public string getOrderID()
        {
            string sql = "declare @id varchar(10) " +
                "SELECT @id = Orders.OrderID from(orders join Booking on Orders.BookID = Booking.BookID)" +
                "join Customers on Customers.CustomerID = Booking.CustomerID " +
                $"Where Customers.CustomerName = N'{cbCustomerName.Text}' " +
                "group by Orders.OrderID " +
                "select @id";
            frmDeskManager dm = new frmDeskManager();
            return dm.getValue(sql, "");
        }

        public void getTableNumber()
        {
            if (this.orderID != null && this.orderID != "")
            {
                string sql = "declare @tableNumber int " +
                    "SELECT TableID from orders join Booking on Orders.BookID = Booking.BookID " +
                    $"Where OrderID = '{this.orderID}' " +
                    "group by TableID " +
                    "select @tablenumber";
                frmDeskManager dm = new frmDeskManager();
                txtTableNumber.Text = dm.getValue(sql, "");
            }
        }

        public void getDate()
        {
            string sql = "SELECT bookingdate from orders join Booking on Orders.BookID = Booking.BookID " +
                    $"Where OrderID = '{this.orderID}' " +
                    "group by bookingdate ";
            DBServices db = new DBServices();
            cbBookingDate.DisplayMember = "BookingDate";
            cbBookingDate.ValueMember = "BookingDate";
            cbBookingDate.DataSource = db.getData(sql);
        }

        public string getBookID(string orderId)
        {
            string sql = "declare @bookid varchar(10) "+
                "SELECT @bookid = BookID " +
                    "from Orders " +
                    $"where Orders.OrderID = '{orderId}' " +
                    "group by BookId " +
                    "select @bookid";
            frmDeskManager dm = new frmDeskManager();
            return dm.getValue(sql, "");
        }

        public void getFood(string orderId)
        {
            string sql = "SELECT Orders.OrderID, NameDish, Quantity, orders.Price " +
                    "from(orders join Booking on Orders.BookID = Booking.BookID) join Dishs on Dishs.DishID = Orders.DishID " +
                    $"where Orders.BookID = '{getBookID(orderId)}' " +
                    "group by Orders.OrderID, NameDish, Quantity, orders.Price";
            DBServices db = new DBServices();
            dtGridViewFood.DataSource= db.getData(sql);
        }

        public void handleIntoMoney(string orderId)
        {
            string sql = "DECLARE @Prices VARCHAR(MAX) " +
                    "SELECT @Prices = COALESCE(@Prices + ',', '') + CONVERT(VARCHAR, price) " +
                    "FROM orders " +
                    $"Where Orders.BookID = '{getBookID(orderId)}' " +
                    "Select @Prices";
            frmDeskManager dm = new frmDeskManager();
            string valueReturn = dm.getValue(sql, "0");
            string[] strPrices = valueReturn.Split(',');
            decimal dcmPrices = 0;
            foreach(string key in strPrices)
            {
                dcmPrices += Convert.ToDecimal(key);
            }
            txtIntoMoney.Text = dcmPrices.ToString();
        }

        public void addBill()
        {
            string billId = txtBillId.Text;
            string orderId = this.orderID;
            string datePay = txtDatePay.Text;
            string money = txtIntoMoney.Text;

            string sql = "INSERT INTO BILLS VALUES " +
                $"('{billId}', '{orderID}', '{datePay}', {money})";
            DBServices db = new DBServices();
            db.runQuery(sql);
        }

        private void frmBill_Load(object sender, EventArgs e)
        {
            newBill();
            if(this.myBool)
                getNameCustomer(true);
            else
                getNameCustomer(false);
        }

        private void cbCustomerName_SelectedValueChanged(object sender, EventArgs e)
        {
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
            getTableNumber();
            getDate();
        }

        private void dtGridViewFood_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBillPrinting_Click(object sender, EventArgs e)
        {
            if (txtDatePay.Text != "")
            {
                MessageBox.Show("Bạn có muốn in hóa đơn không?", "Thông báo!!");
                addBill();
                this.Close();
            }
            else
                MessageBox.Show("Vui lòng nhập ngày thanh toán!!", "Thông báo!!");
        }
    }
}
