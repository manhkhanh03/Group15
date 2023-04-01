﻿using System;
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
    public partial class frmCalendar : Form
    {
        bool AddNew = false;
        public frmCalendar()
        {
            InitializeComponent();
        }

        private void Calendar_Load(object sender, EventArgs e)
        {
            LoadGridData();
        }
        private void LoadGridData()
        {
            DBServices db = new DBServices();
            string sql = "select * from Calendars";
            dgvCalendar.DataSource = db.getData(sql);
            SetEnable(false);
        }
        private void SetEnable(bool check)
        {
            txtCalendarID.Enabled = false;
            cbStaffID.Enabled = check;
            btnAddNew.Enabled = !check;
            btnDelete.Enabled = !check;
            btnEdit.Enabled = !check;
            btnExit.Enabled = !check;
            btnCancel.Enabled = check;
            btnSave.Enabled = check;
            dgvCalendar.Enabled = !check;
        }

        private void dgvCalendar_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0) 
            {
                txtCalendarID.Text = dgvCalendar.Rows[i].Cells["CalendarID"].Value.ToString();
                cbStaffID.Text = dgvCalendar.Rows[i].Cells["StaffID"].Value.ToString();
                dtpDate.Text = dgvCalendar.Rows[i].Cells["Date"].Value.ToString();
                if (dgvCalendar.Rows[i].Cells["Shift"].Value.ToString() == "Ca sáng") rbCasang.Checked = true;
                else rbCasang.Checked = false;
                if (dgvCalendar.Rows[i].Cells["Shift"].Value.ToString() == "Ca chiều") rbCachieu.Checked = true;
                else rbCachieu.Checked = false;
                if(dgvCalendar.Rows[i].Cells["Shift"].Value.ToString() == "Ca tối") rbCachieu.Checked = true;
                else rbCatoi.Checked = false;
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            AddNew = true;
            SetEnable(true);
            txtCalendarID.Clear();
        
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string ci = txtCalendarID.Text;
            string sh = "";
            if(rbCasang.Checked) 
            {
                 sh = rbCatoi.Text; 
            }
            else if(rbCachieu.Checked) 
            {
                 sh = rbCasang.Text;
            }
            else if(rbCatoi.Checked) 
            {
                 sh = rbCatoi.Text;
            }
            string cs = cbStaffID.Text;
            string da = dtpDate.Text;
            if(AddNew)
            {
                
                int count = 0;
                count = dgvCalendar.Rows.Count;
                ci = count.ToString();
                AddNew = true;
                SetEnable(true);
                //Ghi khi nhấp vào nút thêm mới
                string sql = string.Format("INSERT INTO Calendars ( CalendarID, StaffID ,Date , Shift ) VALUES  ('{0}','{1}','{2}',N'{3}')", ci, cs, da, sh);
                DBServices db = new DBServices();
                db.runQuery(sql); //thực thi một truy vấn không trả về bất kỳ giá trị nào từ cơ sở dữ liệu
                LoadGridData();
            }
            else
            {

                ci = txtCalendarID.Text;
                string sql = string.Format("UPDATE Calendars SET " +
                    "StaffID = '{0}' ," +
                    "Date = '{1}' ," +
                    "Shift = N'{2}'   WHERE  CalendarID = {4}", cs,da,sh,ci);
                DBServices db = new DBServices();
                db.runQuery(sql); //thực thi một truy vấn không trả về bất kỳ giá trị nào từ cơ sở dữ liệu
                LoadGridData();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetEnable(false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            AddNew = false;
            SetEnable(true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ban co chan chan muon xoa ?", "Thong bao");
            string ci = txtCalendarID.Text;
            string sql = $"DELETE FROM Calendars WHERE CalendarID like '{ci}%'";
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