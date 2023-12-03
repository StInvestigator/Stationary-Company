using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationary_Company
{
    public class DatabaseManager
    {
        public string ConnectionString { get; set; }

        private SqlConnection sqlConnection { get; set; }

        public DatabaseManager(string connectionString)
        {
            ConnectionString = connectionString;
            sqlConnection = new SqlConnection(ConnectionString);
        }
        public bool OpenConnection()
        {
            try
            {
                sqlConnection.Open();
                return true;
            }
            catch (SqlException sql_ex)
            {
                throw new Exception(sql_ex.Message);
            }
        }
        public bool CloseConnection()
        {
            try
            {
                sqlConnection.Close();
                return true;
            }
            catch (SqlException sql_ex)
            {
                throw new Exception(sql_ex.Message);
            }
        }
        public void ExecuteNonQuery(string query)
        {
            using (SqlConnection _sqlConnection = new SqlConnection(ConnectionString))
            {
                if (_sqlConnection.State == System.Data.ConnectionState.Closed)
                {
                    _sqlConnection.OpenAsync();
                }
                SqlCommand sqlCommand = new SqlCommand(query, _sqlConnection);
                sqlCommand.ExecuteNonQuery();
            }
            CloseConnection();
        }
    }
}

