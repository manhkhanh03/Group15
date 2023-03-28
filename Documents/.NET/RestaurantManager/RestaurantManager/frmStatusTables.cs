using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManager
{
    public partial class frmStatusTables : Form
    {
        bool addNew = false;
        bool cellEnter = true;
        public frmStatusTables()
        {
            InitializeComponent();
        }

        public void getDataTable()
        {
            DBServices db = new DBServices();
            dataGridView1.DataSource = db.querySelect("VIEWTABLES");
        }

        public void getStatusTables()
        {
            DBServices db = new DBServices();
            cbStatus.DisplayMember = "Status";
            cbStatus.ValueMember = "Status";
            string status = "STATUS";
            cbStatus.DataSource = db.querySelect("VIEWTABLES", status, status);
        }

        public void setEnable(bool check)
        {
            txtTableID.Enabled = false;
            cbStatus.Enabled = !check;
            txtSeats.Enabled = !check;
            btnAddNew.Enabled = check;
            btnDelete.Enabled = check;
            btnEdit.Enabled = check;
            btnExit.Enabled = check;
            btnCancel.Enabled = !check;
            btnSave.Enabled = !check;
        }

        private void frmStatusTables_Load(object sender, EventArgs e)
        {
            setEnable(true);

            getDataTable();
            getStatusTables();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(cellEnter)
            {
                int i = e.RowIndex;
                txtTableID.Text = dataGridView1.Rows[i].Cells["NumberTable"].Value.ToString();
                txtSeats.Text = dataGridView1.Rows[i].Cells["Seats"].Value.ToString();
                cbStatus.SelectedValue = dataGridView1.Rows[i].Cells["Status"].Value.ToString();
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmDeskManager Dm = new frmDeskManager();
            string query = "DECLARE @VALUE INT " +
                "SELECT @VALUE = MAX(TABLEID) + 1 FROM TABLES " +
                "SELECT @VALUE";
            txtTableID.Text = Dm.getValue(query, "1");
            
            addNew = true;
            setEnable(false);
            txtSeats.Clear();
            cbStatus.SelectedValue = "off";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtTableID.Clear();
            setEnable(true);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            frmDeskManager Dm = new frmDeskManager();
            int seat = int.Parse(txtSeats.Text);
            string query = "DECLARE @VALUE INT " +
                "SELECT @VALUE = MAX(TABLEID) + 1 FROM TABLES " +
                "SELECT @VALUE";
            int tableID = int.Parse(Dm.getValue(query, "1"));

            dynamic obj = new ExpandoObject();
            obj.tableID = int.Parse(Dm.getValue(query, "1"));
            obj.seat = int.Parse(txtSeats.Text);
            obj.status = "off";
            DBServices db = new DBServices();

            if (addNew)
            {
                db.queryInsertInto("TABLES", obj);
            }else
            {
                int id = int.Parse(txtTableID.Text);
                db.queryUpdate("TABLES", obj, $"TABLEID = {id}");
            }
            getDataTable();
            cellEnter = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            addNew = false;
            cellEnter = false;
            setEnable(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtTableID.Text);
            DBServices db = new DBServices();
            db.queryDelete("TABLES", $"TABLEID = {id}");
            getDataTable();
        }
    }
}
