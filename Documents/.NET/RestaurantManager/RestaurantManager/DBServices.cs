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
        private string conn = @"Data Source=LAPTOP-VL2DNGOC\SQLEXPRESS;Initial Catalog=RestaurantManager;Integrated Security=True";

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

        /* Truy vấn sql */

        // Select * from 
        public DataTable querySelect(params object[] ValueQuery)
        {
            /* Tham số cần lưu ý 
             * 1 tham số: tên bảng
             * 2 tham số: tên thuộc tính (tên cột) muốn select
             * 3 tham số: nhận 1 câu điều kiện hoàn chỉnh( cả tên cột và giá trị cần so sánh
             * 4 tham số: nhận tên thuộc tính sư dụng group by
             */
            string sql = "";

            switch (ValueQuery.Length)
            {
                case 1: 
                    sql = $"SELECT * FROM {ValueQuery[0]}";
                    break;
                case 2:
                    sql = $"SELECT {ValueQuery[1]} FROM {ValueQuery[0]}";
                    break;
                case 3:
                    //for (int key = 0; key < ValueQuery[2].ToString().Length; key++)
                    //{
                    //MessageBox.Show(ValueQuery[2].ToString().IndexOf("and").ToString());
                    //if (ValueQuery[2].ToString()[key].ToString() != "=" && ValueQuery[2].ToString()[key].ToString() != "AND")
                    //{
                    //sql = $"SELECT {ValueQuery[1]} FROM {ValueQuery[0]} WHERE {ValueQuery[2]}";
                    //}
                    string value = ValueQuery[2].ToString();
                    switch (value.Contains("=") && value.Contains("AND") && value.Contains("NULL") && value.Contains("IS"))
                    {
                        case true:
                            sql = $"SELECT {ValueQuery[1]} FROM {ValueQuery[0]} WHERE {ValueQuery[2]}";
                            break;
                        case false:
                            sql = $"SELECT {ValueQuery[1]} FROM {ValueQuery[0]} GROUP BY {ValueQuery[2]}";
                            break;
                    }
                    //}
                    break;
                case 4:
                    sql = $"SELECT {ValueQuery[1]} FROM {ValueQuery[0]} WHERE {ValueQuery[2]} " +
                        $"GROUP BY {ValueQuery[3]}";
                    break;
            }

            return getData(sql);
            //foreach (object key in ValueQuery)
            //{
            //    MessageBox.Show(key.ToString());
            //}
        }

        // insert into ... values

        // dalete ... 

        //Thủ tục

    }
}
