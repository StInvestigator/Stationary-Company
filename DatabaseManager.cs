using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
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
        public void InsertStationaryType(int id, string name, int amount)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sql = "INSERT INTO StationaryTypes (Id, Name, Amount) VALUES (@Id, @Name, @Amount)";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Amount", amount);

                    command.ExecuteNonQuery();
                }
            }
        }
        public void InsertManager(int id, string name)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sql = "INSERT INTO Managers (Id, Name) VALUES (@Id, @Name)";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Name", name);

                    command.ExecuteNonQuery();
                }
            }
        }
        public void InsertStationary(int id, string name, int typeId, int amount, decimal price)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sql = "INSERT INTO Stationery (Id, Name, TypeId, Amount, Price) VALUES (@Id, @Name, @TypeId, @Amount, @Price)";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@TypeId", typeId);
                    command.Parameters.AddWithValue("@Amount", amount);
                    command.Parameters.AddWithValue("@Price", price);

                    command.ExecuteNonQuery();
                }
            }
        }
        public void InsertBuyer(int id, string firma)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sql = "INSERT INTO Buyers (Id, Firma) VALUES (@Id, @Firma)";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Firma", firma);

                    command.ExecuteNonQuery();
                }
            }
        }
        public void InsertSelling(int id, string name, string type, int amount, decimal price, string firma, DateTime date, string managerName)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sql = "INSERT INTO Sellings (Id, Name, Type, Amount, Price, Firma, Date, ManagerName) " +
                             "VALUES (@Id, @Name, @Type, @Amount, @Price, @Firma, @Date, @ManagerName)";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Type", type);
                    command.Parameters.AddWithValue("@Amount", amount);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@Firma", firma);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@ManagerName", managerName);

                    command.ExecuteNonQuery();
                }
            }
        }
        public void UpdateStationaryType(int id, string name, int amount)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sql = "UPDATE StationaryTypes SET Name = @Name, Amount = @Amount WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Amount", amount);

                    command.ExecuteNonQuery();
                }
            }
        }
        public void UpdateManager(int id, string name)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sql = "UPDATE Managers SET Name = @Name WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Name", name);

                    command.ExecuteNonQuery();
                }
            }
        }
        public void UpdateStationary(int id, string name, int typeId, int amount, decimal price)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sql = "UPDATE Stationery SET Name = @Name, TypeId = @TypeId, Amount = @Amount, Price = @Price WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@TypeId", typeId);
                    command.Parameters.AddWithValue("@Amount", amount);
                    command.Parameters.AddWithValue("@Price", price);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateBuyer(int id, string firma)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sql = "UPDATE Buyers SET Firma = @Firma WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Firma", firma);

                    command.ExecuteNonQuery();
                }
            }
        }
        public void DeleteStationaryType(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sql = "DELETE FROM StationaryTypes WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteManager(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sql = "DELETE FROM Managers WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteStationary(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sql = "DELETE FROM Stationery WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteBuyer(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sql = "DELETE FROM Buyers WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
        }
        public void ShowStationary(string procName, string paramName = "", string paramVal = "")
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(procName, connection);
                command.CommandType = CommandType.StoredProcedure;
                if(paramVal != "" && paramName != "")
                {
                    SqlParameter nameParam = new SqlParameter
                    {
                        ParameterName = paramName,
                        Value = paramVal
                    };
                    command.Parameters.Add(nameParam);
                }
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string typeName = reader.GetString(2);
                            int amount = reader.GetInt32(3);
                            SqlMoney price = reader.GetSqlMoney(4);
                            Console.WriteLine($"\n{reader.GetName(0)}:\t{id}\n{reader.GetName(1)}:\t{name}\n{reader.GetName(2)}:\t{typeName}\n{reader.GetName(3)}:\t{amount}\n{reader.GetName(4)}:\t{price}$\n");
                        }
                    }
                }
            }
        }
        public void ShowSellings(string procName, string paramName = "", string paramVal = "")
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(procName, connection);
                command.CommandType = CommandType.StoredProcedure;
                if (paramVal != "" && paramName != "")
                {
                    SqlParameter nameParam = new SqlParameter
                    {
                        ParameterName = paramName,
                        Value = paramVal
                    };
                    command.Parameters.Add(nameParam);
                }
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string typeName = reader.GetString(2);
                            int amount = reader.GetInt32(3);
                            SqlMoney price = reader.GetSqlMoney(4);
                            string firma = reader.GetString(5);
                            DateTime date = reader.GetDateTime(6);
                            string manager = reader.GetString(7);

                            Console.WriteLine($"\n{reader.GetName(0)}:\t\t{id}\n{reader.GetName(1)}:\t\t{name}\n{reader.GetName(2)}:\t\t{typeName}\n{reader.GetName(3)}:\t\t{amount}\n{reader.GetName(4)}:\t\t{price}$" +
                                $"\n{reader.GetName(5)}:\t\t{firma}\n{reader.GetName(6)}:\t\t{date}\n{reader.GetName(7)}:\t{manager}");
                        }
                    }
                }
            }
        }
        public void ShowString(string procName, string paramName = "", int? paramVal = null)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(procName, connection);
                command.CommandType = CommandType.StoredProcedure;
                if (paramVal != null && paramName != "")
                {
                    SqlParameter nameParam = new SqlParameter
                    {
                        ParameterName = paramName,
                        Value = paramVal
                    };
                    command.Parameters.Add(nameParam);
                }
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            Console.WriteLine($"\n{reader.GetName(0)}:\t\t{id}\n{reader.GetName(1)}:\t{name}\n");
                        }
                    }
                }
            }
        }
        public void ShowStringInt(string procName)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(procName, connection);
                command.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string name = reader.GetString(0);
                            int num = reader.GetInt32(1);
                            Console.WriteLine($"\n{reader.GetName(0)}:\t{name}\n{reader.GetName(1)}:\t{num}\n");
                        }
                    }
                }
            }
        }
        public void ShowStringDecimal(string procName, string param1Name = "", DateOnly? param1Val = null, string param2Name = "", DateOnly? param2Val = null)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(procName, connection);
                command.CommandType = CommandType.StoredProcedure;
                if (param1Val != null && param1Name != "")
                {
                    SqlParameter nameParam = new SqlParameter
                    {
                        ParameterName = param1Name,
                        Value = param1Val
                    };
                    command.Parameters.Add(nameParam);
                }
                if (param2Val != null && param2Name != "")
                {
                    SqlParameter nameParam = new SqlParameter
                    {
                        ParameterName = param2Name,
                        Value = param2Val
                    };
                    command.Parameters.Add(nameParam);
                }
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string name = reader.GetString(0);
                            decimal num = Math.Round(reader.GetDecimal(1),2);
                            Console.WriteLine($"\n{reader.GetName(0)}:\t{name}\n{reader.GetName(1)}:\t{num}\n");
                        }
                    }
                }
            }
        }
    }
}

