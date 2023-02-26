using Clothing_shop.DBConnection;
using Clothing_shop.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Clothing_shop.DAO
{
    public class EmployeesDAO
    {
        private SqlConnection connection;
        public List<Employees> GetAllEmployees()
        {
            List<Employees> employees = new List<Employees>();
            connection = new DBConnect().getConnection();
            string sql = "SELECT * FROM Employees";
            using (connection = new DBConnect().getConnection())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employees employee = new Employees();
                            employee.EmployeeID = reader.GetInt32(0);
                            employee.EmployeeName = reader.GetString(1);
                            employee.EmployeeRole = reader.GetString(2);
                            employee.EmployeeUsername = reader.GetString(3);
                            employee.EmployeePassword = reader.GetString(4);
                            employee.EmployeePhone = reader.GetString(5);
                            employee.EmployeeAddress = reader.GetString(6);
                            employee.EmployeeBirthDay = reader.GetDateTime(7);
                            employees.Add(employee);
                        }
                    }
                }
            }
            return employees;
        }

        public void AddEmployee(Employees employee)
        {
            using (connection = new DBConnect().getConnection())
            {
                string sql = "INSERT INTO Employees (EmployeeName, EmployeeRole, EmployeeUsername, EmployeePassword, EmployeePhone, EmployeeAddress, EmployeeBirthDay) " +
                             "VALUES (@EmployeeName, @EmployeeRole, @EmployeeUsername, @EmployeePassword, @EmployeePhone, @EmployeeAddress, @EmployeeBirthDay)";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                    command.Parameters.AddWithValue("@EmployeeRole", employee.EmployeeRole);
                    command.Parameters.AddWithValue("@EmployeeUsername", employee.EmployeeUsername);
                    command.Parameters.AddWithValue("@EmployeePassword", employee.EmployeePassword);
                    command.Parameters.AddWithValue("@EmployeePhone", employee.EmployeePhone);
                    command.Parameters.AddWithValue("@EmployeeAddress", employee.EmployeeAddress);
                    command.Parameters.AddWithValue("@EmployeeAddress", employee.EmployeeBirthDay);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateEmployee(Employees employee)
        {
            using (connection = new DBConnect().getConnection())
            {
                string sql = "UPDATE Employees SET EmployeeName=@EmployeeName, EmployeeRole=@EmployeeRole, EmployeeUsername=@EmployeeUsername, " +
                    "EmployeePassword=@EmployeePassword, EmployeePhone=@EmployeePhone, EmployeeAddress=@EmployeeAddress, EmployeeBirthDay=@EmployeeBirthDay " +
                    "WHERE EmployeeID=@EmployeeID";

                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
                    command.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                    command.Parameters.AddWithValue("@EmployeeRole", employee.EmployeeRole);
                    command.Parameters.AddWithValue("@EmployeeUsername", employee.EmployeeUsername);
                    command.Parameters.AddWithValue("@EmployeePassword", employee.EmployeePassword);
                    command.Parameters.AddWithValue("@EmployeePhone", employee.EmployeePhone);
                    command.Parameters.AddWithValue("@EmployeeBirthDay", employee.EmployeeBirthDay);
                    command.Parameters.AddWithValue("@EmployeeAddress", employee.EmployeeAddress);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteEmployee(int employeeID)
        {
            using (connection = new DBConnect().getConnection())
            {
                string sql = "DELETE FROM Employees WHERE EmployeeID=@EmployeeID";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", employeeID);
                    command.ExecuteNonQuery();
                }
            }
        }
        public Employees checkLogin(String username, String password)
        {
            Employees employee = null;
            using (connection = new DBConnect().getConnection())
            {
                string sql = "select * " +
                "from dbo.Employees " +
                "where Employees.EmployeeUsername like @EmployeeUsername and Employees.EmployeePassword " +
                "like @EmployeePassword";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeUsername", username);
                    command.Parameters.AddWithValue("@EmployeePassword", password);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            employee = new Employees();
                            employee.EmployeeID = reader.GetInt32(0);
                            employee.EmployeeName = reader.GetString(1);
                            employee.EmployeeRole = reader.GetString(2);
                            employee.EmployeeUsername = reader.GetString(3);
                            employee.EmployeePassword = reader.GetString(4);
                            employee.EmployeePhone = reader.GetString(5);
                            employee.EmployeeAddress = reader.GetString(6);
                        }
                    }
                }
            }
            return employee;
        }
        public Employees GetEmployeesByID(int employeeID)
        {
            Employees employee = null;
            using (connection = new DBConnect().getConnection())
            {
                string sql = "select * from dbo.Employees " +
                    "where EmployeeID = @EmployeeID";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", employeeID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            employee = new Employees();
                            employee.EmployeeID = reader.GetInt32(0);
                            employee.EmployeeName = reader.GetString(1);
                            employee.EmployeeRole = reader.GetString(2);
                            employee.EmployeeUsername = reader.GetString(3);
                            employee.EmployeePassword = reader.GetString(4);
                            employee.EmployeePhone = reader.GetString(5);
                            employee.EmployeeAddress = reader.GetString(6);
                            employee.EmployeeBirthDay = reader.GetDateTime(7);
                        }
                    }
                }
            }
            return employee;
        }
    }
}
