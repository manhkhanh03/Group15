using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RestaurantManager
{
    internal class DBServices
    {
        /*private string conn = @"Data Source=192.168.56.1;Initial Catalog=RestaurantManager;User ID=manhkhanh;Password=1234";*/
        private string conn = @"Data source= DESKTOP-VNHT20S\SQLEXPRESS; Initial Catalog=RestaurantManager;Integrated security=True";
        private SqlConnection mySqlConnection;

        public DBServices()
        {
            mySqlConnection = new SqlConnection(conn);
        }

        public DataTable getData(string sql)
        {
            try
            {
                SqlDataAdapter myDataAdepter = new SqlDataAdapter(sql, mySqlConnection);
                DataTable myDataTable = new DataTable();
                myDataAdepter.Fill(myDataTable);
                return myDataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void runQuery(string sql)
        {
            try
            {
                mySqlConnection.Open();
                SqlCommand mySqlCommand = new SqlCommand(sql, mySqlConnection);
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
