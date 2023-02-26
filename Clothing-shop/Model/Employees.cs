using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothing_shop.Model
{
    public class Employees
    {

        public int EmployeeID { get; set; }
        public String EmployeeName { get; set; }
        public String EmployeeRole { get; set; }
        public String EmployeeUsername { get; set; }
        public String EmployeePassword { get; set; }
        public String EmployeePhone { get; set; }
        public String EmployeeAddress { get; set; }
        public Employees() { }
        public Employees(int employeeID, string employeeName, string employeeRole, string employeeUsername, string employeePassword, string employeePhone, string employeeAddress)
        {
            EmployeeID = employeeID;
            EmployeeName = employeeName;
            EmployeeRole = employeeRole;
            EmployeeUsername = employeeUsername;
            EmployeePassword = employeePassword;
            EmployeePhone = employeePhone;
            EmployeeAddress = employeeAddress;
        }
    }
}
