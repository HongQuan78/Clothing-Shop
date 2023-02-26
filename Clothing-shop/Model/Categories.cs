using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothing_shop.Model
{
    public class Categories
    {
        public String CategoryID { get; set; }
        public String CategoryName { get; set; }
        public String CategoryDescription { get; set; }
        public Categories(string categoryID, string categoryName, string categoryDescription)
        {
            CategoryID = categoryID;
            CategoryName = categoryName;
            CategoryDescription = categoryDescription;
        }
    }
}
