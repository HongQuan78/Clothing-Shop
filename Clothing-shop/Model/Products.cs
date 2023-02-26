using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothing_shop.Model
{
    public class Products
    {
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
        public double Product_Price { get; set; }
        public string Product_Description { get; set;}

        public string Product_CategoryID { get; set; }
    }
}
