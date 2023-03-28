using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Dynamic;
using System.Globalization;

namespace RestaurantManager
{
    internal class DBServices
    {
        //private string conn = @"Data Source=LAPTOP-VL2DNGOC\SQLEXPRESS;Initial Catalog=RestaurantManager;User ID=manhkhanh;Password=1234";
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
             * 3 tham số: nhận 1 câu điều kiện hoàn chỉnh( cả tên cột và giá trị cần so sánh) hoặc câu lệnh group by như các thuộc tính muốn select
             * 4 tham số: nhận tên thuộc tính sư dụng group by
             * 5 tham số: ghi đầy đủ tên cột muốn sắp xếp và kiểu sắp xếp (desc hay asc)
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
                    string value = ValueQuery[2].ToString();
                    switch (value.Contains("=") || value.Contains("AND") || value.Contains("NULL") || value.Contains("IN") || value.Contains("NOT"))
                    {
                        case true:
                            sql = $"SELECT {ValueQuery[1]} FROM {ValueQuery[0]} WHERE {ValueQuery[2]}";
                            break;
                        case false:
                            sql = $"SELECT {ValueQuery[1]} FROM {ValueQuery[0]} GROUP BY {ValueQuery[2]}";
                            break;
                    }
                    break;
                case 4:
                    sql = $"SELECT {ValueQuery[1]} FROM {ValueQuery[0]} WHERE {ValueQuery[2]} " +
                        $"GROUP BY {ValueQuery[3]}";
                    break;
                case 5:
                    sql = $"SELECT {ValueQuery[1]} FROM {ValueQuery[0]} WHERE {ValueQuery[2]} " +
                        $"GROUP BY {ValueQuery[3]} " +
                        $"ORDER BY {ValueQuery[4]}";
                    break;
            }

            return getData(sql);
        }
       
        // insert into ... values
        public void queryInsertInto(string className, dynamic propertiesName)
        {
            /* tham số
             * 1 tham số: tên thuộc tính(tên cột)
             * 2 tham số: tham số thứ 2 bắt buộc là 1 object, và ghi đúng thứ tự tên cột cần set
             */
            int index = ((IDictionary<string, object>)propertiesName).Count;
            string[] attribute = new string[index];

            int i = 0;
            string sql = $"INSERT INTO {className} VALUES (";
            foreach (var prop in (IDictionary<string, object>)propertiesName)
            {
                attribute[i] = prop.Value.ToString();
                switch (prop.Value.GetType().ToString())
                {
                    case "System.String":
                        sql += i < index - 1 ? $"'{attribute[i]}', " : $"'{attribute[i]}') ";
                        break;
                    case "System.Int32":
                    case "System.Decimal":
                        sql += i < index - 1 ? $"{attribute[i]}, " : $"{attribute[i]}) ";
                        break;
                }
                i++;
            }
            MessageBox.Show(sql);

            runQuery(sql); 
        }

        // dalete ... 
        public void queryDelete(string className, params object[] where)
        {
            /*tham số
             *1 tham số: tên thuộc tính(tên cột)
             * 2 tham số: 1 câu điều kiện đầy đủ
            */

            string sql = $"DELETE FROM {className} ";
            sql += where.Length == 0 ? "" : $"WHERE {where[0]}";

            runQuery(sql);
        }

        // UPDATE 
        public void queryUpdate(string className, dynamic propertiesName, params object[] ValueQuery)
        {
            /* tham số
             * 1 tham số: tên thuộc tính(tên cột)
             * 2 tham số: tham số thứ 2 bắt buộc là 1 object, các tên cột cần set và các tên key dynamic phải đặt giống tên cột
             * 3 tham số: điều kiện đầy đủ(cả tên cột và giá trị)
             */
            int index = ((IDictionary<string, object>)propertiesName).Count;
            string[] attribute = new string[index];

            int i = 0;
            string sql = $"UPDATE {className} SET ";
            foreach (var prop in (IDictionary<string, object>)propertiesName)
            {
                attribute[i] = prop.Value.ToString();
                switch (prop.Value.GetType().ToString())
                {
                    case "System.String":
                        sql += i < index - 1 ? $"{prop.Key} = N'{attribute[i]}', " : $"{prop.Key} = N'{attribute[i]}' ";
                        break;
                    case "System.Int32":
                    case "System.Decimal":
                        sql += i < index - 1 ? $"{prop.Key} = {attribute[i]}, " : $"{prop.Key} = {attribute[i]} ";
                        break;
                }
                i++;
            }

            sql += $" WHERE {ValueQuery[0]}";

            runQuery(sql);
        }

        //Thủ tục

    }
}
