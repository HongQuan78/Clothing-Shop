using Clothing_shop.DBConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
                        order.TotalAmount = reader.IsDBNull(4) ? 0 : reader.GetDouble(4);
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
                    order.TotalAmount = reader.IsDBNull(4) ? 0 : reader.GetDouble(4);
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
        public List<Orders> SearchOrder(string keyword)
        {
            List<Orders> orders = new List<Orders>();

            using (connection = new DBConnect().getConnection())
            {
                string query = "SELECT * FROM Orders WHERE OrderID LIKE @keyword OR CustomerID LIKE @keyword OR EmployeeID LIKE @keyword OR Status LIKE @keyword";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

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
                        order.TotalAmount = reader.IsDBNull(4) ? 0 : reader.GetDouble(4);
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
        public void UpdateOrderStatus(int orderId, string status)
        {
            using (connection = new DBConnect().getConnection())
            {
                connection.Open();

                string query = "UPDATE Orders SET Status = @status, ModifiedDate = GETDATE() " +
                    "WHERE OrderID = @orderId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@status", status);
                command.Parameters.AddWithValue("@orderId", orderId);

                command.ExecuteNonQuery();
            }
        }

        public List<Orders> GetOrderByDate(DateTime date)
        {
            List<Orders> orders = new List<Orders>();

            using (connection = new DBConnect().getConnection())
            {
                string query = "select * from dbo.Orders where CONVERT(DATE, OrderDate) = CONVERT(DATE, @Date)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Date", date.Date);
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
                        order.TotalAmount = reader.IsDBNull(4) ? 0 : reader.GetDouble(4);
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

        public List<Orders> GetOrderByMonth(string month)
        {
            List<Orders> orders = new List<Orders>();

            using (connection = new DBConnect().getConnection())
            {
                string query = "select * from orders where Month(OrderDate) = @month";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@month", month);
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
                        order.TotalAmount = reader.IsDBNull(4) ? 0 : reader.GetDouble(4);
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

        public List<Orders> GetOrderByProductName(string name)
        {
            List<Orders> orders = new List<Orders>();

            using (connection = new DBConnect().getConnection())
            {
                string query = "SELECT o.OrderID, o.CustomerID, o.EmployeeID, o.OrderDate, o.TotalAmount, o.[Status], o.ModifiedDate\r\nFROM Orders o\r\nJOIN Customers c ON o.CustomerID = c.CustomerID\r\nJOIN OrderItems oi ON o.OrderID = oi.OrderID\r\nJOIN Products p ON oi.ProductID = p.ProductID\r\nWHERE p.ProductName like N'%@name%'";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", name);
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
                        order.TotalAmount = reader.IsDBNull(4) ? 0 : reader.GetDouble(4);
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

        public double GetTotalAmount()
        {
            double total = 0;
            using (connection = new DBConnect().getConnection())
            {
                string query = "SELECT SUM(TotalAmount) AS TotalAmountSum FROM Orders";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        total = reader.GetDouble(0);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return total;
        }


        public double GetTotalAmountByDate(DateTime date)
        {
            double total = 0;
            using (connection = new DBConnect().getConnection())
            {
                string query = "SELECT SUM(TotalAmount) AS TotalAmountSum FROM Orders" +
                    " Where CONVERT(DATE, OrderDate) = CONVERT(DATE, @Date)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Date", date.Date);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        total = reader.GetDouble(0);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return total;
        }

        public double GetTotalAmountByProductName(string name)
        {
            double total = 0;
            using (connection = new DBConnect().getConnection())
            {
                string query = "SELECT SUM(o.TotalAmount) AS TotalAmountSum " +
                    "FROM Orders o " +
                    "JOIN Customers c ON o.CustomerID = c.CustomerID " +
                    "JOIN OrderItems oi ON o.OrderID = oi.OrderID " +
                    "JOIN Products p ON oi.ProductID = p.ProductID " +
                    "WHERE p.ProductName like N@Name";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        total = reader.GetDouble(0);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return total;
        }


        public double GetTotalAmountByMonth(DateTime date)
        {
            double total = 0;
            using (connection = new DBConnect().getConnection())
            {
                string query = "SELECT SUM(TotalAmount) AS TotalAmountSum FROM Orders" +
                               " WHERE YEAR(OrderDate) = @Year AND MONTH(OrderDate) = @Month";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Year", date.Year);
                command.Parameters.AddWithValue("@Month", date.Month);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        total = reader.GetDouble(0);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return total;
        }




        public Dictionary<string, double> GetChartData()
        {
            Dictionary<string, double> data = new Dictionary<string, double>();

            using (connection = new DBConnect().getConnection())
            {
                connection.Open();
                int currentYear = DateTime.Now.Year;
                string query = "SELECT MONTH(OrderDate) AS Month, YEAR(OrderDate) AS Year, SUM(TotalAmount) AS TotalRevenue " +
                               "FROM Orders " +
                               $"WHERE OrderDate BETWEEN '{currentYear}-01-01' AND '{currentYear}-12-31' " +
                               "GROUP BY MONTH(OrderDate), YEAR(OrderDate) " +
                               "ORDER BY YEAR(OrderDate), MONTH(OrderDate)";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string monthYear = reader.GetInt32(0).ToString() + "/" + reader.GetInt32(1).ToString();
                    double totalRevenue = reader.GetDouble(2);

                    data.Add(monthYear, totalRevenue);
                }
            }

            return data;
        }

        //get order by month


    }
}