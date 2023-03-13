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
        private OrderDAO order = new OrderDAO();
        private static string customerName = "";
        private static string customerPhone = "";
        private static string customerAddress = "";
        public static int orderID = -1;
        private int productID = -1;
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
            quanLyNhanVien_Menu.Visible = true;
            if (!string.Equals("Manager", frmLogin.employeeLogin.EmployeeRole, StringComparison.CurrentCultureIgnoreCase))
            {
                quanLyNhanVien_Menu.Visible = false;
            }
            orderID = AddOrderDeatail.OrderID;
            int cusID = ChonKhachHang.cusID;
            displayOrders();
            txtTotalAmount.Text = orderID > -1 ? order.GetOrderById(orderID).TotalAmount.ToString() : "0";
            txtName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            if (cusID >= 0)
            {
                Customers customers = new CustomerDAO().GetCustomerById(cusID);
                txtName.Text = customers.CustomerName;
                txtPhone.Text = customers.CustomerPhone;
                txtAddress.Text = customers.CustomerAddress;
                txtTotalAmount.Text = orderID > -1 ? order.GetOrderById(orderID).TotalAmount.ToString() : "0";
            }

             
        }

        public void displayOrders()
        {
            txtTotalAmount.Text = orderID > -1 ? order.GetOrderById(orderID).TotalAmount.ToString() : "0";
            OrderView.DataSource = null; // clear the data source of the DataGridView
            if (orderID > -1)
            {
                var OrderDetailList = new OrderItemsDAO().GetOrderItemsByOrderID(orderID);
                OrderView.DataSource = OrderDetailList;
                OrderView.AutoGenerateColumns = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            orderID = -1;
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
                txtTotalAmount.Text = orderID > -1 ? order.GetOrderById(orderID).TotalAmount.ToString() : "0";
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
            orderID = -1;
            displayOrders();
            showForm show = new showForm();
            Thread thread = new Thread(show.showChonKhachHang);
            thread.Start();
            this.Close();

        }

        private void addOrderItems_Click(object sender, EventArgs e)
        {
            showForm show = new showForm();
            //Thread thread = new Thread(new ThreadStart(show.showAddOrderDetail));
            //thread.Start();
            //this.Close();
            show.showAddOrderDetail();

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

        private void quanLySanPhamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm show = new showForm();
            Thread thread = new Thread(show.showQuanLySanPham);
            thread.Start();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            orderID = -1;
            txtAddress.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtTotalAmount.Text = "";
            displayOrders();

        }

        private void btnDeleteOrderItems_Click(object sender, EventArgs e)
        {
                OrderItemsDAO orderItemsDAO = new OrderItemsDAO();
            try
            {
                DialogResult dialogResult = MessageBox.Show("Xóa sản phẩm này?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {   

                    orderItemsDAO.DeleteOrderItem(orderID, productID);
                    MessageBox.Show("Xóa thành công");
                    displayOrders();
                }
            }
            catch (Exception)
            {
                throw;
                MessageBox.Show("Không thể xóa");
            }
        }

        private void OrderView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            if (numrow >= 0)
            {
                productID = int.Parse(OrderView.Rows[numrow].Cells[1].Value.ToString());

            }

        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            showForm show = new showForm();
            Thread thread = new Thread(show.showFormQuanLyDonHang);

            thread.Start();
            this.Close();
        }
    }
}
