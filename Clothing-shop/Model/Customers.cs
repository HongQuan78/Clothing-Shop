using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothing_shop.Model
{
    public class Customers
    {
        private Customers() { }
        private String CustomerID { get; set; }
        private String CustomerName { get; set; }

        private String CustomerPhone { get; set;}
        private String CustomerAddress { get; set;}
        public Customers(string customerID, string customerName, string customerPhone, string customerAddress)
        {
            CustomerID = customerID;
            CustomerName = customerName;
            CustomerPhone = customerPhone;
            CustomerAddress = customerAddress;
        }
    }
}
