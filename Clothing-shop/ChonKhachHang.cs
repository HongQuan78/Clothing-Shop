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
    public partial class ChonKhachHang : Form
    {
        private CustomerDAO customerDAO = new CustomerDAO();
        public static int cusID = -1;
        public static string cusName;
        public ChonKhachHang()
        {
            InitializeComponent();
        }

        private void ChonKhachHang_Load(object sender, EventArgs e)
        {
            displayCustomer();
        }
        public void displayCustomer()
        {
            var customers = customerDAO.GetAllCustomers();
            CusView.DataSource = customers;
            CusView.AutoGenerateColumns = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;
            if (name == "" || phone == "" || address == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            else
            {
                Customers customers = new Customers(0, name, phone, address);
                customerDAO.AddCustomer(customers);
                MessageBox.Show("Thêm thành công");
                displayCustomer();
            }

        }

        private void CusView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            if (numrow >= 0)
            {
                cusID = int.Parse(CusView.Rows[numrow].Cells[0].Value.ToString());
                txtName.Text = CusView.Rows[numrow].Cells[1].Value.ToString();
                cusName = txtName.Text;
                txtPhone.Text = CusView.Rows[numrow].Cells[2].Value.ToString();
                txtAddress.Text = CusView.Rows[numrow].Cells[3].Value.ToString();

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;
            if (name == "" || phone == "" || address == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            else
            {
                Customers customers = new Customers(cusID, name, phone, address);
                customerDAO.UpdateCustomer(customers);
                MessageBox.Show("Sửa thành công");
                displayCustomer();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                customerDAO.DeleteCustomer(cusID);
                MessageBox.Show("Xóa thành công");
                displayCustomer();
            }
            catch (Exception)
            {

                MessageBox.Show("Không thể xóa");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            showForm show = new showForm();
            Thread thread = new Thread(show.showFormThemDonHang);
            thread.Start();
            this.Close();
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
    }
}
