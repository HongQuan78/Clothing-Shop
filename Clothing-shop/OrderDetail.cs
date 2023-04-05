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
            orderDate.Enabled = false;
            modifierDate.Enabled = false;
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
                if (!checkBox1.Checked)
                {
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

        Bitmap bmp;
        private void btnPrint_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            bmp = new Bitmap(this.Size.Width, this.Size.Height, g);
            Graphics mg = Graphics.FromImage(bmp);
            mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Lấy các thông tin khách hàng và đơn hàng
            string empName = "Tên nhân viên: " + txtEmpName.Text;
            string cusName = "Tên khách hàng: " + txtCusname.Text;
            string cusAddress = "Địa chỉ khách hàng: " + txtAddress.Text;
            string cusPhone = "Số điện thoại khách hàng: " + txtPhone.Text;
            string total = "Tổng giá: " + txtTotal.Text;
            string status = "Trạng thái: " + cmbStatus.Text;
            string orderDate = "Ngày đặt hàng: " + this.orderDate.Text;
            string modifierDate = "Đã giao vào ngày: " + this.modifierDate.Text;

           

            // Tạo font và brush để vẽ chữ
            Font font = new Font("Arial", 12, FontStyle.Bold);
            SolidBrush brush = new SolidBrush(Color.Black);

            // Vị trí để in các thông tin
            PointF empNamePosition = new PointF(10, 10);
            PointF cusNamePosition = new PointF(10, 30);
            PointF cusAddressPosition = new PointF(10, 50);
            PointF cusPhonePosition = new PointF(10, 70);
            PointF totalPosition = new PointF(10, 90);
            PointF statusPosition = new PointF(10, 110);
            PointF orderDatePosition = new PointF(10, 130);
            PointF modifierDatePosition = new PointF(10, 150);

            // In các thông tin khách hàng và đơn hàng
            e.Graphics.DrawString(empName, font, brush, empNamePosition);
            e.Graphics.DrawString(cusName, font, brush, cusNamePosition);
            e.Graphics.DrawString(cusAddress, font, brush, cusAddressPosition);
            e.Graphics.DrawString(cusPhone, font, brush, cusPhonePosition);
            e.Graphics.DrawString(total, font, brush, totalPosition);
            e.Graphics.DrawString(status, font, brush, statusPosition);
            e.Graphics.DrawString(orderDate, font, brush, orderDatePosition);
            e.Graphics.DrawString(modifierDate, font, brush, modifierDatePosition);

            // Vị trí của bảng
            PointF tablePosition = new PointF(10, 200);

            // Kích thước của mỗi ô
            float cellHeight = 30;

            // Kích thước của các cột trong bảng
            float productNameWidth = 300;
            float unitPriceWidth = 100;
            float quantityWidth = 100;
            float totalWidth = 100;

            // Vị trí của từng cột trong bảng
            PointF productNamePosition = tablePosition;
            PointF unitPricePosition = new PointF(productNamePosition.X + productNameWidth, tablePosition.Y);
            PointF quantityPosition = new PointF(unitPricePosition.X + unitPriceWidth, tablePosition.Y);
            PointF totalPricePosition = new PointF(quantityPosition.X + quantityWidth, tablePosition.Y);
            PointF totalPositionTable = new PointF(quantityPosition.X + quantityWidth, tablePosition.Y);
            
            var orderItems = new OrderItemsDAO().getInvoice(orderID);
            // Vẽ các ô trong bảng
            foreach (var orderItem in orderItems)
            {
                // Vẽ tên sản phẩm
                e.Graphics.DrawString(orderItem.ProductName, font, brush, productNamePosition);

                // Vẽ số lượng sản phẩm
                e.Graphics.DrawString(orderItem.OrderItems_Quantity.ToString(), font, brush, quantityPosition);

                // Vẽ tổng giá tiền của sản phẩm đó
                e.Graphics.DrawString(orderItem.Price.ToString(), font, brush, unitPricePosition);
                e.Graphics.DrawString((orderItem.Price * orderItem.OrderItems_Quantity).ToString(), font, brush, totalPricePosition);

                // Di chuyển đến hàng tiếp theo
                productNamePosition.Y += cellHeight;
                unitPricePosition.Y += cellHeight;
                quantityPosition.Y += cellHeight;
                totalPricePosition.Y += cellHeight;
                totalPositionTable.Y += cellHeight;
            }

            // Vẽ đường viền cho bảng
            e.Graphics.DrawRectangle(new Pen(Color.Black), tablePosition.X, tablePosition.Y, productNameWidth + unitPriceWidth + quantityWidth + totalWidth, cellHeight * (orderItems.Count + 1));

        }
    }
}
