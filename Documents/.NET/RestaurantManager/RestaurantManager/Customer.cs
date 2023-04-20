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
    public partial class frmCustomer : Form
    {
        bool Addnew = false;
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            LoadGridData();
        }
        private void LoadGridData()
        {
            DBServices db = new DBServices();
            //string sql = "SELECT * FROM Customers ";
            //dgvCustomer.DataSource = db.getData(sql);
            dgvCustomer.DataSource = db.querySelect("Customers");
            SetEnable(false);
        }
        private void SetEnable(bool check)
        {
            txtCustomerID.Enabled = false;
            txtName.Enabled = check;
            dtpBirthday.Enabled = check;
            mtxtPhone.Enabled = check;
            txtAddress.Enabled = check;
            btnAddNew.Enabled = !check;
            btnDelete.Enabled = !check;
            btnEdit.Enabled = !check;
            btnExit.Enabled = !check;
            btnCancel.Enabled = check;
            btnSave.Enabled = check;
            dgvCustomer.Enabled = !check;

        }

        private void dgvCustomer_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0)
            {
                txtCustomerID.Text = dgvCustomer.Rows[i].Cells["CustomerID"].Value.ToString();
                txtName.Text = dgvCustomer.Rows[i].Cells["Name"].Value.ToString();
                dtpBirthday.Text = dgvCustomer.Rows[i].Cells["Birthday"].Value.ToString();
                mtxtPhone.Text = dgvCustomer.Rows[i].Cells["Phone"].Value.ToString();
                txtAddress.Text = dgvCustomer.Rows[i].Cells["Address"].Value.ToString();
                if (dgvCustomer.Rows[i].Cells["Gender"].Value.ToString() == "Nam") rbBoy.Checked = true;
                else rbBoy.Checked = false;
                if (dgvCustomer.Rows[i].Cells["Gender"].Value.ToString() == "Nữ") rbGirl.Checked = true;
                else rbGirl.Checked = false;

            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            Addnew = true;
            SetEnable(true);
            txtCustomerID.Clear();
            txtName.Clear();
            txtAddress.Clear();
            mtxtPhone.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string ci = txtCustomerID.Text;
            string na = txtName.Text;
            string ph = mtxtPhone.Text;
            string ad = txtAddress.Text;
            string ge = (rbBoy.Checked) ? rbBoy.Text : rbGirl.Text;
            string bi = dtpBirthday.Text;

            if (Addnew)
            {
                DBServices db = new DBServices();
                string ssql = "declare @id int select @id = substring(max(Customerid),3,3)from customers select @id +1 ";
                DataTable dt = db.getData(ssql);
                string upid = "KH" + (int.Parse(dt.Rows[0][0].ToString()) < 10 ? "00" + dt.Rows[0][0].ToString() : "0" + dt.Rows[0][0].ToString());
                Addnew = true;
                SetEnable(true);
                //Ghi khi nhấp vào nút thêm mới
                string sql = string.Format("INSERT INTO Customers ( CustomerID, Name ,Phone , Address ,Birthday , Gender  ) VALUES  ('{0}',N'{1}','{2}',N'{3}','{4}',N'{5}')", upid, na, ph, ad, bi, ge);
                db.runQuery(sql); //thực thi một truy vấn không trả về bất kỳ giá trị nào từ cơ sở dữ liệu
                LoadGridData();
            }
            else
            {
                string sql = string.Format("UPDATE Customers SET " +
                   "Name = N'{0}' ," +
                   "Gender = N'{1}' ," +
                   "Address = N'{2}' ," +
                   "Birthday = '{3}' ," +
                   "Phone = '{4}'  WHERE CustomerID = {5}", na, ge, ad, bi, ph, ci);
                DBServices db = new DBServices();
                db.runQuery(sql); //thực thi một truy vấn không trả về bất kỳ giá trị nào từ cơ sở dữ liệu
                LoadGridData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Addnew = false;
            SetEnable(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetEnable(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Ban co chan chan muon xoa ?", "Thong bao");
            string ci = txtCustomerID.Text;
            string sql = $"DELETE FROM Customers WHERE CustomerID like '{ci}%'";
            DBServices db = new DBServices();
            db.runQuery(sql); //thực thi một truy vấn không trả về bất kỳ giá trị nào từ cơ sở dữ liệu
            LoadGridData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPurchaseHistory_Click(object sender, EventArgs e)
        {
            frmPurchaseHistory fp = new frmPurchaseHistory();
            fp.ShowDialog();
        }
    }
}
