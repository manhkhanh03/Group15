using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManager
{
    public partial class frmStaff : Form
    {
        bool AddNew = false;
        public frmStaff()
        {
            InitializeComponent();
        }

        private void frmStaff_Load(object sender, EventArgs e)
        {
            LoadGridData();
        }
        private void LoadGridData()
        {
            DBServices db = new DBServices();
            //string sql = "SELECT * FROM Staffs ";
            //dgvStaff.DataSource = db.getData(sql);
            dgvStaff.DataSource = db.querySelect("Staffs");
            setEnable(false);
        }
        private void setEnable(bool check)
        {
            txtStaffID.Enabled = false;
            txtNameStaff.Enabled = check;
            mtxtPhone.Enabled = check;
            txtPosition.Enabled = check;
            txtSalary.Enabled = check;
            txtAddress.Enabled = check;
            btnAddNew.Enabled = !check;
            btnDelete.Enabled = !check;
            btnEdit.Enabled = !check;
            btnExit.Enabled = !check;
            btnCancel.Enabled = check;
            btnSave.Enabled = check;
            dgvStaff.Enabled = !check;

        }

        private void dgvStaff_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0)
            {
                txtStaffID.Text = dgvStaff.Rows[i].Cells["StaffID"].Value.ToString();
                txtNameStaff.Text = dgvStaff.Rows[i].Cells["NameStaff"].Value.ToString();
                mtxtPhone.Text = dgvStaff.Rows[i].Cells["Phone"].Value.ToString();
                txtPosition.Text = dgvStaff.Rows[i].Cells["Position"].Value.ToString();
                txtSalary.Text = dgvStaff.Rows[i].Cells["Salary"].Value.ToString();
                txtAddress.Text = dgvStaff.Rows[i].Cells["Address"].Value.ToString();
                dtpBirthday.Text = dgvStaff.Rows[i].Cells["Birthday"].Value.ToString();
                if (dgvStaff.Rows[i].Cells["Gender"].Value.ToString() == "Nam") rbBoy.Checked = true;
                else rbBoy.Checked = false;
                if (dgvStaff.Rows[i].Cells["Gender"].Value.ToString() == "Nữ") rbGirl.Checked = true;
                else rbGirl.Checked = false;


            }
        }

        
      
        

        private void cbSapXep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSapXep.SelectedIndex == 0)
            {
                dgvStaff.Columns["NameStaff"].SortMode = DataGridViewColumnSortMode.Automatic;
                this.dgvStaff.Sort(this.dgvStaff.Columns["NameStaff"], ListSortDirection.Ascending);
                
                

            }
            else
            {
                dgvStaff.Columns["StaffID"].SortMode = DataGridViewColumnSortMode.Automatic;
                this.dgvStaff.Sort(this.dgvStaff.Columns["StaffID"], ListSortDirection.Ascending);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
                string se = txtSearch.Text;
                string sql = $"select * from Staffs WHERE NameStaff like N'%{se}%'";
                DBServices db = new DBServices();
                dgvStaff.DataSource = db.getData(sql); //thực thi một truy vấn không trả về bất kỳ giá trị nào từ cơ sở dữ liệu
                setEnable(false);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            setEnable(false);
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            frmCalendar  fc =  new frmCalendar();
            fc.ShowDialog();
        }

        private void btnAddNew_Click_1(object sender, EventArgs e)
        {
            AddNew = true;
            setEnable(true);
            txtNameStaff.Clear();
            txtAddress.Clear();
            mtxtPhone.Clear();
            txtPosition.Clear();
            txtSalary.Clear();
            DBServices db = new DBServices();
            string ssql = "declare @id int select @id = substring(max(Staffid) ,3,3)from staffs select @id +1 ";
            DataTable dt = db.getData(ssql);
            string upid = "NV" + (int.Parse(dt.Rows[0][0].ToString()) < 10 ? "00" + dt.Rows[0][0].ToString() : "0" + dt.Rows[0][0].ToString());
            txtStaffID.Text = upid; 
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            string si = txtStaffID.Text;
            string ns = txtNameStaff.Text;
            string ph = mtxtPhone.Text;
            string po = txtPosition.Text;
            string sa = txtSalary.Text;
            string ad = txtAddress.Text;
            string ge = (rbBoy.Checked) ? rbBoy.Text : rbGirl.Text;
            string bi = dtpBirthday.Text;

            if (AddNew)
            {
                /*    string ma = "";
                    if (dgvStaff.Rows.Count <= 0)
                    {
                        ma = "NV001";
                    }
                    else
                    {

                        int k = 1;
                        ma = "NV";
                        k = Convert.ToInt32(dgvStaff.Rows[dgvStaff.Rows.Count - 1].[0].Value.ToString().Substring(2, 3));
                        k = k + 1;
                        if (k < 10)
                        {
                            ma = ma + "00";
                        }
                        else if (k < 100)
                        {
                            ma = ma + "0";
                        }
                        ma = ma + k.ToString();

                    }*/

                DBServices db = new DBServices();
                AddNew = true;
                setEnable(true);
                //Ghi khi nhấp vào nút thêm mới
                string sql = string.Format("INSERT INTO Staffs ( StaffID, NameStaff , Gender , Address,  Birthday, Phone , Position , Salary ) VALUES  ('{0}',N'{1}',N'{2}',N'{3}','{4}',N'{5}','{6}',{7})", si, ns, ge, ad, bi, ph, po, sa);
                db.runQuery(sql); //thực thi một truy vấn không trả về bất kỳ giá trị nào từ cơ sở dữ liệu
                LoadGridData();
            }

            else
            {
                //Ghi khi nhấp vào nút sửa 

                string sql = string.Format("UPDATE Staffs SET " +
                    "NameStaff = N'{0}' ," +
                    "Gender = N'{1}' ," +
                    "Address = N'{2}' ," +
                    "Birthday = '{3}' ," +
                    "Phone = '{4}' ," +
                    "Position = N'{5}' ," +
                    "Salary = '{6}'  WHERE StaffID = {7}", ns, ge, ad, ph, po, sa);
                DBServices db = new DBServices();
                db.runQuery(sql); //thực thi một truy vấn không trả về bất kỳ giá trị nào từ cơ sở dữ liệu
                LoadGridData();
            }
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            AddNew = false;
            setEnable(true);
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Ban co chan chan muon xoa ?", "Thong bao");
            string si = txtStaffID.Text;
            string sql = $"DELETE FROM Staffs WHERE StaffID like '{si}%'";
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
