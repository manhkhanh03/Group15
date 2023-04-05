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
    public partial class frmTypeFood : Form
    {
        bool AddNew = false;
        private string idType;
        public frmTypeFood()
        {
            InitializeComponent();
        }

        private void frmTypeFood_Load(object sender, EventArgs e)
        {
            LoadGridData();
        }
        private void setEnable(bool check)
        {

            txtTypeFoodID.Enabled = check;
            txtNameType.Enabled = check;
            btnAddNew.Enabled = !check;
            btnDelete.Enabled = !check;
            btnEdit.Enabled = !check;
            btnExit.Enabled = !check;
            btnCancel.Enabled = check;
            btnSave.Enabled = check;

        }
        private void LoadGridData()
        {
            DBServices db = new DBServices();
            string sql = "SELECT * FROM TypeFoods ";
            dgvTypeFood.DataSource = db.getData(sql);
            setEnable(false);
        }
        private void dgvTypeFood_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0)
            {

                txtNameType.Text = dgvTypeFood.Rows[i].Cells["NameType"].Value.ToString();
                txtTypeFoodID.Text = dgvTypeFood.Rows[i].Cells["TypeFoodID"].Value.ToString();

            }
        }
      

        private void btnAddNew_Click_1(object sender, EventArgs e)
        {
            AddNew = true;
            setEnable(true);
            txtTypeFoodID.Clear();
            txtNameType.Clear();
            txtNameType.Focus();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            string nf = txtNameType.Text;
            string ti = txtTypeFoodID.Text;

            if (AddNew)
            {

                AddNew = true;
                setEnable(true);
                //Ghi khi nhấp vào nút thêm mới
                string sql = string.Format("INSERT INTO TypeFoods ( TypeFoodID, NameType ) VALUES  ('{0}',N'{1}')", ti, nf);

                DBServices db = new DBServices();
                db.runQuery(sql); //thực thi một truy vấn không trả về bất kỳ giá trị nào từ cơ sở dữ liệu
                LoadGridData();
            }

            else
            {
                //Ghi khi nhấp vào nút sửa 
                string id = txtTypeFoodID.Text;
                string sql = string.Format("UPDATE TypeFoods SET " +
                    "TypeFoodID = '{0}', " +
                    "NameType = N'{1}'   WHERE TypeFoodID like '{2}%'", id, nf, this.idType);
                DBServices db = new DBServices();
                db.runQuery(sql); //thực thi một truy vấn không trả về bất kỳ giá trị nào từ cơ sở dữ liệu
                LoadGridData();
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            setEnable(false);
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            AddNew = false;
            setEnable(true);
            idType = txtTypeFoodID.Text;
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Ban co chan chan muon xoa ?", "Thong bao");
            string ti = txtTypeFoodID.Text;
            string sql = $"DELETE FROM TypeFoods WHERE TypeFoodID like '{ti}%'";
            DBServices db = new DBServices();
            db.runQuery(sql); //thực thi một truy vấn không trả về bất kỳ giá trị nào từ cơ sở dữ liệu
            LoadGridData();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
