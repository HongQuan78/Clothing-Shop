using Clothing_shop.DAO;
using Clothing_shop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clothing_shop
{

    public partial class frmQuanLyNhanVien : Form
    {
        private int empID = 0;
        EmployeesDAO dao = new EmployeesDAO();
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
            quanLyNhanVien_Menu.Visible = true;
            if (!string.Equals("Manager", frmLogin.employeeLogin.EmployeeRole, StringComparison.CurrentCultureIgnoreCase))
            {
                quanLyNhanVien_Menu.Visible = false;
            }
            displayListEmployee();
        }

        public void displayListEmployee()
        {

            var employees = new EmployeesDAO().GetAllEmployees();
            DataTable dt = new DataTable();
            ViewEmployeeList.DataSource = employees;
           


        }

        private void ViewEmployeeList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            if (numrow >= 0)
            {
                empID = int.Parse(ViewEmployeeList.Rows[numrow].Cells[0].Value.ToString());
                txtEmpName.Text = ViewEmployeeList.Rows[numrow].Cells[1].Value.ToString();
                txtEmpUsername.Text = ViewEmployeeList.Rows[numrow].Cells[3].Value.ToString();
                txtEmpPassword.Text = ViewEmployeeList.Rows[numrow].Cells[4].Value.ToString();
                txtEmpPhone.Text = ViewEmployeeList.Rows[numrow].Cells[5].Value.ToString();
                txtEmpAddress.Text = ViewEmployeeList.Rows[numrow].Cells[6].Value.ToString();
                txtEmpBirthday.Text = ViewEmployeeList.Rows[numrow].Cells[7].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                dao.AddEmployee(getEmployee(dao.getID()));
                MessageBox.Show("Thêm thành công");
                displayListEmployee();
            }
            catch (Exception)
            {

                MessageBox.Show("Không thể thành công");
            }
                
           
        }

        public Employees getEmployee(int idParam)
        {
            int id = idParam;
            string name = txtEmpName.Text;
            string username = txtEmpUsername.Text;
            string password = txtEmpPassword.Text;
            string phone = txtEmpPhone.Text;
            string address = txtEmpAddress.Text;
            string birthday = txtEmpBirthday.Text;
            return new Employees(id, name, "Nhân viên", username, password, phone, address, DateTime.Parse(birthday));
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Display a confirmation box
                DialogResult result = MessageBox.Show("Xóa nhân viên này?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Check the result
                if (result == DialogResult.Yes)
                {
                    new EmployeesDAO().DeleteEmployee(empID);
                    MessageBox.Show("Xóa thành công");
                    displayListEmployee();
                }

                
            }
            catch (Exception)
            {

                MessageBox.Show("Không thể xóa nhân viên");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {   
                dao.UpdateEmployee(getEmployee(empID));
                MessageBox.Show("Chỉnh sửa thành công");
                displayListEmployee();
            }
            catch (Exception)
            {

                MessageBox.Show("Có lỗi xảy ra");
            }
            
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            displayListEmployee();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {   
            string name = txtSearch.Text;
            var employees = new EmployeesDAO().SearchEmployeesByName(name);
            DataTable dt = new DataTable();
            ViewEmployeeList.DataSource = employees;
            ViewEmployeeList.AutoGenerateColumns = true;
            txtSearch.Text = "Tìm kiếm theo tên";
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void quanLyDonHang_Click(object sender, EventArgs e)
        {
            showForm show = new showForm();
            Thread thread = new Thread(show.showFormQuanLyDonHang);
            thread.Start();
            this.Close();
        }

        private void quanLyNhanVien_Menu_Click_1(object sender, EventArgs e)
        {

        }

        private void xemHangTraLai_Click(object sender, EventArgs e)
        {
            showForm show = new showForm();
            Thread thread = new Thread(show.showFormHangBiTraLai);
            thread.Start();
            this.Close();
        }

        private void theemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm show = new showForm();
            Thread thread = new Thread(show.showFormThemDonHang);
            thread.Start();
            this.Close();
        }

        private void xemKhachHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm show = new showForm();
            Thread thread = new Thread(show.showChonKhachHang);
            thread.Start();
            this.Close();
        }

        private void quanLySanPhamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm show = new showForm();
            Thread thread = new Thread(show.showQuanLySanPham);
            thread.Start();
            this.Close();
        }
    }
}
