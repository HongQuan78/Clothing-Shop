using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothing_shop.Model
{
    public class OrderItems
    {
        private int OrderID { get; set; }
        private int ProductID { get; set; }
        private int OrderItems_Quantity { get; set; }
        public OrderItems(int orderID, int productID, int orderItems_Quantity)
        {
            OrderID = orderID;
            ProductID = productID;
            OrderItems_Quantity = orderItems_Quantity;
        }
    }
}
