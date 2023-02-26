using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothing_shop.Model
{
    public class Categories
    {
        public Categories() { }
        public String Category_ID { get; set; }
        public String Category_Name { get; set; }
        public int Product_quantity { get; set; }
        public Categories(string category_ID, string category_Name, int product_quantity)
        {
            Category_ID = category_ID;
            Category_Name = category_Name;
            Product_quantity = product_quantity;
        }
    }
}
