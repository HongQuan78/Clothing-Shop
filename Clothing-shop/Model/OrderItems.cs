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
        public OrderItems(int orderID, int productID, int orderItems_Quantity)
        {
            OrderID = orderID;
            ProductID = productID;
            OrderItems_Quantity = orderItems_Quantity;
        }
    }
}
