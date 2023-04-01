using Clothing_shop.DBConnection;
using Clothing_shop.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
public class ProductDAO
{
    private SqlConnection connection;

    public ProductDAO()
    {
    }

    public List<Products> GetAllProducts()
    {
        List<Products> products = new List<Products>();
        using (connection = new DBConnect().getConnection())
        {
            string query = "SELECT * FROM Products";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Products product = new Products
                {
                    ProductID = (int)reader["ProductID"],
                    ProductName = (string)reader["ProductName"],
                    ProductDescription = (string)reader["ProductDescription"],
                    ProductPrice = (double)reader["ProductPrice"],
                    CategoryID = (int)reader["CategoryID"],
                    InventoryQuantity = (int)reader["InventoryQuantity"]
                };
                products.Add(product);
            }
        }
        return products;
    }


    public List<Products> GetAllProductsCate()
    {
        List<Products> products = new List<Products>();
        using (connection = new DBConnect().getConnection())
        {
            string query = "select Products.ProductID, Products.ProductName, Products.ProductDescription," +
                " Products.ProductPrice, Categories.CategoryID, Categories.CategoryName, Products.InventoryQuantity " +
                "from Products inner join Categories " +
                "on Products.CategoryID = Categories.CategoryID";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Products product = new Products
                {
                    ProductID = (int)reader["ProductID"],
                    ProductName = (string)reader["ProductName"],
                    ProductDescription = (string)reader["ProductDescription"],
                    ProductPrice = (double)reader["ProductPrice"],
                    CategoryID = (int)reader["CategoryID"],
                    InventoryQuantity = (int)reader["InventoryQuantity"]
                };
                products.Add(product);
            }
        }
        return products;
    }




    public Products GetProductById(int productId)
    {
        using (connection = new DBConnect().getConnection())
        {
            string query = "SELECT * FROM Products WHERE ProductID = @ProductID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ProductID", productId);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Products product = new Products
                {
                    ProductID = (int)reader["ProductID"],
                    ProductName = (string)reader["ProductName"],
                    ProductDescription = reader["ProductDescription"] == DBNull.Value ? null : (string)reader["ProductDescription"],
                    ProductPrice = (double)reader["ProductPrice"],
                    CategoryID = (int)reader["CategoryID"],
                    InventoryQuantity = (int)reader["InventoryQuantity"]
                };
                return product;
            }
            return null;
        }
    }

    public int AddProduct(Products product)
    {
        using (connection = new DBConnect().getConnection())
        {
            string query = "INSERT INTO Products (ProductName, ProductDescription, ProductPrice, CategoryID, InventoryQuantity) " +
                           "VALUES (@ProductName, @ProductDescription, @ProductPrice, @CategoryID, @InventoryQuantity); " +
                           "SELECT SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ProductName", product.ProductName);
            command.Parameters.AddWithValue("@ProductDescription", product.ProductDescription ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ProductPrice", product.ProductPrice);
            command.Parameters.AddWithValue("@CategoryID", product.CategoryID);
            command.Parameters.AddWithValue("@InventoryQuantity", product.InventoryQuantity);
            connection.Open();
            return Convert.ToInt32(command.ExecuteScalar());
        }
    }

    public void UpdateProduct(Products product)
    {
        using (connection = new DBConnect().getConnection())
        {
            string query = "UPDATE Products SET ProductName = @ProductName, ProductDescription = @ProductDescription, " +
                           "ProductPrice = @ProductPrice, CategoryID = @CategoryID, InventoryQuantity = @InventoryQuantity " +
                           "WHERE ProductID = @ProductID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ProductID", product.ProductID);
            command.Parameters.AddWithValue("@ProductName", product.ProductName);
            command.Parameters.AddWithValue("@ProductDescription", product.ProductDescription ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ProductPrice", product.ProductPrice);
            command.Parameters.AddWithValue("@CategoryID", product.CategoryID);
            command.Parameters.AddWithValue("@InventoryQuantity", product.InventoryQuantity);
            connection.Open();
            command.ExecuteNonQuery();
        }

    }
    public void DeleteProduct(int productID)
    {
        using (connection = new DBConnect().getConnection())
        {
            string query = "Delete from Products where ProductID = @ProductID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ProductID", productID);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    //get product by category
    public List<Products> GetProductByCate(int cateID)
    {
        List<Products> products = new List<Products>();
        using (connection = new DBConnect().getConnection())
        {
            string query = "SELECT * FROM Products where CategoryID = @category";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@category", cateID);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Products product = new Products
                {
                    ProductID = (int)reader["ProductID"],
                    ProductName = (string)reader["ProductName"],
                    ProductDescription = (string)reader["ProductDescription"],
                    ProductPrice = (double)reader["ProductPrice"],
                    CategoryID = (int)reader["CategoryID"],
                    InventoryQuantity = (int)reader["InventoryQuantity"]
                };
                products.Add(product);
            }
        }
        return products;
    }
}
