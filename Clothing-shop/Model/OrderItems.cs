using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothing_shop.Model
{
    public class OrderItems
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int OrderItems_Quantity { get; set; }
        public string ProductName { get; set; }
        public OrderItems(int orderID, int productID, int orderItems_Quantity)
        {
            OrderID = orderID;
            ProductID = productID;
            OrderItems_Quantity = orderItems_Quantity;
        }

        public OrderItems(int orderID, int productID, int orderItems_Quantity, string productName)
        {
            OrderID = orderID;
            ProductID = productID;
            OrderItems_Quantity = orderItems_Quantity;
            ProductName = productName;
        }
    }
}
