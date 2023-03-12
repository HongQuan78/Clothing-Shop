using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothing_shop.Model
{
    public class Products
    {
        public int ProductID { get; set; }
        public String ProductName { get; set; }
        public String ProductDescription { get; set; }
        public double ProductPrice { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int InventoryQuantity {  get; set;  }

        public Products(int productID, String productName, String productDescription, double productPrice, int categoryID)
        {
            ProductID = productID;
            ProductName = productName;
            ProductDescription = productDescription;
            ProductPrice = productPrice;
            CategoryID = categoryID;
        }

        public Products(int productID, String productName, String productDescription, double productPrice, int categoryID, string categoryName, int quantity)
        {
            ProductID = productID;
            ProductName = productName;
            ProductDescription = productDescription;
            ProductPrice = productPrice;
            CategoryID = categoryID;
            CategoryName = categoryName;
            InventoryQuantity = quantity;
        }
        public Products()
        {

        }

    }
}
