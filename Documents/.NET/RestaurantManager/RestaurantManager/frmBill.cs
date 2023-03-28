using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Dynamic;
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
            pkDate.Enabled = true;
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
            string from = "(Orders join Bookings on Orders.BookID = Bookings.BookID) join Customers on Customers.CustomerID = Bookings.CustomerID";
            string where = "Pay = N'Chưa thanh toán'";
            string select = "CustomerName";
            DBServices db = new DBServices();
            cbCustomerName.DisplayMember = "CustomerName";
            cbCustomerName.ValueMember = "CustomerID";
            if (!check)
                cbCustomerName.DataSource = db.querySelect(from, select, where, select);
            else
                cbCustomerName.DataSource = db.querySelect(from, select,where + $" and Orders.OrderID = '{this.orderID}'", select);
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
            string select = "BOOKINGDATE";
            string from = "orders join Bookings on Orders.BookID = Bookings.BookID";
            string where = $"OrderID = '{this.orderID}'";
            DBServices db = new DBServices();
            cbBookingDate.DisplayMember = "BookingDate";
            cbBookingDate.ValueMember = "BookID";
            cbBookingDate.DataSource = db.querySelect(from, select, where, select);
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
            string select = "Orders.OrderID, NameFood, Quantity, orders.Price";
            string from = "(orders JOIN Bookings ON Orders.BookID = Bookings.BookID) JOIN Foods ON Foods.FoodID = Orders.FoodID";
            string where = $" Orders.BookID = '{getBookID(orderId)}'";
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
            cbPaymentStaff.DisplayMember = "NameStaff";
            cbPaymentStaff.ValueMember = "StaffID";
            cbPaymentStaff.DataSource = db.querySelect("STAFFS");
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
            dynamic obj = new ExpandoObject();
            obj.billID = int.Parse(txtBillId.Text);
            obj.datePay = pkDate.Text;
            obj.money = decimal.Parse(txtIntoMoney.Text);
            obj.staffID = cbPaymentStaff.SelectedValue.ToString();
            obj.bookID = getBookID(this.orderID);

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
            DateTime date = DateTime.Now;
            MessageBox.Show(pkDate.Text.ToString() + date.ToString());
            //if (pkDate.Text.ToString() != date.ToString())
            //{
            //    MessageBox.Show("Bạn có muốn in hóa đơn không?", "Thông báo!!");
            //    addBill();
            //    frmDeskManager dm = new frmDeskManager();
            //    dm.setStatusTable(getTableNumber(), "off");
            //    setPayBooking();
            //    this.Close();
            //}
            //else
            //    MessageBox.Show("Vui lòng nhập ngày thanh toán!!", "Thông báo!!");
        }

        private void btnEditBill_Click(object sender, EventArgs e)
        {
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
            pkDate.MinDate = date;
        }
    }
}
