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
        public string EmployeeName { get; set; }
        public string EmployeeRole { get; set; }
        public string EmployeeUsername { get; set; }
        public string EmployeePassword { get; set; }
        public string EmployeePhone { get; set; }
        public string EmployeeAddress { get; set; }
        public DateTime EmployeeBirthDay { get; set; }
        public Employees() { }
        public Employees(int employeeID, string employeeName, string employeeRole, string employeeUsername, string employeePassword, string employeePhone, string employeeAddress, DateTime employeeBirthDay)
        {
            EmployeeID = employeeID;
            EmployeeName = employeeName;
            EmployeeRole = employeeRole;
            EmployeeUsername = employeeUsername;
            EmployeePassword = employeePassword;
            EmployeePhone = employeePhone;
            EmployeeAddress = employeeAddress;
            EmployeeBirthDay = employeeBirthDay;
        }
    }
}
