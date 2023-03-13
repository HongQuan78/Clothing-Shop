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
    public partial class OrderDetail : Form
    {
        private Orders orderDisplay = new Orders();
        private Employees employees = new Employees();
        private Customers customers = new Customers();
        private int orderID;
        private int returnID;
        public OrderDetail(int orderid, int returnid)
        {
            InitializeComponent();
            orderID = orderid;
            returnID = returnid;
        }
        private void OrderDetail_Load(object sender, EventArgs e)
        {
            quanLyNhanVien_Menu.Visible = true;
            if (!string.Equals("Manager", frmLogin.employeeLogin.EmployeeRole, StringComparison.CurrentCultureIgnoreCase))
            {
                quanLyNhanVien_Menu.Visible = false;
            }
            OrderDAO orderDAO = new OrderDAO();

            orderDisplay = orderDAO.GetOrderById(orderID);
            txtEmpName.Text = new EmployeesDAO().GetEmployeesByID(orderDisplay.EmployeeID).EmployeeName;
            txtCusname.Text = new CustomerDAO().GetCustomerById(orderDisplay.CustomerID).CustomerName;
            txtTotal.Text = orderDisplay.TotalAmount.ToString();
            cmbStatus.Text = orderDisplay.Status.ToString();
            orderDate.Text = orderDisplay.OrderDate.ToString();
            txtAddress.Text = new CustomerDAO().GetCustomerById(orderDisplay.CustomerID).CustomerAddress;
            txtPhone.Text = new CustomerDAO().GetCustomerById(orderDisplay.CustomerID).CustomerPhone;
            if (returnID >= 0) { checkBox1.Checked = true; }
            if (orderDisplay.ModifiedDate != DateTime.MinValue)
            {
                modifierDate.Text = orderDisplay.ModifiedDate.ToString();
            }
            else
            {
                modifierDate.Text = orderDate.Text;
            }
            displayOrderItems();
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

        private void button1_Click(object sender, EventArgs e)
        {
            string status = cmbStatus.Text;
            new OrderDAO().UpdateOrderStatus(orderID, status);
            if (returnID < 0)
            {
                showForm show = new showForm();
                Thread thread = new Thread(show.showFormQuanLyDonHang);
                thread.Start();
            }
            this.Close();


        }

        public void showOrderItems()
        {
            var orderItems = new OrderItemsDAO().GetOrderItemsByOrderID(orderID);

        }

        private void cmbStatus_ValueMemberChanged(object sender, EventArgs e)
        {

        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void displayOrderItems()
        {
            var list = new OrderItemsDAO().getInvoice(orderID);
            OrderDetailView.DataSource = list;
            OrderDetailView.AutoGenerateColumns = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (returnID >= 0)
            {   
                if(!checkBox1.Checked) {
                    new ReturnsDAO().Delete(returnID);
                }
                return;
            }
            if (checkBox1.Checked)
            {
                new getReason().ShowDialog();
                string reason = getReason.Reason;
                new ReturnsDAO().Create(new Returns
                {
                    OrderID = orderID,
                    Reason = reason
                });
                return;
            }
           
        }

        private void OrderDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmHangBiTraLai frm = Application.OpenForms.OfType<frmHangBiTraLai>().FirstOrDefault();
            if (frm != null)
            {
                frm.displayReturn();
            }
        }
    }
}
