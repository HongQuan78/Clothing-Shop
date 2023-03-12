using Clothing_shop.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Clothing_shop.DAL
{
    public class InventoryDao
    {
        private readonly string connectionString;

        public InventoryDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Create(Inventory inventory)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "INSERT INTO Inventory (ProductID, Inventory_Quantity) VALUES (@ProductID, @Inventory_Quantity); SELECT SCOPE_IDENTITY()",
                    connection
                );
                command.Parameters.AddWithValue("@ProductID", inventory.ProductID);
                command.Parameters.AddWithValue("@Inventory_Quantity", inventory.Inventory_Quantity);
                inventory.InventoryID = Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public Inventory Read(int inventoryID)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "SELECT * FROM Inventory WHERE InventoryID = @InventoryID",
                    connection
                );
                command.Parameters.AddWithValue("@InventoryID", inventoryID);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Inventory(
                        (int)reader["InventoryID"],
                        (int)reader["ProductID"],
                        (int)reader["Inventory_Quantity"]
                    );
                }
                else
                {
                    return null;
                }
            }
        }

        public void Update(Inventory inventory)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "UPDATE Inventory SET ProductID = @ProductID, Inventory_Quantity = @Inventory_Quantity WHERE InventoryID = @InventoryID",
                    connection
                );
                command.Parameters.AddWithValue("@ProductID", inventory.ProductID);
                command.Parameters.AddWithValue("@Inventory_Quantity", inventory.Inventory_Quantity);
                command.Parameters.AddWithValue("@InventoryID", inventory.InventoryID);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int inventoryID)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "DELETE FROM Inventory WHERE InventoryID = @InventoryID",
                    connection
                );
                command.Parameters.AddWithValue("@InventoryID", inventoryID);
                command.ExecuteNonQuery();
            }
        }

        public List<Inventory> GetAll()
        {
            var inventories = new List<Inventory>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "SELECT * FROM Inventory",
                    connection
                );
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    inventories.Add(new Inventory(
                        (int)reader["InventoryID"],
                        (int)reader["ProductID"],
                        (int)reader["Inventory_Quantity"]
                    ));
                }
            }
            return inventories;
        }
    }
}
