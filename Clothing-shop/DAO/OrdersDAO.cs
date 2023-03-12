using Clothing_shop.DBConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace Clothing_shop.DAO
{
    public class OrderDAO
    {
        private SqlConnection connection;

        public OrderDAO()
        {

        }

        public List<Orders> GetAllOrders()
        {
            List<Orders> orders = new List<Orders>();

            using (connection = new DBConnect().getConnection())
            {
                string query = "SELECT * FROM Orders";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Orders order = new Orders();
                        order.OrderID = reader.GetInt32(0);
                        order.CustomerID = reader.GetInt32(1);
                        order.EmployeeID = reader.GetInt32(2);
                        order.OrderDate = reader.GetDateTime(3);
                        order.TotalAmount = reader.GetDouble(4);
                        order.Status = reader.GetString(5);
                        order.ModifiedDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);

                        orders.Add(order);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return orders;
        }

        public Orders GetOrderById(int orderId)
        {
            Orders order = null;
            using (connection = new DBConnect().getConnection())
            {
                connection.Open();

                string query = "SELECT * FROM Orders WHERE OrderID = @orderId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@orderId", orderId);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    order = new Orders();
                    order.OrderID = reader.GetInt32(0);
                    order.CustomerID = reader.GetInt32(1);
                    order.EmployeeID = reader.GetInt32(2);
                    order.OrderDate = reader.GetDateTime(3);
                    order.TotalAmount = reader.GetDouble(4);
                    order.Status = reader.GetString(5);
                    order.ModifiedDate = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                }


                reader.Close();
            }

            return order;
        }

        public int AddOrder(Orders order)
        {
            int orderId = 0;

            using (connection = new DBConnect().getConnection())
            {
                connection.Open();

                string query = "INSERT INTO Orders (CustomerID, EmployeeID, TotalAmount) " +
                    "VALUES (@CustomerID, @employeeId, @totalAmount);" +
                    "SELECT CAST(SCOPE_IDENTITY() AS INT)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", order.CustomerID);
                command.Parameters.AddWithValue("@employeeId", order.EmployeeID);
                command.Parameters.AddWithValue("@totalAmount", order.TotalAmount);
                orderId = (int)command.ExecuteScalar();
            }

            return orderId;
        }

        public void UpdateOrder(Orders order)
        {
            using (connection = new DBConnect().getConnection())
            {
                connection.Open();

                string query = "UPDATE Orders SET CustomerID = @customerId, EmployeeID = @employeeId, " +
                    "TotalAmount = @totalAmount, Status = @status, ModifiedDate = GETDATE() " +
                    "WHERE OrderID = @orderId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@customerId", order.CustomerID);
                command.Parameters.AddWithValue("@employeeId", order.EmployeeID);
                command.Parameters.AddWithValue("@totalAmount", order.TotalAmount);
                command.Parameters.AddWithValue("@status", order.Status);
                command.Parameters.AddWithValue("@orderId", order.OrderID);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteOrder(int orderId)
        {
            using (connection = new DBConnect().getConnection())
            {
                connection.Open();

                string query = "DELETE FROM Orders WHERE OrderID = @orderId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@orderId", orderId);
                command.ExecuteNonQuery();
            }
        }
        public int GetHighestID()
        {
            int highestID = 0;
            using (connection = new DBConnect().getConnection())
            {
                connection.Open();

                string query = "SELECT MAX(OrderID) FROM Orders";
                SqlCommand command = new SqlCommand(query, connection);

                highestID = (int)command.ExecuteScalar();
            }

            return highestID;
        }
        
    }
}