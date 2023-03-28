using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Globalization;
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
            DBServices db = new DBServices();
            dataGridView1.DataSource = db.querySelect("BOOKINGS");
        }

        public void getDataCustomers()
        {
            DBServices db = new DBServices();
            cbCustomerID.DisplayMember = "CustomerName";
            cbCustomerID.ValueMember = "CustomerID";
            cbCustomerID.DataSource = db.querySelect("CUSTOMERS");
        }

        public void getDataTable()
        {
            DBServices db = new DBServices();
            cbTableID.DisplayMember = "TableID";
            cbTableID.ValueMember = "TableID";
            cbTableID.DataSource = db.querySelect("TABLES");
        }

        public void setStatusTable(int tableID, string status)
        {
            DBServices db = new DBServices();
            dynamic obj = new ExpandoObject();
            obj.status = status;
            db.queryUpdate("TABLES", obj, $"TABLEID = {tableID}");
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
            cbBookingStaff.DisplayMember = "NameStaff";
            cbBookingStaff.ValueMember = "StaffID";
            cbBookingStaff.DataSource = db.querySelect("STAFFS");
        }

        public void setEnable(bool check)
        {
            txtBookID.Enabled = false;
            cbBookingStaff.Enabled = check;
            cbCustomerID.Enabled = check;
            cbTableID.Enabled = check;
            pkDate.Enabled = check;
            pkTime.Enabled = check;
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
                    pkDate.Value = Convert.ToDateTime(dataGridView1.Rows[i].Cells["BOOKINGDATE"].Value).Date;
                    txtPay.Text = dataGridView1.Rows[i].Cells["Pay"].Value.ToString();

                    string timeString = dataGridView1.Rows[i].Cells["BOOKINGTIME"].Value.ToString();
                    DateTime timeValue;
                    bool isValidTime = DateTime.TryParseExact(timeString, "HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out timeValue);

                    if (isValidTime)
                    {
                        pkTime.Value = timeValue;
                    }
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
            pkDate.ResetText();
            pkTime.ResetText();
            cellEnter = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int tableID = int.Parse(cbTableID.Text);
            string query = $"declare @table int = {tableID}; " +
                "if exists (select * from tables where @table = tableid and Status = 'off') " +
                    "select 1; " +
                "else " +
                    "select 0";
            int TId = int.Parse(getValue(query, "0"));
            string bookID = txtBookID.Text;

            dynamic obj = new ExpandoObject();
            obj.bookID = bookID;
            obj.staffID = cbBookingStaff.SelectedValue.ToString();
            obj.ctmID = cbCustomerID.SelectedValue.ToString();
            obj.tableID = tableID;
            obj.date = pkDate.Text;
            obj.time = pkTime.Text;
            obj.pay = txtPay.Text;

            DBServices db = new DBServices();

            if (addNew)
            {
                if (TId == 1)
                {
                    db.queryInsertInto("BOOKINGS", obj);
                    getDataBook();
                    getDataCustomers();
                }
                else MessageBox.Show("Bàn đã được đặt!! Hãy thử đặt bàn khác.", "Thông báo");
            }
            else
            {
                db.queryUpdate("BOOKINGS", obj, $"BOOKID = '{bookID}'");
                if (tableID != this.tableId)
                    setStatusTable(this.tableId, "off");

                //db.runQuery(sql);
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
            DBServices db = new DBServices();
            db.queryDelete("BOOKINGS", $"BOOKID = '{id}'");
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
            dynamic obj = new ExpandoObject();
            obj.Pay = "Hủy đăng ký";
            setStatusTable(this.tableId, "off");
            db.queryUpdate("BOOKINGS", obj, $"BOOKID = '{bookID}'");
            getDataBook();
        }

        private void pkDate_ValueChanged(object sender, EventArgs e)
        {
            //pkDate.MinDate = DateTime.Now;
            //int dayofmonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            DateTime date = DateTime.Now;
            pkDate.MinDate= date;
        }
    }
}
