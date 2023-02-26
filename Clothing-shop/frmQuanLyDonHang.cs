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
    public partial class frmQuanLyDonHang : Form
    {
        public frmQuanLyDonHang()
        {
            InitializeComponent();
        }

        private void quanLyNhanVien_Menu_Click(object sender, EventArgs e)
        {
            showForm show = new showForm();
            Thread thread = new Thread(new ThreadStart(show.showFormQuanLyNhanVien));
            thread.Start();
            this.Close();
        }

        private void frmQuanLyDonHang_Load(object sender, EventArgs e)
        {
            quanLyNhanVien_Menu.Visible = true;
            if (!string.Equals("Manager", frmLogin.employeeLogin.EmployeeRole, StringComparison.CurrentCultureIgnoreCase)){
                quanLyNhanVien_Menu.Visible=false;
            }
        }

      
        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            showForm show = new showForm();
            Thread thread = new Thread(new ThreadStart(show.showFormThemDonHang));
            thread.Start();
            this.Close();
        }

        private void xemHangTraLaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm show = new showForm();
            Thread thread = new Thread(new ThreadStart(show.showFormHangBiTraLai));
            thread.Start();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
