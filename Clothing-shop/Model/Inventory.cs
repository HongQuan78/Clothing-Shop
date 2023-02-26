using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothing_shop.Model
{
    public class Inventory
    {
        public int InventoryID { get; set; }
        public int ProductID { get; set; }
        public int Inventory_Quantity { get; set; }
        public Inventory(int inventoryID, int productID, int inventory_Quantity)
        {
            InventoryID = inventoryID;
            ProductID = productID;
            Inventory_Quantity = inventory_Quantity;
        }
    }
}
