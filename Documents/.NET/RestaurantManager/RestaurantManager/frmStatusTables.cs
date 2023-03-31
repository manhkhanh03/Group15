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
            cbStatus.DisplayMember = "STATUS";
            cbStatus.ValueMember = "STATUS";
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
                txtTableID.Text = dataGridView1.Rows[i].Cells["NUMBERTABLE"].Value.ToString();
                txtSeats.Text = dataGridView1.Rows[i].Cells["SEATS"].Value.ToString();
                cbStatus.SelectedValue = dataGridView1.Rows[i].Cells["STATUS"].Value.ToString();
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            DBServices db = new DBServices();
            txtTableID.Text = db.queryProcedure("TABLES", "MAX(TABLEID) + 1").ToString();
            addNew = true;
            setEnable(false);
            txtSeats.Clear();
            cellEnter = false;
            cbStatus.SelectedValue = "off";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtTableID.Clear();
            cellEnter = true;
            setEnable(true);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DBServices db = new DBServices();
            int tableID = int.Parse(db.queryProcedure("TABLES", "MAX(TABLEID) + 1").ToString());
            dynamic obj = new ExpandoObject();
            obj.tableID = txtTableID.Text;
            obj.seats = int.Parse(txtSeats.Text);
            obj.status = "off";

            if (addNew)
            {
                obj.tableID = int.Parse(db.queryProcedure("TABLES", "MAX(TABLEID) + 1").ToString());
                db.queryInsertInto("TABLES", obj);
            }else
            {
                int id = int.Parse(txtTableID.Text);
                obj.status = cbStatus.Text;
                db.queryUpdate("TABLES", obj, $"TABLEID = {id}");
            }
            getDataTable();
            cellEnter = true;
            setEnable(true);
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
