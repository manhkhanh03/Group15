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
            cbCustomerID.DisplayMember = "CUSTOMERNAME";
            cbCustomerID.ValueMember = "CUSTOMERID";
            cbCustomerID.DataSource = db.querySelect("CUSTOMERS");
        }

        public void getDataTable()
        {
            DBServices db = new DBServices();
            cbTableID.DisplayMember = "TABLEID";
            cbTableID.ValueMember = "TABLEID";
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
            cbBookingStaff.DisplayMember = "NAMESTAFF";
            cbBookingStaff.ValueMember = "STAFFID";
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
                    txtBookID.Text = dataGridView1.Rows[i].Cells["BOOKID"].Value.ToString();
                    cbBookingStaff.SelectedValue = dataGridView1.Rows[i].Cells["STAFFID"].Value.ToString();
                    cbCustomerID.SelectedValue = dataGridView1.Rows[i].Cells["CUSTOMERID"].Value.ToString();
                    cbTableID.Text = Convert.ToString(dataGridView1.Rows[i].Cells["TABLEID"].Value);
                    DateTime bookingDate;
                    if (DateTime.TryParse(dataGridView1.Rows[i].Cells["BOOKINGDATE"].Value?.ToString(), out bookingDate))
                        pkDate.Value = bookingDate.Date;
                    else
                        pkDate.Value = DateTime.Now.Date;
                    string timeString = dataGridView1.Rows[i].Cells["BOOKINGTIME"].Value.ToString();
                    DateTime timeValue;
                    bool isValidTime = DateTime.TryParseExact(timeString, "HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out timeValue);

                    if (isValidTime)
                        pkTime.Value = timeValue;
                    txtPay.Text = dataGridView1.Rows[i].Cells["PAY"].Value.ToString();   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            string select = "SUBSTRING(MAX(BOOKID), 5, 2) + 1";
            DBServices db = new DBServices();
            int myNumber = int.Parse(db.queryProcedure("BOOKINGS", select).ToString());
            txtBookID.Text = "Book" + (myNumber < 10 ? "0" + myNumber.ToString() : myNumber.ToString());
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
            DBServices db = new DBServices();
            string TId = db.queryProcedure("TABLES", "STATUS", $"TABLEID = {tableID}").ToString();
            string bookID = txtBookID.Text;

            dynamic obj = new ExpandoObject();
            obj.bookID = bookID;
            obj.staffID = cbBookingStaff.SelectedValue.ToString();
            obj.ctmID = cbCustomerID.SelectedValue.ToString();
            obj.tableID = tableID;
            obj.date = pkDate.Text;
            obj.time = pkTime.Text;
            obj.pay = txtPay.Text;

            if (addNew)
            {
                if (TId.Contains("off"))
                {
                    db.queryInsertInto("BOOKINGS", obj);
                    getDataBook();
                    getDataCustomers();
                    setStatusTable(tableID, "on");
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
            //DateTime date = DateTime.Now;
            //pkDate.MinDate= date;
        }
    }
}
