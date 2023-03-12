using Clothing_shop.DAO;
using Clothing_shop.Model;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Clothing_shop
{
    public partial class frmQuanLySanPham : Form
    {
        private ProductDAO productsDAO = new ProductDAO();
        private int productID = -1;
        public frmQuanLySanPham()
        {
            InitializeComponent();
        }

        private void frmQuanLySanPham_Load(object sender, EventArgs e)
        {
            quanLyNhanVien_Menu.Visible = true;
            if (!string.Equals("Manager", frmLogin.employeeLogin.EmployeeRole, StringComparison.CurrentCultureIgnoreCase))
            {
                quanLyNhanVien_Menu.Visible = false;
            }
            txtAmount.Maximum = int.MaxValue;
            CategoryDAO categoryDAO = new CategoryDAO();
            var comboBox = categoryDAO.GetAllCategories();
            categoryBox.DataSource = comboBox;
            categoryBox.DisplayMember = "CategoryName";
            categoryBox.ValueMember = "CategoryID";
            displayProduct();


        }

        public void displayProduct()
        {
            var products = productsDAO.GetAllProductsCate();
            dataGridView1.DataSource = products;
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            if (numrow >= 0)
            {
                productID = int.Parse(dataGridView1.Rows[numrow].Cells[0].Value.ToString());
                txtName.Text = dataGridView1.Rows[numrow].Cells[1].Value.ToString();
                txtDescription.Text = dataGridView1.Rows[numrow].Cells[2].Value.ToString();
                txtPrice.Text = dataGridView1.Rows[numrow].Cells[3].Value.ToString();
                txtAmount.Text = dataGridView1.Rows[numrow].Cells[6].Value.ToString();
                categoryBox.Text = dataGridView1.Rows[numrow].Cells[5].Value.ToString();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //check all textbox is not empty
            if (txtName.Text == "" || txtDescription.Text == "" || txtPrice.Text == "" || txtAmount.Text == "" || categoryBox.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            else
            {
                string name = txtName.Text;
                string description = txtDescription.Text;
                double price = double.Parse(txtPrice.Text);
                int amount = int.Parse(txtAmount.Text);
                //get value from combobox
                int cateId = (int)categoryBox.SelectedValue;
                productsDAO.AddProduct(new Products
                {
                    ProductID = productID,
                    ProductName= name,
                    ProductDescription= description,
                    ProductPrice= price,
                    CategoryID= cateId,
                    InventoryQuantity = amount
                }) ;

                productID = -1;
                txtName.Text = "";
                txtDescription.Text = "";
                txtPrice.Text = "";
                txtAmount.Text = "";
                categoryBox.Text = "";
                MessageBox.Show("Thêm thành công");
                displayProduct();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (productID == -1)
            {
                MessageBox.Show("Chưa chọn sản phẩm để xóa");
                return;
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Xóa sản phẩm này?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    productsDAO.DeleteProduct(productID);
                    displayProduct();
                    productID = -1;
                    txtName.Text = "";
                    txtDescription.Text = "";
                    txtPrice.Text = "";
                    txtAmount.Text = "";
                    categoryBox.Text = "";
                    MessageBox.Show("Xóa thành công");

                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //check all textbox is not empty
            if (txtName.Text == "" || txtDescription.Text == "" || txtPrice.Text == "" || txtAmount.Text == "" || categoryBox.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            else
            {
                string name = txtName.Text;
                string description = txtDescription.Text;
                double price = double.Parse(txtPrice.Text);
                int amount = int.Parse(txtAmount.Text);
                //get value from combobox
                int cateId = (int)categoryBox.SelectedValue;
                productsDAO.UpdateProduct(new Products
                {
                    ProductID = productID,
                    ProductName = name,
                    ProductDescription = description,
                    ProductPrice = price,
                    CategoryID = cateId,
                    InventoryQuantity = amount
                });
                MessageBox.Show("Sửa thành công");
                displayProduct();
            }
        }
    }
}
