using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothing_shop.Model
{
    public class Customers
    {
        public int CustomerID { get; set; }
        public String CustomerName { get; set; }

        public String CustomerPhone { get; set;}
        public String CustomerAddress { get; set;}
        public Customers()
        {

        }
        public Customers(int customerID, string customerName, string customerPhone, string customerAddress)
        {
            CustomerID = customerID;
            CustomerName = customerName;
            CustomerPhone = customerPhone;
            CustomerAddress = customerAddress;
        }
    }
}
