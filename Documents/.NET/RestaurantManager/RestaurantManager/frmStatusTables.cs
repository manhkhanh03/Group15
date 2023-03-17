using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            string sql = "SELECT * FROM VIEWTABLES";
            dataGridView1.DataSource = db.getData(sql);
        }

        public void getStatusTables()
        {
            DBServices db = new DBServices();
            string sql = "SELECT STATUS FROM VIEWTABLES " +
                "GROUP BY STATUS";
            cbStatus.DisplayMember = "Status";
            cbStatus.ValueMember = "Status";
            cbStatus.DataSource = db.getData(sql);
        }

        public void setEnable(bool check)
        {
            txtTableID.Enabled = false;
            cbStatus.Enabled = false;
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

            DBServices db = new DBServices();
            string sql;

            if (addNew)
            {
                sql = "INSERT INTO TABLES VALUES " +
                    $"({tableID}, {seat}, 'off')";
            }else
            {
                int id = int.Parse(txtTableID.Text);
                sql = "UPDATE TABLES SET " +
                    $"SEATS = {seat} " +
                    $"WHERE TABLEID = {id}";
            }
            db.runQuery(sql);
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
            string sql = $"DELETE FROM TABLES WHERE TABLEID = {id}";
            DBServices db = new DBServices();
            db.runQuery(sql);
            getDataTable();
        }
    }
}
