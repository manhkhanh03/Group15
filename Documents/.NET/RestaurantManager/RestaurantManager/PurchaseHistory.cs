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
    public partial class frmPurchaseHistory : Form
    {
        bool AddNew = false;
        public frmPurchaseHistory()
        {
            InitializeComponent();
        }

        private void frmPurchaseHistory_Load(object sender, EventArgs e)
        {
            LoadGridData();
            GetDataCustomer();
        }
        private void GetDataCustomer()
        {
            DBServices db = new DBServices();
            cbCustomerID.DisplayMember= "CustomerID";
            cbCustomerID.ValueMember = "CustomerID";
            string sql = "select * from Customers";
            cbCustomerID.DataSource= db.getData(sql);
        }
         private void LoadGridData() 
         {
            DBServices db = new DBServices();
            string sql = "Select * from PurchaseHistorys";
            dgvPurchaseHistory.DataSource = db.getData(sql);
            SetEnable(false);
         }
        private void SetEnable(bool check)
        {
            txtPurchaseHistoryID.Enabled = false;
            cbCustomerID.Enabled = check;
            cbOrderID.Enabled = check;
            btnAddNew.Enabled = !check;
            btnDelete.Enabled = !check;
            btnEdit.Enabled = !check;
            btnExit.Enabled = !check;
            btnCancel.Enabled = check;
            btnSave.Enabled = check;
            dgvPurchaseHistory.Enabled = !check;
        }

        private void dgvPurchaseHistory_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0)
            {
                txtPurchaseHistoryID.Text = dgvPurchaseHistory.Rows[i].Cells["PurchaseHistoryID"].Value.ToString();
                cbCustomerID.SelectedValue = dgvPurchaseHistory.Rows[i].Cells["CustomerID"].Value.ToString();
                cbOrderID.SelectedValue = dgvPurchaseHistory.Rows[i].Cells["OrderID"].Value.ToString();
                dtpDate.Text = dgvPurchaseHistory.Rows[i].Cells["Date"].Value.ToString();
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            AddNew = true;
            SetEnable(true);
            txtPurchaseHistoryID.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
