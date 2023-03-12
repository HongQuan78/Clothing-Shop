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
        private ProductsDAO productsDAO = new ProductsDAO();
        private int ProductID = -1;
        public AddOrderDeatail()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int orderID = frmThemDonHang.orderID;
            int cusID = ChonKhachHang.cusID;
            if (orderID >= 0 && cusID >= 0)
            {
                if (ProductID >= 0)
                {
                    int quantity = int.Parse(amount.Text);
                    int price = int.Parse(txtPrice.Text);
                    int total = quantity * price;
                    OrderItems orderItems = new OrderItems(orderID, ProductID, total);
                    orderItemsDAO.AddOrderItem(orderItems);
                    MessageBox.Show("Thêm thành công");
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
            displayProduct();
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
    }
}
