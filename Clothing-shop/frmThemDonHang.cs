using Clothing_shop.DAO;
using Clothing_shop.DBConnection;
using Clothing_shop.Model;
using System;
using System.CodeDom;
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
    public partial class frmThemDonHang : Form
    {
        private static List<int> productID = new List<int>();
        private ProductsDAO productsDAO = new ProductsDAO();
        private OrderDAO order = new OrderDAO();
        private static string customerName = "";
        private static string customerPhone = "";
        private static string customerAddress = "";
        public static int orderID = -1;
        public frmThemDonHang()
        {
            InitializeComponent();
        }

        private void ProductViews_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {


        }

        private void quanLyNhanVien_Menu_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(showFormQuanLyNhanVien));
            thread.Start();
            this.Close();
        }

        private void showFormQuanLyNhanVien()
        {
            frmQuanLyNhanVien quanLyNhanVien = new frmQuanLyNhanVien();
            quanLyNhanVien.ShowDialog();
        }

        private void frmThemDonHang_Load(object sender, EventArgs e)
        {
            int cusID = ChonKhachHang.cusID;
            if (cusID >= 0)
            {
                Customers customers = new CustomerDAO().GetCustomerById(cusID);
                txtName.Text = customers.CustomerName;
                txtPhone.Text = customers.CustomerPhone;
                txtAddress.Text = customers.CustomerAddress;
            }
            else
            {
                txtName.Text = "";
                txtPhone.Text = "";
                txtAddress.Text = "";
            }
            //displayOrders();
        }

        public void displayOrders()
        {
            if (orderID >= 0)
            {
                var OrderDetailList = new OrderItemsDAO().GetOrderItemsByOrderID(orderID);
                OrderView.DataSource = OrderDetailList;
                OrderView.AutoGenerateColumns = true;
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {

            customerName = txtName.Text;
            customerPhone = txtPhone.Text;
            customerAddress = txtAddress.Text;
            if (customerName == "" || customerPhone == "" || customerAddress == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng");
            }
            else
            {
                int cusID = ChonKhachHang.cusID;
                int empID = frmLogin.employeeLogin.EmployeeID;
                txtTotalAmount.Text = "0";
                Orders orderAdd = new Orders(cusID, empID, double.Parse(txtTotalAmount.Text));
                orderID = order.AddOrder(orderAdd);
                MessageBox.Show("Thêm khách hàng thành công");
                displayOrders();
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chooseCustomer_Click(object sender, EventArgs e)
        {
            showForm show = new showForm();
            Thread thread = new Thread(show.showChonKhachHang);
            thread.Start();
            this.Close();

        }

        private void addOrderItems_Click(object sender, EventArgs e)
        {
            showForm show = new showForm();
            Thread thread = new Thread(new ThreadStart(show.showAddOrderDetail));
            thread.Start();
            this.Close();
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
            showForm show = new showForm();
            Thread thread = new Thread(show.showFormQuanLyNhanVien);
            thread.Start();
            this.Close();
        }

        private void xemHangTraLai_Click(object sender, EventArgs e)
        {
            showForm show = new showForm();
            Thread thread = new Thread(show.showFormHangBiTraLai);
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
    }
}
