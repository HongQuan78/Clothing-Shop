using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothing_shop.DBConnection
{
    public class Orders
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }
        public string Status { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Orders()
        {

        }
        public Orders(int customerID, int employeeID, double totalAmount)
        {
            CustomerID = customerID;
            EmployeeID = employeeID;
            TotalAmount = totalAmount;
        }

        public Orders(int orderID, int customerID, int employeeID, DateTime orderDate, double totalAmount, string status, DateTime modifiedDate)
        {
            OrderID = orderID;
            CustomerID = customerID;
            EmployeeID = employeeID;
            OrderDate = orderDate;
            TotalAmount = totalAmount;
            Status = status;
            ModifiedDate = modifiedDate;
        }
    }
}
