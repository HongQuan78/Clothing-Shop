using Clothing_shop.DBConnection;
using Clothing_shop.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Clothing_shop.DAO
{
    public class ProductsDAO
    {
        private SqlConnection connection;

        public ProductsDAO()
        {
           
        }

        public List<Model.Products> GetAllProducts()
        {
            List<Model.Products> products = new List<Model.Products>();

            using (SqlConnection connection = new DBConnect().getConnection())
            {
                string query = "SELECT ProductID, ProductName, ProductDescription, ProductPrice, CategoryID FROM Products";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int productId = reader.GetInt32(0);
                    string productName = reader.GetString(1);
                    string productDescription = reader.GetString(2);
                    double productPrice = reader.GetDouble(3);
                    int categoryId = reader.GetInt32(4);

                    Model.Products product = new Model.Products(productId, productName, productDescription, productPrice, categoryId);
                    products.Add(product);
                }

                reader.Close();
            }

            return products;
        }

        public Model.Products GetProductById(int productId)
        {
            Model.Products product = null;

            using (SqlConnection connection = new DBConnect().getConnection())
            {
                string query = "SELECT ProductName, ProductDescription, ProductPrice, CategoryID FROM Products WHERE ProductID = @ProductId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductId", productId);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string productName = reader.GetString(0);
                    string productDescription = reader.GetString(1);
                    double productPrice = reader.GetDouble(2);
                    int categoryId = reader.GetInt32(3);

                    product = new Model.Products(productId, productName, productDescription, productPrice, categoryId);
                }

                reader.Close();
            }

            return product;
        }

        public List<Model.Products> GetProductsByName(string name)
        {
            List<Model.Products> products = new List<Model.Products>();

            using (SqlConnection connection = new DBConnect().getConnection())
            {
                string query = "SELECT ProductID, ProductName, ProductDescription, ProductPrice, CategoryID FROM Products WHERE ProductName LIKE '%' + @Name + '%'";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int productId = reader.GetInt32(0);
                    string productName = reader.GetString(1);
                    string productDescription = reader.GetString(2);
                    double productPrice = reader.GetDouble(3);
                    int categoryId = reader.GetInt32(4);

                    Model.Products product = new Model.Products(productId, productName, productDescription, productPrice, categoryId);
                    products.Add(product);
                }

                reader.Close();
            }

            return products;
        }

        public void AddProduct(Model.Products product)
        {
            using (SqlConnection connection = new DBConnect().getConnection())
            {
                string query = "INSERT INTO Products (ProductName, ProductDescription, ProductPrice, CategoryID) VALUES (@ProductName, @ProductDescription, @ProductPrice, @CategoryID)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@ProductDescription", product.ProductDescription);
                command.Parameters.AddWithValue("@ProductPrice", product.ProductPrice);
                command.Parameters.AddWithValue("@CategoryID", product.CategoryID);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void UpdateProduct(Products product)
        {
            using (SqlConnection connection = new DBConnect().getConnection())
            {
                SqlCommand command = new SqlCommand("UPDATE Products SET ProductName = @ProductName, ProductDescription = @ProductDescription, ProductPrice = @ProductPrice, CategoryID = @CategoryID WHERE ProductID = @ProductID", connection);
                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@ProductDescription", product.ProductDescription);
                command.Parameters.AddWithValue("@ProductPrice", product.ProductPrice);
                command.Parameters.AddWithValue("@CategoryID", product.CategoryID);
                command.Parameters.AddWithValue("@ProductID", product.ProductID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
