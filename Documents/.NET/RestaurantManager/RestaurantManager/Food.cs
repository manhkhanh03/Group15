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
    public partial class frmFood : Form
    {
        bool AddNew = false;
        public frmFood()
        {
            InitializeComponent();
        }

        private void frmFood_Load(object sender, EventArgs e)
        {
            LoadGridData();
            GetDataTypefood();
        }
        private void GetDataTypefood()
        {
            DBServices db = new DBServices();
            cbTypeFoodID.DisplayMember = "TypeFoodID";
            cbTypeFoodID.ValueMember = "TypeFoodID";
            string sql = "select * from TypeFoods ";
            cbTypeFoodID.DataSource = db.getData(sql);
        }
        private void LoadGridData()
        {
            DBServices db = new DBServices();
            string sql = "SELECT * FROM Foods ";
            dgvListFood.DataSource = db.getData(sql);
            setEnable(false);
        }
        private void setEnable(bool check)
        {
            txtFoodID.Enabled = false;
            txtNameFood.Enabled = check;
            txtPrice.Enabled = check;
            txtDescription.Enabled = check;
            cbTypeFoodID.Enabled = check;
            btnAddNew.Enabled = !check;
            btnDelete.Enabled = !check;
            btnEdit.Enabled = !check;
            btnExit.Enabled = !check;
            btnCancel.Enabled = check;
            btnSave.Enabled = check;
            dgvListFood.Enabled = !check;


        }

        private void dgvListFood_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0)
            {
                txtFoodID.Text = dgvListFood.Rows[i].Cells["FoodID"].Value.ToString();
                cbTypeFoodID.Text = dgvListFood.Rows[i].Cells["TypeFoodID"].Value.ToString();
                txtNameFood.Text = dgvListFood.Rows[i].Cells["NameFood"].Value.ToString();
                txtDescription.Text = dgvListFood.Rows[i].Cells["Description"].Value.ToString();
                txtPrice.Text = dgvListFood.Rows[i].Cells["Price"].Value.ToString();

            }
        }

  
        private void btnMenu_Click(object sender, EventArgs e)
        {
            frmTypeFood tf = new frmTypeFood();
            tf.ShowDialog();
        }

        private void btnAddNew_Click_1(object sender, EventArgs e)
        {
            AddNew = true;
            setEnable(true);
            txtFoodID.Clear();
            txtPrice.Clear();
            txtNameFood.Clear();
            txtDescription.Clear();
            txtNameFood.Focus();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            string fi;
            string nf = txtNameFood.Text;
            string ti = cbTypeFoodID.Text;
            string pr = txtPrice.Text;
            string df = txtDescription.Text;

            if (AddNew)
            {
                int count = 0;
                count = dgvListFood.Rows.Count;
                fi = count.ToString();
                AddNew = true;
                setEnable(true);
                //Ghi khi nhấp vào nút thêm mới
                string sql = string.Format("INSERT INTO Foods ( FoodID, NameFood ,TypeFoodID , Price , Description ) VALUES  ('{0}',N'{1}',N'{2}','{3}',N'{4}')", fi, nf, ti, pr, df);

                DBServices db = new DBServices();
                db.runQuery(sql); //thực thi một truy vấn không trả về bất kỳ giá trị nào từ cơ sở dữ liệu
                LoadGridData();
            }

            else
            {
                //Ghi khi nhấp vào nút sửa 

                fi = txtFoodID.Text;
                string sql = string.Format("UPDATE Foods SET " +
                    "NameFood = N'{0}' ," +
                    "TypeFoodID = N'{1}' ," +
                    "Price = '{2}' ," +
                    "Description = N'{3}'  WHERE FoodID = {4}", nf, ti, pr, df, fi);
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
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Ban co chan chan muon xoa ?", "Thong bao");
            string fi = txtFoodID.Text;
            string sql = $"DELETE FROM Foods WHERE FoodID like '{fi}%'";
            DBServices db = new DBServices();
            db.runQuery(sql); //thực thi một truy vấn không trả về bất kỳ giá trị nào từ cơ sở dữ liệu
            LoadGridData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
