using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothing_shop.Model
{
    public class Employees
    {

        private String EmployeeID { get; set; }
        private String EmployeeName { get; set; }
        private String EmployeeRole { get; set; }
        private String EmployeeUsername { get; set; }
        private String EmployeePassword { get; set; }
        private String EmployeePhone { get; set; }
        private String EmployeeAddress { get; set; }
        private Employees() { }
        public Employees(string employeeID, string employeeName, string employeeRole, string employeeUsername, string employeePassword, string employeePhone, string employeeAddress)
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
