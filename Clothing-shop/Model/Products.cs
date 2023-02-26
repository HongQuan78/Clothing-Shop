using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothing_shop.Model
{
    public class Products
    {
        private int ProductID { get; set; }
        private String ProductName { get; set; }
        private String ProductDescription { get; set; }
        private double ProductPrice { get; set; }
        private String CategoryID { get; set; }
        public Products(int productID, String productName, String productDescription, double productPrice, String categoryID)
        {
            ProductID = productID;
            ProductName = productName;
            ProductDescription = productDescription;
            ProductPrice = productPrice;
            CategoryID = categoryID;
        }


    }
}
