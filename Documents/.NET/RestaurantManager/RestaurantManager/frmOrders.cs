using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public frmOrders()
        {
            InitializeComponent();
        }

        public void setEnable(bool check)
        {
            txtOrderID.Enabled = false;
            txtPrice.Enabled = false;
            txtQuantity.Enabled = !check;
            btnSave.Enabled = !check;
            cbBookID.Enabled = !check;
            cbDishID.Enabled = !check;
            btnCancel.Enabled = !check;
            btnAddNew.Enabled = check;
            btnDelete.Enabled = check;
            btnEdit.Enabled = check;
            btnExit.Enabled = check;
        }

        public void getDataOrder()
        {
            DBServices db = new DBServices();
            string sql = "SELECT * FROM ORDERS";
            dataGridView1.DataSource = db.getData(sql);
        }
        // ngan OC test
        public void getDataBook()
        {
            DBServices db = new DBServices();
            string sql = "SELECT * FROM BOOKING";
            cbBookID.DisplayMember = "BookID";
            cbBookID.ValueMember = "BookID";
            cbBookID.DataSource = db.getData(sql);
        }

        public void getDataDish()
        {
            DBServices db = new DBServices();
            string sql = "SELECT * FROM DISHS";
            cbDishID.DisplayMember = "DishID";
            cbDishID.ValueMember = "DishID";
            cbDishID.DataSource = db.getData(sql);
        }

        public decimal getPriceDishs(string dishId)
        {
            string sql = "declare @price decimal(10, 2) " +
                    $"exec getPriceDish @price out, {dishId} " +
                    "select @price";
            DBServices db = new DBServices();
            DataTable dt = db.getData(sql);
            return decimal.Parse(dt.Rows[0][0].ToString());
        } 

        public decimal getTotalPrice(string dishId)
        {
            string sql = "declare @price decimal(10, 2), @quantity int " +
                    $"exec getTotalPrice @price out, @quantity out, {dishId} " +
                    "select @price, @quantity";
            DBServices db = new DBServices();
            DataTable dt = db.getData(sql);
            decimal price = decimal.Parse(dt.Rows[0][0].ToString());
            int quantity = int.Parse(dt.Rows[0][1].ToString());
            return price * quantity;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmOrders_Load(object sender, EventArgs e)
        {
            setEnable(true);
            getDataOrder();
            getDataBook();
            getDataDish();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(cellEnter)
            {
                int i = e.RowIndex;
                txtOrderID.Text = dataGridView1.Rows[i].Cells["OrderID"].Value.ToString();
                txtPrice.Text = dataGridView1.Rows[i].Cells["Price"].Value.ToString();
                txtQuantity.Text = dataGridView1.Rows[i].Cells["Quantity"].Value.ToString();
                cbBookID.SelectedValue = dataGridView1.Rows[i].Cells["BookID"].Value.ToString();
                cbDishID.SelectedValue = dataGridView1.Rows[i].Cells["DishID"].Value.ToString();
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
            string bookId = cbBookID.Text;
            string dishId = cbDishID.Text;
            decimal price = decimal.Parse(txtPrice.Text);
            int quantity = int.Parse(txtQuantity.Text);
            string sql;

            if (addNew)
            {
                sql = "INSERT INTO ORDERS VALUES " +
                    $"('{id}', '{bookId}', '{dishId}', {quantity}, {price})";
                
            }else
            {
                sql = "UPDATE ORDERS SET " +
                    $"BOOKID = '{bookId}', " +
                    $"DISHID = '{dishId}', " +
                    $"QUANTITY = {quantity}, " +
                    $"PRICE = {price} " +
                    $"WHERE ORDERID = '{id}'";

            }
            DBServices db = new DBServices();
            db.runQuery(sql);
            getDataOrder();

            quantityChange = false;
            setEnable(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtOrderID.Clear();
            txtPrice.Clear();
            setEnable(true);
            quantityChange = false;
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            string dishId = cbDishID.Text;
            if (quantityChange)
            {
                txtPrice.Text = txtQuantity.Text == "" ? "" : Convert.ToString(getPriceDishs(dishId) * int.Parse(txtQuantity.Text));
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            quantityChange = true;
            addNew = false;
            setEnable(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtOrderID.Text;

            string sql = $"DELETE FROM ORDERS " +
                $"WHERE ORDERID = '{id}'";
            DBServices db = new DBServices();
            db.runQuery(sql);
            getDataOrder();
        }
    }
}
