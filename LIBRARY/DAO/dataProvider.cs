using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace LIBRARY.DataClass
{
    class dataProvider
    {
        public static string connectionString = @"Data Source=DESKTOP-I2KUT1M\CITADEL;Initial Catalog=QuanLyThuVien;User ID=IT008; Password=it008";
        public DataTable dataTable(string cmd)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable tb = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd, connection);
                adapter.Fill(tb);
                connection.Close();
                return tb;
            }
        }
        public void Excute(string cmd)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(cmd, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
