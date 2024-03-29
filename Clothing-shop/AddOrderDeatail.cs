﻿using Clothing_shop.DAO;
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
    public partial class AddOrderDeatail : Form
    {
        private OrderItemsDAO orderItemsDAO = new OrderItemsDAO();
        private ProductDAO productsDAO = new ProductDAO();
        private CustomerDAO customerDAO = new CustomerDAO();
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
            fillComboBox();
        }

        public void fillComboBox()
        {
            CategoryDAO categoryDAO = new CategoryDAO();
            var comboBox = categoryDAO.GetAllCategories();
            comboCategory.DataSource = comboBox;
            comboCategory.DisplayMember = "CategoryName";
            comboCategory.ValueMember = "CategoryID";
        }

        public void displayProduct()
        {
            var products = productsDAO.GetAllProducts();
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã sản phẩm");
            dt.Columns.Add("Tên sản phẩm");
            dt.Columns.Add("Mô tả");
            dt.Columns.Add("Giá");
            dt.Columns.Add("Loại sản phẩm");
            dt.Columns.Add("Số lượng trong kho");
            foreach (var item in products)
            {
                Categories cate = new CategoryDAO().GetCategoryById(item.CategoryID);
                dt.Rows.Add(
                    item.ProductID, 
                    item.ProductName, 
                    item.ProductDescription, 
                    item.ProductPrice, 
                    cate.CategoryName, 
                    item.InventoryQuantity);
            }
            productsView.DataSource = dt;
            //change width of column
            productsView.Columns[0].Width = 100; 
            productsView.Columns[1].Width = 150;
            productsView.Columns[2].Width = 200;
            productsView.Columns[3].Width = 200;
            productsView.Columns[4].Width = 150;
            productsView.Columns[5].Width = 150;
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
            //showForm show = new showForm();
            //Thread thread = new Thread(show.showFormThemDonHang);
            //thread.Start();
            this.Close();
        }

        private void AddOrderDeatail_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmThemDonHang frm = Application.OpenForms.OfType<frmThemDonHang>().FirstOrDefault();
            if (frm != null)
            {
                frm.displayOrders();
            }
        }

        private void comboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboCategory.SelectedValue != null && int.TryParse(comboCategory.SelectedValue.ToString(), out int selectedValue))
            {
                var list = productsDAO.GetProductByCate(selectedValue);
                // Use the list of products as needed
                productsView.DataSource = list;
                productsView.AutoGenerateColumns = true;
            }
        }
    }
}
