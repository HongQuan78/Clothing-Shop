using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothing_shop.Model
{
    public class Inventory
    {
        private int InventoryID { get; set; }
        private int ProductID { get; set; }
        private int Inventory_Quantity { get; set; }
        public Inventory(int inventoryID, int productID, int inventory_Quantity)
        {
            InventoryID = inventoryID;
            ProductID = productID;
            Inventory_Quantity = inventory_Quantity;
        }
    }
}
