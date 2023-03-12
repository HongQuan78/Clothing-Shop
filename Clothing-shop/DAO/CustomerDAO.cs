using Clothing_shop.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Clothing_shop.DBConnection
{
    public class CustomerDAO
    {
        private SqlConnection connection;

        public CustomerDAO()
        {
        }

        public List<Customers> GetAllCustomers()
        {
            List<Customers> customers = new List<Customers>();

            using (connection = new DBConnect().getConnection())
            {
                connection.Open();

                string query = "SELECT * FROM Customers";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Customers customer = new Customers(
                            (int)reader["CustomerID"],
                            (string)reader["CustomerName"],
                            (string)reader["CustomerPhone"],
                            (string)reader["CustomerAddress"]
                        );

                        customers.Add(customer);
                    }
                }
            }

            return customers;
        }

        public void AddCustomer(Customers customer)
        {
            using (connection = new DBConnect().getConnection())
            {
                connection.Open();

                string query = "INSERT INTO Customers(CustomerName, CustomerPhone, CustomerAddress) VALUES (@Name, @Phone, @Address)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", customer.CustomerName);
                command.Parameters.AddWithValue("@Phone", customer.CustomerPhone);
                command.Parameters.AddWithValue("@Address", customer.CustomerAddress);

                command.ExecuteNonQuery();
            }
        }

        public void UpdateCustomer(Customers customer)
        {
            using (connection = new DBConnect().getConnection())
            {
                connection.Open();

                string query = "UPDATE Customers SET CustomerName = @Name, CustomerPhone = @Phone, CustomerAddress = @Address WHERE CustomerID = @ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", customer.CustomerName);
                command.Parameters.AddWithValue("@Phone", customer.CustomerPhone);
                command.Parameters.AddWithValue("@Address", customer.CustomerAddress);
                command.Parameters.AddWithValue("@ID", customer.CustomerID);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteCustomer(int customerID)
        {
            using (connection = new DBConnect().getConnection())
            {
                connection.Open();

                string query = "DELETE FROM Customers WHERE CustomerID = @ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", customerID);

                command.ExecuteNonQuery();
            }
        }
        public Customers GetCustomerById(int customerID)
        {
            using (connection = new DBConnect().getConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Customers WHERE CustomerID = @ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", customerID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Customers customer = new Customers(
                            (int)reader["CustomerID"],
                            (string)reader["CustomerName"],
                            (string)reader["CustomerPhone"],
                            (string)reader["CustomerAddress"]
                        );

                        return customer;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

    }
}
