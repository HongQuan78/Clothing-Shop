using Clothing_shop.DAO;
using Clothing_shop.DBConnection;
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
    public partial class frmHangBiTraLai : Form
    {   
        private ReturnsDAO returnsDAO = new ReturnsDAO();
        public frmHangBiTraLai()
        {
            InitializeComponent();
        }

        private void frmHangBiTraLai_Load(object sender, EventArgs e)
        {
            quanLyNhanVien_Menu.Visible = true;
            if (!string.Equals("Manager", frmLogin.employeeLogin.EmployeeRole, StringComparison.CurrentCultureIgnoreCase))
            {
                quanLyNhanVien_Menu.Visible = false;
            }
            displayReturn();
        }
        public void displayReturn()
        {
            var returns = returnsDAO.GetAll();
            dataGridView1.DataSource = returns;
            dataGridView1.AutoGenerateColumns = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void quanLyNhanVien_Menu_Click(object sender, EventArgs e)
        {
            showForm show = new showForm();
            Thread thread = new Thread(show.showFormQuanLyNhanVien);
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            int orderid = 0;
            int returnid = 0;
            if (numrow >= 0)
            {
                returnid = int.Parse(dataGridView1.Rows[numrow].Cells[0].Value.ToString());
                orderid = int.Parse(dataGridView1.Rows[numrow].Cells[1].Value.ToString());
            }
            new OrderDetail(orderid, returnid).ShowDialog();
        }
    }
}
