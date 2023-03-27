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
using static System.Collections.Specialized.BitVector32;

namespace Clothing_shop
{
    public partial class frmLogin : Form
    {
        public static Employees employeeLogin = new Employees();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            EmployeesDAO employeesDAO = new EmployeesDAO();
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            Employees employees = employeesDAO.checkLogin(username, password);
            if (employees == null)
            {
                MessageBox.Show("Sai mật khẩu hoặc tài khoản!");
            }
            else
            {
                employeeLogin = employees;
                Thread thread = new Thread(new ThreadStart(showFormQuanLyDonHang));
                thread.Start();
                this.Close();
            }

        }

        private void showFormQuanLyDonHang()
        {
            frmQuanLyDonHang quanLyDonHang = new frmQuanLyDonHang();
            quanLyDonHang.ShowDialog();
        }


        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }
    }
}
