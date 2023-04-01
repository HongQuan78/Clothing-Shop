using Clothing_shop.DAO;
using Clothing_shop.DBConnection;
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

        public void DGVConfig(List<Returns> returns)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã");
            dt.Columns.Add("Mã đơn hàng");
            dt.Columns.Add("Tên khách hàng");
            dt.Columns.Add("Số điện thoại");
            dt.Columns.Add("Lý do");
            foreach (var item in returns)
            {
                Orders o = new OrderDAO().GetOrderById(item.OrderID);
                Customers cus = new CustomerDAO().GetCustomerById(o.CustomerID);
                dt.Rows.Add(
                    item.ReturnID,
                    item.OrderID,
                    cus.CustomerName,
                    cus.CustomerPhone,
                    item.Reason);
            }
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 250;
            dataGridView1.AutoGenerateColumns = true;
        }

        public void displayReturn()
        {
            var returns = returnsDAO.GetAll();
            DGVConfig(returns);
            
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchKey = txtSearch.Text;
            var returns = returnsDAO.ReturnSearch(searchKey);
            DGVConfig(returns);
        }
    }
}
