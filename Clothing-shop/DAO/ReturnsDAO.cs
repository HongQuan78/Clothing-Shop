using Clothing_shop.DBConnection;
using Clothing_shop.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Clothing_shop.DAO
{
    public class ReturnsDAO
    {
        private SqlConnection connection;

        public ReturnsDAO()
        {
          
        }

        public int Create(Returns returns)
        {
            using (connection = new DBConnect().getConnection())
            {
                connection.Open();

                string query = "INSERT INTO Returns (OrderID, Reason) VALUES (@OrderID, @Reason); SELECT SCOPE_IDENTITY()";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OrderID", returns.OrderID);
                    command.Parameters.AddWithValue("@Reason", returns.Reason);
                    int newId = Convert.ToInt32(command.ExecuteScalar());
                    returns.ReturnID = newId;
                    return newId;
                }
            }
        }

        public Returns GetById(int id)
        {
            using (connection = new DBConnect().getConnection())
            {
                connection.Open();

                string query = "SELECT ReturnID, OrderID, Reason FROM Returns WHERE ReturnID = @ReturnID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ReturnID", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Returns returns = new Returns(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2));
                            return returns;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public List<Returns> GetAll()
        {
            using (connection = new DBConnect().getConnection())
            {
                connection.Open();

                string query = "SELECT ReturnID, OrderID, Reason FROM Returns";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    List<Returns> returnsList = new List<Returns>();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Returns returns = new Returns(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2));
                            returnsList.Add(returns);
                        }
                    }
                    return returnsList;
                }
            }
        }

        public void Update(Returns returns)
        {
            using (connection = new DBConnect().getConnection())
            {
                connection.Open();

                string query = "UPDATE Returns SET OrderID = @OrderID, Reason = @Reason WHERE ReturnID = @ReturnID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OrderID", returns.OrderID);
                    command.Parameters.AddWithValue("@Reason", returns.Reason);
                    command.Parameters.AddWithValue("@ReturnID", returns.ReturnID);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (connection = new DBConnect().getConnection())
            {
                connection.Open();

                string query = "DELETE FROM Returns WHERE ReturnID = @ReturnID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ReturnID", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
