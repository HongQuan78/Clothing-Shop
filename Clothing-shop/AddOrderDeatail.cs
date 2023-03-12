using Clothing_shop.DAO;
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
    public partial class AddOrderDeatail : Form
    {
        private OrderItemsDAO orderItemsDAO = new OrderItemsDAO();
        private ProductDAO productsDAO = new ProductDAO();
        public static int OrderID = -1;
        private int ProductID = -1;
        public AddOrderDeatail()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cusID = ChonKhachHang.cusID;
            if (OrderID >= 0 && cusID >= 0)
            {
                if (ProductID >= 0)
                {
                    int quantity = int.Parse(amount.Text);
                    OrderItems orderItems = new OrderItems(OrderID, ProductID, quantity);
                    orderItemsDAO.AddOrderItem(orderItems);
                    MessageBox.Show("Thêm thành công");
                    displayProduct();
                }
                else
                {
                    MessageBox.Show("Chưa chọn sản phẩm");
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn khách hàng");
            }
        }

        private void AddOrderDeatail_Load(object sender, EventArgs e)
        {
            OrderID = frmThemDonHang.orderID;
            displayProduct();
            quanLyNhanVien_Menu.Visible = true;
            if (!string.Equals("Manager", frmLogin.employeeLogin.EmployeeRole, StringComparison.CurrentCultureIgnoreCase))
            {
                quanLyNhanVien_Menu.Visible = false;
            }
        }
        public void displayProduct()
        {
            var products = productsDAO.GetAllProducts();
            productsView.DataSource = products;
            productsView.AutoGenerateColumns = true;
        }

        private void productsView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            if (numrow >= 0)
            {
                ProductID = int.Parse(productsView.Rows[numrow].Cells[0].Value.ToString());
                txtName.Text = productsView.Rows[numrow].Cells[1].Value.ToString();
                txtPrice.Text = productsView.Rows[numrow].Cells[3].Value.ToString();

            }
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

        private void btnback_Click(object sender, EventArgs e)
        {
            showForm show = new showForm();
            Thread thread = new Thread(show.showFormThemDonHang);
            thread.Start();
            this.Close();
        }
    }
}
