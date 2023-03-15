using Clothing_shop.DBConnection;
using Clothing_shop.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothing_shop.DAO
{
    public class OrderItemsDAO
    {
        private SqlConnection connection;

        public OrderItemsDAO()
        {
        }

        public void AddOrderItem(OrderItems orderItem)
        {
            using (connection = new DBConnect().getConnection())
            {
                string sql = "INSERT INTO OrderItems (OrderID, ProductID, OrderItems_Quantity) VALUES (@OrderID, @ProductID, @OrderItems_Quantity)";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@OrderID", orderItem.OrderID);
                    command.Parameters.AddWithValue("@ProductID", orderItem.ProductID);
                    command.Parameters.AddWithValue("@OrderItems_Quantity", orderItem.OrderItems_Quantity);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateOrderItem(OrderItems orderItem)
        {
            using (connection = new DBConnect().getConnection())
            {
                string sql = "UPDATE OrderItems SET OrderItems_Quantity = @OrderItems_Quantity WHERE OrderID = @OrderID AND ProductID = @ProductID";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@OrderID", orderItem.OrderID);
                    command.Parameters.AddWithValue("@ProductID", orderItem.ProductID);
                    command.Parameters.AddWithValue("@OrderItems_Quantity", orderItem.OrderItems_Quantity);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteOrderItem(int orderID, int productID)
        {
            using (connection = new DBConnect().getConnection())
            {
                string sql = "DELETE FROM OrderItems WHERE OrderID = @OrderID AND ProductID = @ProductID";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@OrderID", orderID);
                    command.Parameters.AddWithValue("@ProductID", productID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<OrderItems> GetOrderItemsByOrderID(int orderID)
        {
            List<OrderItems> orderItems = new List<OrderItems>();

            using (connection = new DBConnect().getConnection())
            {
                string sql = "SELECT * FROM OrderItems inner join Products" +
                    " on OrderItems.ProductID = Products.ProductID " +
                    "WHERE OrderID = @OrderID";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@OrderID", orderID);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            OrderItems Items = new OrderItems
                            {
                                OrderID = (int)reader["OrderID"],
                                ProductID = (int)reader["ProductID"],
                                ProductName = (string)reader["ProductName"],
                                ProductDescription = (string)reader["ProductDescription"],
                                Price = (double)reader["ProductPrice"],
                                OrderItems_Quantity = (int)reader["OrderItems_Quantity"],
                            };
                            orderItems.Add(Items);
                        };
                    }
                    return orderItems;
                }

            }


        }

        public List<OrderItems> getInvoice(int orderID)
        {
            List<OrderItems> orderItems = new List<OrderItems>();

            using (connection = new DBConnect().getConnection())
            {
                string sql = "select OrderID, Products.ProductID, ProductName, ProductDescription, ProductPrice, OrderItems_Quantity from dbo.OrderItems inner join Products " +
                    "on OrderItems.ProductID = Products.ProductID where OrderID = @OrderID";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@OrderID", orderID);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            OrderItems Items = new OrderItems
                            {
                                OrderID = (int)reader["OrderID"],
                                ProductID = (int)reader["ProductID"],
                                ProductName = (string)reader["ProductName"],
                                ProductDescription = (string)reader["ProductDescription"],
                                Price = (double)reader["ProductPrice"],
                                OrderItems_Quantity = (int)reader["OrderItems_Quantity"],

                            };
                            orderItems.Add(Items);
                        }
                    }
                }
                
            }

            return orderItems;
        }
    }
}
