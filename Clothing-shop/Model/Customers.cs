using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothing_shop.Model
{
    public class Customers
    {
        public Customers() { }
        public String Customer_ID { get; set; }
        public String Customer_Name { get; set; }
        
        public String Customer_Phone { get; set;}
        public String Customer_Address { get; set;}
        public Customers(string customer_ID, string customer_Name, string customer_Phone, string customer_Address)
        {
            Customer_ID = customer_ID;
            Customer_Name = customer_Name;
            Customer_Phone = customer_Phone;
            Customer_Address = customer_Address;
        }
    }
}
