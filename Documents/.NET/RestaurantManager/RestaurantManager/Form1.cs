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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            frmDeskManager dm = new frmDeskManager();
            dm.Show();
        }

        private void btnOrderManagement_Click(object sender, EventArgs e)
        {
            frmOrders od = new frmOrders("", true);
            od.Show();
        }

        private void btnBillPrinting_Click(object sender, EventArgs e)
        {
            frmBill bill = new frmBill("", false);
            //bill.ShowDialog();
            bill.Show();
        }

        private void btnFood_Click(object sender, EventArgs e)
        {
            frmFood food = new frmFood();
            food.ShowDialog();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            frmStaff st = new frmStaff();
            st.ShowDialog();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            frmCustomer cr = new frmCustomer();
            cr.ShowDialog();
        }
    }
}
