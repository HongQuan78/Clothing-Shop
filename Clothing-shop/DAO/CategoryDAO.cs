using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Clothing_shop.DBConnection;
using Clothing_shop.Model;

namespace Clothing_shop.DAO
{
    public class CategoryDAO
    {
        private SqlConnection connection;

        public CategoryDAO()
        {
        }

        // Create a new category in the database
        public void CreateCategory(Categories category)
        {
            using ( connection = new DBConnect().getConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Categories (CategoryName, CategoryDescription) VALUES (@CategoryName, @CategoryDescription)", connection);
               
                command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                command.Parameters.AddWithValue("@CategoryDescription", category.CategoryDescription);
                command.ExecuteNonQuery();
            }
        }

        // Read all categories from the database
        public List<Categories> GetAllCategories()
        {
            List<Categories> categories = new List<Categories>();
            using (connection = new DBConnect().getConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT CategoryID, CategoryName, CategoryDescription FROM Categories", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Categories category = new Categories(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                    categories.Add(category);
                }
            }
            return categories;
        }

        // Read a category from the database by category ID
        public Categories GetCategoryById(int categoryId)
        {
            using (connection = new DBConnect().getConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT CategoryID, CategoryName, CategoryDescription FROM Categories WHERE CategoryID = @CategoryID", connection);
                command.Parameters.AddWithValue("@CategoryID", categoryId);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Categories category = new Categories(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                    return category;
                }
            }
            return null;
        }

        // Update a category in the database
        public void UpdateCategory(Categories category)
        {
            using (connection = new DBConnect().getConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Categories SET CategoryName = @CategoryName, CategoryDescription = @CategoryDescription WHERE CategoryID = @CategoryID", connection);
                command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                command.Parameters.AddWithValue("@CategoryDescription", category.CategoryDescription);
                command.Parameters.AddWithValue("@CategoryID", category.CategoryID);
                command.ExecuteNonQuery();
            }
        }

        // Delete a category from the database by category ID
        public void DeleteCategory(int categoryId)
        {
            using (connection = new DBConnect().getConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Categories WHERE CategoryID = @CategoryID", connection);
                command.Parameters.AddWithValue("@CategoryID", categoryId);
                command.ExecuteNonQuery();
            }
        }
    }
}
