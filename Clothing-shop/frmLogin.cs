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
    public partial class frmLogin : Form
    {
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
                MessageBox.Show("Null òi má ơi");
            }
            else
            {
                MessageBox.Show("Oke gòi á má");
            }
            //Thread thread = new Thread(new ThreadStart(showFormQuanLyDonHang));
            //thread.Start();
            //this.Close();
        }

        private void showFormQuanLyDonHang()
        {
            frmQuanLyDonHang quanLyDonHang = new frmQuanLyDonHang();
            quanLyDonHang.ShowDialog();
        }


        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
