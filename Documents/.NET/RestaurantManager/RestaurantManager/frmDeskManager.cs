using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace RestaurantManager
{
    public partial class frmDeskManager : Form
    {
        private bool addNew = false;
        bool cellEnter = true;
        private int tableId;
        public frmDeskManager()
        {
            InitializeComponent();
        }

        public void getDataBook()
        {
            string sql = "SELECT * FROM BOOKINGS";
            DBServices db = new DBServices();
            dataGridView1.DataSource = db.getData(sql);
        }

        public void getDataCustomers()
        {
            DBServices db = new DBServices();
            string sql = "SELECT * FROM CUSTOMERS";
            cbCustomerID.DisplayMember = "CustomerName";
            cbCustomerID.ValueMember = "CustomerID";
            cbCustomerID.DataSource = db.getData(sql);
        }

        public void getDataTable()
        {
            DBServices db = new DBServices();
            string sql = "SELECT * FROM tables";
            cbTableID.DisplayMember = "TableID";
            cbTableID.ValueMember = "TableID";
            cbTableID.DataSource = db.getData(sql);
        }

        public void setStatusTable(int tableID, string status)
        {
            DBServices db = new DBServices();
            string sql = "UPDATE TABLES " +
                "SET " +
                $"STATUS = '{status}' " +
                $"WHERE TABLEID = '{tableID}'";
            
            db.runQuery(sql);
        }

        public string getValue(string query, string numberReturn)
        {
            DBServices db = new DBServices();
            DataTable dt = db.getData(query);
            return dt.Rows[0][0].ToString() == "" ? numberReturn : dt.Rows[0][0].ToString();
        }

        public void getStaffs()
        {
            DBServices db = new DBServices();
            string sql = "SELECT * FROM STAFFS";
            cbBookingStaff.DisplayMember = "NameStaff";
            cbBookingStaff.ValueMember = "StaffID";
            cbBookingStaff.DataSource = db.getData(sql);
        }

        public void setEnable(bool check)
        {
            txtBookID.Enabled = false;
            cbBookingStaff.Enabled = check;
            cbCustomerID.Enabled = check;
            cbTableID.Enabled = check;
            txtBookingDate.Enabled = check;
            txtTime.Enabled = check;
            txtPay.Enabled = false;
            btnAddNew.Enabled = !check;
            btnDelete.Enabled = !check;
            btnEdit.Enabled = !check;
            btnExit.Enabled = !check;
            btnStatus.Enabled = !check;
            btnCancelTable.Enabled = !check;
            btnCancel.Enabled = check;
            btnSave.Enabled = check;
        }

        private void frmDeskManager_Load(object sender, EventArgs e)
        {
            setEnable(false);
            getDataBook();
            getDataCustomers();
            getDataTable();
            getStaffs();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
           if (cellEnter)
            {
                try
                {
                    int i = e.RowIndex;
                    txtBookID.Text = dataGridView1.Rows[i].Cells["BookID"].Value.ToString();
                    cbBookingStaff.SelectedValue = dataGridView1.Rows[i].Cells["StaffID"].Value.ToString();
                    cbCustomerID.SelectedValue = dataGridView1.Rows[i].Cells["CustomerID"].Value.ToString();
                    cbTableID.SelectedValue = dataGridView1.Rows[i].Cells["TableID"].Value.ToString();
                    txtBookingDate.Text = dataGridView1.Rows[i].Cells["BookingDate"].Value.ToString();
                    txtTime.Text = dataGridView1.Rows[i].Cells["BOOKINGTIME"].Value.ToString();
                    txtPay.Text = dataGridView1.Rows[i].Cells["Pay"].Value.ToString();
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            string sql =
                        "declare @idBooking int;\n" +
                        "exec getIdBooking @idBooking out;\n" +
                        "select @idBooking";

            txtBookID.Text = "Book" + getValue(sql, "1");
            txtPay.Text = "Chưa thanh toán"; // chưa thanh toán
            addNew = true;
            setEnable(true);
            txtBookingDate.Clear();
            txtTime.Clear();
            cellEnter = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string bookID = txtBookID.Text;
            string staffID = cbBookingStaff.SelectedValue.ToString();
            string ctmID = cbCustomerID.SelectedValue.ToString();
            int tableID = int.Parse(cbTableID.Text);
            string date = txtBookingDate.Text;
            string time = txtTime.Text;
            string pay = txtPay.Text;
            string query = $"declare @table int = {tableID}; " +
                "if exists (select * from tables where @table = tableid and Status = 'off') " +
                    "select 1; " +
                "else " +
                    "select 0";
            int TId = int.Parse(getValue(query, "0"));

           
            DBServices db = new DBServices();

            if (addNew)
            {
                if (TId == 1)
                {
                    string sql = "INSERT INTO BOOKINGS VALUES " +
                        $"('{bookID}', '{staffID}', '{ctmID}', {tableID}, '{date}', '{time}', N'{pay}')";
                    db.runQuery(sql);
                    getDataBook();
                    getDataCustomers();
                }
                else MessageBox.Show("Bàn đã được đặt!! Hãy thử đặt bàn khác.", "Thông báo");
            }
            else
            {
                string sql = "UPDATE BOOKINGS \n" +
                    "SET " +
                    $"STAFFID = '{staffID}',\n" +
                    $"CUSTOMERID = '{ctmID}', \n" +
                    $"TableID = {tableID}, \n" +
                    $"BOOKINGDATE = '{date}', \n" +
                    $"BOOKINGTIME = '{time}', \n" +
                    $"PAY = N'{pay}' \n" + 
                    $"WHERE BOOKID = '{bookID}'";
                if (tableID != this.tableId)
                    setStatusTable(this.tableId, "off");

                db.runQuery(sql);
                getDataBook();
            }

            setStatusTable(tableID, "on");

            addNew = false;
            setEnable(false);
            cellEnter = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //txtPay.Text = "";
            txtBookID.Clear();
            setEnable(false);
            cellEnter = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            tableId = int.Parse(cbTableID.Text);
            setEnable(true);
            addNew = false;
            cellEnter = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtBookID.Text;
            int tableID = int.Parse(cbTableID.Text);
            string sql = $"DELETE FROM BOOKINGS WHERE BOOKID = '{id}'";
            DBServices db = new DBServices();
            db.runQuery(sql);
            getDataBook();
            setStatusTable(tableID, "off");
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            frmStatusTables ST = new frmStatusTables();
            ST.Show();
        }

        private void btnCancelTable_Click(object sender, EventArgs e)
        {
            this.tableId = int.Parse(cbTableID.Text);  
            DBServices db = new DBServices();
            string bookID = txtBookID.Text;
            string sql = "UPDATE BOOKINGS \n" +
                    "SET " +
                    "PAY = N'Hủy đăng ký' \n" +
                    $"WHERE BOOKID = '{bookID}'";

            setStatusTable(this.tableId, "off");
            db.runQuery(sql);
            getDataBook();
        }
    }
}
