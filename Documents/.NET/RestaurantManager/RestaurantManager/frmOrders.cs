using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RestaurantManager
{
    public partial class frmOrders : Form
    {
        bool addNew = false;
        bool cellEnter = true;
        bool quantityChange = false;
        bool myCheck = false;
        string bookID;
        public frmOrders(string bookID ,bool myCheck)
        {
            InitializeComponent();
            this.myCheck = myCheck;
            this.bookID = bookID;
        }

        public void setEnable(bool check)
        {
            txtOrderID.Enabled = false;
            txtPrice.Enabled = false;
            txtPay.Enabled = false;
            txtQuantity.Enabled = !check;
            btnSave.Enabled = !check;
            cbBookID.Enabled = !check;
            cbStaffs.Enabled = !check;
            cbFoods.Enabled = !check;
            btnCancel.Enabled = !check;
            btnAddNew.Enabled = check;
            btnDelete.Enabled = check;
            btnEdit.Enabled = check;
            btnExit.Enabled = check;
            btnBillPrinting.Enabled = check;
        }

        public void getDataOrder()
        {
            DBServices db = new DBServices();
            string select = "OrderID, Orders.StaffID, Orders.BookID, FoodID, Quantity, Price, Pay";
            string from = "Orders join Bookings on Orders.BookID = Bookings.BookID";
            string where = $"Orders.BookID = '{this.bookID}'";
            if (myCheck)
                dataGridView1.DataSource = db.querySelect(from, select);
            else
                dataGridView1.DataSource = db.querySelect(from, select, where);
        }

        public void getDataBook()
        {
            string where = " PAY NOT IN (N'Đã thanh toán', N'Hủy đăng ký')";
            DBServices db = new DBServices();
            cbBookID.DisplayMember = "TableID";
            cbBookID.ValueMember = "BookID";
            cbBookID.DataSource = db.querySelect("BOOKINGS", "*", where);
        }

        public void getDataFoods()
        {
            DBServices db = new DBServices();
            cbFoods.DisplayMember = "NameFood";
            cbFoods.ValueMember = "FoodID";
            cbFoods.DataSource = db.querySelect("FOODS");
        }

        public decimal getPriceFood(string FoodID)
        {
            string sql = "declare @price decimal(10, 3) " +
                    $"exec getPriceFood @price out, {FoodID} " +
                    "select @price";
            DBServices db = new DBServices();
            DataTable dt = db.getData(sql);
            return decimal.Parse(dt.Rows[0][0].ToString());
        } 

        public void getStaffs()
        {
            DBServices db = new DBServices();
            cbStaffs.DisplayMember = "NameStaff";
            cbStaffs.ValueMember = "StaffID";
            cbStaffs.DataSource = db.querySelect("STAFFS");
        }

        public void setBillPrinting(bool check)
        {
            btnBillPrinting.Enabled = check;
            btnAddNew.Enabled = check;
            btnEdit.Enabled= check;
        }

        //public decimal getTotalPrice(string FoodID)
        //{
        //    string sql = "declare @price decimal(10, 2), @quantity int " +
        //            $"exec getTotalPrice @price out, @quantity out, {FoodID} " +
        //            "select @price, @quantity";
        //    DBServices db = new DBServices();
        //    DataTable dt = db.getData(sql);
        //    decimal price = decimal.Parse(dt.Rows[0][0].ToString());
        //    int quantity = int.Parse(dt.Rows[0][1].ToString());
        //    return price * quantity;
        //}

        public void changed()
        {
            if (quantityChange)
            {
                string FoodID = cbFoods.SelectedValue.ToString();
                txtPrice.Text = txtQuantity.Text == "" ? "" : Convert.ToString(getPriceFood(FoodID) * int.Parse(txtQuantity.Text));
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmOrders_Load(object sender, EventArgs e)
        {
            setEnable(true);
            getDataOrder();
            getDataBook();
            getDataFoods();
            getStaffs();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(cellEnter)
            {
                int i = e.RowIndex;
                txtOrderID.Text = dataGridView1.Rows[i].Cells["OrderID"].Value.ToString();
                cbStaffs.SelectedValue = dataGridView1.Rows[i].Cells["StaffID"].Value.ToString();
                txtPrice.Text = dataGridView1.Rows[i].Cells["Price"].Value.ToString();
                txtQuantity.Text = dataGridView1.Rows[i].Cells["Quantity"].Value.ToString();
                cbBookID.SelectedValue = dataGridView1.Rows[i].Cells["BookID"].Value.ToString();
                cbFoods.SelectedValue = dataGridView1.Rows[i].Cells["FoodID"].Value.ToString();
                txtPay.Text = dataGridView1.Rows[i].Cells["Pay"].Value.ToString();
                if(txtPay.Text == "Đã thanh toán") setBillPrinting(false);
                else setBillPrinting(true);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmDeskManager Dm = new frmDeskManager();
            string query = "DECLARE @VALUE INT " +
                "SELECT @VALUE = SUBSTRING(MAX(ORDERID), 3, 2) + 1 FROM ORDERS " +
                "SELECT @VALUE";
            txtOrderID.Text = "OD" + Dm.getValue(query, "1");
            txtPrice.Clear();
            txtQuantity.Clear();
            
            addNew = true;
            setEnable(false);
            cellEnter = false;
            quantityChange = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string id = txtOrderID.Text;
            dynamic obj = new ExpandoObject();
            obj.orderID = id;
            obj.staffId = cbStaffs.SelectedValue.ToString();
            obj.bookId = cbBookID.SelectedValue.ToString();
            obj.foodID = cbFoods.SelectedValue.ToString();
            obj.quantity = int.Parse(txtQuantity.Text);
            obj.price = decimal.Parse(txtPrice.Text);
            DBServices db = new DBServices();
            if (addNew) db.queryInsertInto("ORDERS", obj);
            else db.queryUpdate("ORDERS", obj, $"ORDERID = '{id}'");
            
            getDataOrder();

            cellEnter = true;
            quantityChange = false;
            setEnable(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cellEnter = true;
            txtOrderID.Clear();
            txtPrice.Clear();
            setEnable(true);
            quantityChange = false;
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            changed();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            cellEnter = false;
            quantityChange = true;
            addNew = false;
            setEnable(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtOrderID.Text;
            DBServices db = new DBServices();
            db.queryDelete("ORDERS", $"ORDERID = '{id}'");
            getDataOrder();
        }

        private void cbDishID_SelectedValueChanged(object sender, EventArgs e)
        {
            changed();
        }

        private void btnBillPrinting_Click(object sender, EventArgs e)
        {
            DBServices db = new DBServices();

            dynamic myObject = new ExpandoObject();
            myObject.name = "manh";
            myObject.description = "khanh";
            myObject.type = 14;
            db.queryDelete("ClassManh");
            //string orderId = txtOrderID.Text;
            //frmBill bill = new frmBill(orderId, true);
            //bill.Show();
        }
    }
}
