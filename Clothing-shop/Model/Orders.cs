using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothing_shop.DBConnection
{
    public class Orders
    {
        private int OrderID { get; set; }
        private int CustomerID { get; set; }
        private int EmployeeID { get; set; }
        private DateTime OrderDate { get; set; }
        private double TotalAmount { get; set; }
        private string Status { get; set; }
        private DateTime ModifiedDate { get; set; }
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
