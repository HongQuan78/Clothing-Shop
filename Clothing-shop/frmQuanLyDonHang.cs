using Clothing_shop.DAO;
using Clothing_shop.DBConnection;
using Clothing_shop.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;

using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Clothing_shop
{
    public partial class frmQuanLyDonHang : Form
    {   
        public string totalText = "0";
        public int orderID = -1;
        private OrderDAO ordersDAO = new OrderDAO();
        private CustomerDAO customerDAO = new CustomerDAO();
        private EmployeesDAO empDAO = new EmployeesDAO();
        public frmQuanLyDonHang()
        {
            InitializeComponent();
        }

        private void quanLyNhanVien_Menu_Click(object sender, EventArgs e)
        {
            showForm show = new showForm();
            Thread thread = new Thread(new ThreadStart(show.showFormQuanLyNhanVien));
            thread.Start();
            this.Close();
        }

        private void frmQuanLyDonHang_Load(object sender, EventArgs e)
        {   
            lbtotal.Text = ordersDAO.GetTotalAmount().ToString();
            displayOrder();
            displayChart();
            quanLyNhanVien_Menu.Visible = true;
            if (!string.Equals("Manager", frmLogin.employeeLogin.EmployeeRole, StringComparison.CurrentCultureIgnoreCase))
            {
                quanLyNhanVien_Menu.Visible = false;
            }

        }

        public void DGVConfig(List<Orders> orders)
        {
            DataTable dt = new DataTable();
            //custom value in datagridview
            dt.Columns.Add("Mã đơn hàng", typeof(int));
            dt.Columns.Add("Tên khách hàng", typeof(string));
            dt.Columns.Add("Tổng giá tiền", typeof(double));
            dt.Columns.Add("Ngày đặt hàng", typeof(DateTime));
            dt.Columns.Add("Trạng thái", typeof(string));
            dt.Columns.Add("Ngày đã giao", typeof(string));
            foreach (var item in orders)
            {
                Customers cus = customerDAO.GetCustomerById(item.CustomerID);
                dt.Rows.Add(
                item.OrderID, cus.CustomerName,
                item.TotalAmount,
                item.OrderDate,
                item.Status);
            }
            viewOrders.DataSource = dt;
            viewOrders.AutoGenerateColumns = true;
            lbdoanhthu.Text = totalText;
        }

        public void displayOrder()
        {
            var orders = ordersDAO.GetAllOrders();
            DGVConfig(orders);
            viewOrders.Refresh();

        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            showForm show = new showForm();
            Thread thread = new Thread(new ThreadStart(show.showFormThemDonHang));
            thread.Start();
            this.Close();
        }

        private void xemHangTraLaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm show = new showForm();
            Thread thread = new Thread(new ThreadStart(show.showFormHangBiTraLai));
            thread.Start();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void theemToolStripMenuItem_Click(object sender, EventArgs e)
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

        }

        private void xemKhachHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm show = new showForm();
            Thread thread = new Thread(show.showChonKhachHang);
            thread.Start();
            this.Close();
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Xóa đơn hàng này?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    ordersDAO.DeleteOrder(orderID);
                    MessageBox.Show("Xóa thành công");
                    displayOrder();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Không thể xóa");
            }

        }

        private void viewOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            if (numrow >= 0)
            {
                orderID = int.Parse(viewOrders.Rows[numrow].Cells[0].Value.ToString());
            }
        }

        private void quanLySanPhamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm show = new showForm();
            Thread thread = new Thread(show.showQuanLySanPham);
            thread.Start();
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearchBox.Text;
            var orders = ordersDAO.SearchOrder(search);
            DGVConfig(orders);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            displayOrder();
        }

        private void viewOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            if (numrow >= 0)
            {
                orderID = int.Parse(viewOrders.Rows[numrow].Cells[0].Value.ToString());
                Thread thread = new Thread(showOrderDetail);
                thread.Start();
                this.Close();

            }
        }
        public void showOrderDetail()
        {
            OrderDetail orderDetail = new OrderDetail(orderID, -1);
            orderDetail.ShowDialog();
        }

        private void timeFilter_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = timeFilter.Value;
            var orders = ordersDAO.GetOrderByDate(selectedDate);
            totalText = ordersDAO.GetTotalAmountByDate(selectedDate).ToString() + " vnd";
            DGVConfig(orders);
        }

        private void displayChart()
        {
            Dictionary<string, double> chartData = ordersDAO.GetChartData();
            if (chart.Series.IndexOf("Series1") >= 0)
            {
                chart.Series.Remove(chart.Series["Series1"]);
            }

            // Add a new series to the chart
            chart.Series.Add("TotalRevenue");

            // Set the chart type to column chart
            chart.Series["TotalRevenue"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            // Set the X-axis title
            chart.ChartAreas[0].AxisX.Title = "Month/Year";

            // Set the Y-axis title
            chart.ChartAreas[0].AxisY.Title = "Total Revenue (vnd)";

            // Add the chart data to the TotalRevenue series
            foreach (KeyValuePair<string, double> data in chartData)
            {
                chart.Series["TotalRevenue"].Points.AddXY(data.Key, data.Value);
            }

        }

        private void btnXemTheomatHang_Click(object sender, EventArgs e)
        {
            frmChonMatHang chonMatHang = new frmChonMatHang();
            chonMatHang.ShowDialog();
        }

        private void btnChonThang_Click(object sender, EventArgs e)
        {
            new frmChonThang().ShowDialog();
        }
    }
}
