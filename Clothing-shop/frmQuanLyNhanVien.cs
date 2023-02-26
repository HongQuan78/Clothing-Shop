using Clothing_shop.DAO;
using Clothing_shop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clothing_shop
{
    public partial class frmQuanLyNhanVien : Form
    {
        public List<Employees> listEmployee = new List<Employees>();
        public frmQuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void quanLyNhanVien_Menu_Click(object sender, EventArgs e)
        {

        }

        private void frmQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            displayListEmployee();
        }

        public void displayListEmployee()
        {
            // Tạo các cột cho DataGridView
            ViewEmployeeList.Columns.Add("EmployeeID", "ID");
            ViewEmployeeList.Columns.Add("EmployeeName", "Name");
            ViewEmployeeList.Columns.Add("EmployeeUsername", "Username");
            ViewEmployeeList.Columns.Add("EmployeePhone", "Phone");
            ViewEmployeeList.Columns.Add("EmployeeAddress", "Address");
            ViewEmployeeList.Columns.Add("EmployeeBirthDay", "Birthday");
            // Lấy danh sách nhân viên từ CSDL và hiển thị trong DataGridView
            List<Employees> employees = new EmployeesDAO().GetAllEmployees();
            ViewEmployeeList.Rows.Clear();
            foreach (Employees employee in employees)
            {
                ViewEmployeeList.Rows.Add(employee.EmployeeID, employee.EmployeeName, employee.EmployeeUsername, employee.EmployeePhone, employee.EmployeeAddress, employee.EmployeeBirthDay);
            }


        }

    }
}
