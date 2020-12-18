using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace LIBRARY.DataClass
{
    public class dataProvider
    {
        public static string connectionString = @"Data Source=DESKTOP-I2KUT1M\CITADEL;Initial Catalog=QLTV;Integrated Security=True";
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

        public object ExcuteScalar(string cmd)
        {
            object obj;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(cmd, connection);
                obj = command.ExecuteScalar();
                connection.Close();
            }
            return obj;
        }

        public SqlDataReader ExcuteReader(string cmd)
        {
             SqlDataReader obj;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(cmd, connection);
                obj = command.ExecuteReader();
                connection.Close();
            }
            return obj;
        }
    }
}
