using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
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
            txtDatePay.Enabled = true;
            cbBookingDate.Enabled = true;
            //dtGridViewFood.Enabled = false;
            cbCustomerName.Enabled = check;
        }

        public void newBill()
        {
            string sql = "declare @id int " +
                "select @id = max(billid) + 1 from Bills " +
                "select @id";
            frmDeskManager dm = new frmDeskManager();
            txtBillId.Text = dm.getValue(sql, "1");
        }

        public void getNameCustomer(bool check)
        {
            string sql;
            if(!check)
            {
                sql = "SELECT CustomerName from(orders join Bookings on Orders.BookID = Bookings.BookID)" +
                "join Customers on Customers.CustomerID = Bookings.CustomerID " +
                "Where  Pay = N'Đã thanh toán' " +
                "group by CustomerName";
            }
            else
            {
                sql = "SELECT CustomerName from(orders join Bookings on Orders.BookID = Bookings.BookID)" +
                "join Customers on Customers.CustomerID = Bookings.CustomerID " +
                $"Where Orders.OrderID = '{this.orderID}'and Pay = N'Đã thanh toán' " +
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
                "SELECT @id = Orders.OrderID from(orders join Bookings on Orders.BookID = Bookings.BookID)" +
                "join Customers on Customers.CustomerID = Bookings.CustomerID " +
                $"Where Customers.CustomerName = N'{cbCustomerName.Text}' " +
                "group by Orders.OrderID " +
                "select @id";
            frmDeskManager dm = new frmDeskManager();
            return dm.getValue(sql, "");
        }

        public int getTableNumber()
        {
            if (this.orderID != null && this.orderID != "")
            {
                string sql = "declare @tableNumber int " +
                    "SELECT TableID from orders join Bookings on Orders.BookID = Bookings.BookID " +
                    $"Where OrderID = '{this.orderID}' " +
                    "group by TableID " +
                    "select @tablenumber";
                frmDeskManager dm = new frmDeskManager();
                return int.Parse(dm.getValue(sql, ""));
            }
            return 0;
        }

        public void getDate()
        {
            string sql = "SELECT bookingdate from orders join Bookings on Orders.BookID = Bookings.BookID " +
                    $"Where OrderID = '{this.orderID}' " +
                    "group by bookingdate ";
            DBServices db = new DBServices();
            cbBookingDate.DisplayMember = "BookingDate";
            cbBookingDate.ValueMember = "BookID";
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
            DBServices db = new DBServices();
            var sql = "SELECT Orders.OrderID, NameFood, Quantity, orders.Price " +
                         "FROM (orders JOIN Bookings ON Orders.BookID = Bookings.BookID) " +
                         "JOIN Foods ON Foods.FoodID = Orders.FoodID " +
                         $"WHERE Orders.BookID = '{getBookID(orderId)}' " +
                         "GROUP BY Orders.OrderID, NameFood, Quantity, orders.Price";

            DataTable dt = db.getData(sql);

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
            string sql = "SELECT * FROM STAFFS";
            DBServices db = new DBServices();
            cbPaymentStaff.DisplayMember = "NameStaff";
            cbPaymentStaff.ValueMember = "StaffID";
            cbPaymentStaff.DataSource = db.getData(sql);
        }

        public void handleIntoMoney(string orderId)
        {
            string sql = "DECLARE @Prices VARCHAR(MAX) " +
                    "SELECT @Prices = COALESCE(@Prices + ',', '') + CONVERT(VARCHAR, price) " +
                    "FROM Orders " +
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
            int billId = int.Parse(txtBillId.Text);
            string staffID = cbPaymentStaff.SelectedValue.ToString();
            string bookID = getBookID(this.orderID);
            string datePay = txtDatePay.Text;
            decimal money = decimal.Parse(txtIntoMoney.Text);

            string sql = "INSERT INTO BILLS VALUES " +
                $"({billId}, '{staffID}', '{bookID}', '{datePay}', {money})";
            DBServices db = new DBServices();
            db.runQuery(sql);
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
            if (txtDatePay.Text != "")
            {
                MessageBox.Show("Bạn có muốn in hóa đơn không?", "Thông báo!!");
                addBill();
                frmDeskManager dm = new frmDeskManager();
                dm.setStatusTable(getTableNumber(), "off");
                setPayBooking();
                this.Close();
            }
            else
                MessageBox.Show("Vui lòng nhập ngày thanh toán!!", "Thông báo!!");
        }

        private void btnEditBill_Click(object sender, EventArgs e)
        {
            frmOrders od = new frmOrders(getBookID(this.orderID), false);
            od.Show();
            this.Close();
        }

        public void setPayBooking()
        {
            string sql = "UPDATE BOOKINGS SET " +
                "PAY = N'Đã thanh toán' " + 
                $"WHERE BookID = '{getBookID(this.orderID)}'";
            DBServices db = new DBServices();
            db.runQuery(sql);        
        }
    }
}
