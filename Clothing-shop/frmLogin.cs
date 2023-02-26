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
            Thread thread = new Thread(new ThreadStart(showFormQuanLyDonHang));
            thread.Start();
            this.Close();
        }

        private void showFormQuanLyDonHang()
        {
            frmQuanLyDonHang quanLyDonHang = new frmQuanLyDonHang();
            quanLyDonHang.ShowDialog();
        }
    }
}
