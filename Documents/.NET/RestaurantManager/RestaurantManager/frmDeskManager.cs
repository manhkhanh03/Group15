using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManager
{
    public partial class frmDeskManager : Form
    {
        private bool addNew = false;
        bool cellEnter = true;
        public frmDeskManager()
        {
            InitializeComponent();
        }

        public void getDataBook()
        {
            string sql = "SELECT * FROM BOOKING";
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
            string sql;
            DBServices db = new DBServices();
            if (status == "on")
                sql = "UPDATE TABLES " +
                "SET " +
                "STATUS = 'off' " +
                $"WHERE TABLEID LIKE'{tableID}%'";
            else
                sql = "UPDATE TABLES " +
                "SET " +
                "STATUS = 'on' " +
                $"WHERE TABLEID LIKE'{tableID}%'";

            db.runQuery(sql);
        }

        public void setEnable(bool check)
        {
            txtBookID.Enabled = false;
            cbCustomerID.Enabled = check;
            cbTableID.Enabled = check;
            txtBookingDate.Enabled = check;
            txtTime.Enabled = check;
            btnAddNew.Enabled = !check;
            btnDelete.Enabled = !check;
            btnEdit.Enabled = !check;
            btnExit.Enabled = !check;
            btnStatus.Enabled = !check;
            btnCancel.Enabled = check;
            btnSave.Enabled = check;
        }

        private void frmDeskManager_Load(object sender, EventArgs e)
        {
            setEnable(false);
            getDataBook();
            getDataCustomers();
            getDataTable();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
           if (cellEnter)
            {
                try
                {
                    int i = e.RowIndex;
                    txtBookID.Text = dataGridView1.Rows[i].Cells["BookID"].Value.ToString();
                    cbCustomerID.SelectedValue = dataGridView1.Rows[i].Cells["CustomerID"].Value.ToString();
                    cbTableID.SelectedValue = dataGridView1.Rows[i].Cells["TableID"].Value.ToString();
                    txtBookingDate.Text = dataGridView1.Rows[i].Cells["BookingDate"].Value.ToString();
                    txtTime.Text = dataGridView1.Rows[i].Cells["time"].Value.ToString();
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
            string get =
                        "declare @id int;\n" +
                        "exec getID @id out;\n" +
                        "select @id";
            txtBookID.Text = "Book" + getValue(get, "1");

            addNew = true;
            setEnable(true);
            txtBookingDate.Clear();
            txtTime.Clear();
        }

        public string getValue(string query, string numberReturn)
        {
            DBServices db = new DBServices(); 
            DataTable dt = db.getData(query);
            return dt.Rows[0][0].ToString() == "" ? numberReturn : dt.Rows[0][0].ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string ctmID = cbCustomerID.SelectedValue.ToString();
            int tableID = int.Parse(cbTableID.SelectedValue.ToString());
            string date = txtBookingDate.Text;
            string time = txtTime.Text;
            string query = $"declare @table int = {tableID}; " +
                "if exists (select * from tables where @table = tableid and Status = 'off') " +
                    "select 1; " +
                "else " +
                    "select 0";
            int TId = int.Parse(getValue(query, "0"));

            if (TId == 1) 
            {
                DBServices db = new DBServices();

                if (addNew)
                {
                    string get =
                        "declare @id int;\n" +
                        "exec getID @id out;\n" +
                        "select @id";
                    int bookID = int.Parse(getValue(get, "1"));
                    string sql = "INSERT INTO BOOKING VALUES " +
                        $"(CONCAT('Book', {bookID}), '{ctmID}', {tableID}, '{date}', '{time}')";
                    db.runQuery(sql);
                    getDataBook();
                    getDataCustomers();
                }
                else
                {
                    string bookID = txtBookID.Text;
                    string sql = "UPDATE BOOKING \n" +
                        "SET " +
                        $"CUSTOMERID = '{ctmID}', \n" +
                        $"TableID = {tableID}, \n" +
                        $"BOOKINGDATE = '{date}', \n" +
                        $"TIME = '{time}'\n" +
                        $"WHERE BOOKID like '{bookID}%'";
                    db.runQuery(sql);
                    getDataBook();
                }

                setStatusTable(tableID, "off");

                addNew = false;
                setEnable(false);
                cellEnter = true;
            }
            else
            {
                MessageBox.Show("Bàn đã được đặt!! Hãy thử đặt bàn khác.", "Thông báo");
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtBookID.Clear();
            setEnable(false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            setEnable(true);
            addNew = false;
            cellEnter = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtBookID.Text;
            int tableID = int.Parse(cbTableID.SelectedValue.ToString());
            string sql = $"DELETE FROM BOOKING WHERE BOOKID like'{id}%'";
            DBServices db = new DBServices();
            db.runQuery(sql);
            getDataBook();
            setStatusTable(tableID, "on");
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            frmStatusTables ST = new frmStatusTables();
            ST.ShowDialog();
        }
    }
}
