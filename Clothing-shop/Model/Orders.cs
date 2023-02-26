using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothing_shop.Model
{
    public class Orders
    {
        public int Order_ID { get; set; }
        public int Customer_ID { get; set;}
        public int Employee_ID { get; set;}
        public DateTime Order_date { get; set; }
        public Orders(int order_ID, int customer_ID, int employee_ID, DateTime order_date)
        {
            Order_ID = order_ID;
            Customer_ID = customer_ID;
            Employee_ID = employee_ID;
            Order_date = order_date;
        }
    }
}
