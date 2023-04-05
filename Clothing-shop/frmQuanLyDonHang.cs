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
        private static List<Orders> printData;
        private OrderDAO ordersDAO = new OrderDAO();
        private CustomerDAO customerDAO = new CustomerDAO();
        private EmployeesDAO empDAO = new EmployeesDAO();

        private List<List<string>> pages; // stores the data for each page
        private int currentPage; // the index of the current page being printed
        private int rowsPerPage; // the number of rows that can fit on one page
        private int totalRows; // the total number of rows in the data

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
            printData = orders;
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

        Bitmap bmp;

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            bmp = new Bitmap(1200, 800, g);
            Graphics mg = Graphics.FromImage(bmp);
            mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string title = "Báo Cáo Doanh Thu";
            Font titleFont = new Font("Arial", 20, FontStyle.Bold);
            Font font = new Font("Arial", 12, FontStyle.Regular);
            e.Graphics.DrawString(title, titleFont, Brushes.Black, 300, 50);
            e.Graphics.DrawString("Ngày: " + DateTime.Now.ToString("dd/MM/yyyy"), font, Brushes.Black, 50, 100);
            e.Graphics.DrawString("Tổng doanh thu: " + totalText, font, Brushes.Black, 50, 150);
            //print table data of printData
            int row = 200;
            int col = 50;
            int width = 120;
            int height = 50;
            int i = 0;

            // loop through each column to print headers
            if (viewOrders != null)
            {
                foreach (DataGridViewColumn column in viewOrders.Columns)
                {
                    if (column != null)
                    {
                        e.Graphics.DrawRectangle(Pens.Black, new Rectangle(col + i * width, row, width, height));
                        e.Graphics.DrawString(column.HeaderText ?? string.Empty, font, Brushes.Black, new Rectangle(col + i * width, row, width, height));
                        i++;
                    }
                }
            }

            // loop through each row to print data
            row += height;
            if (viewOrders != null)
            {
                foreach (DataGridViewRow datarow in viewOrders.Rows)
                {
                    i = 0;
                    if (datarow != null && datarow.Cells != null)
                    {
                        foreach (DataGridViewCell cell in datarow.Cells)
                        {
                            if (cell != null)
                            {
                                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(col + i * width, row, width, height));
                                e.Graphics.DrawString(cell.Value?.ToString() ?? string.Empty, font, Brushes.Black, new Rectangle(col + i * width, row, width, height));
                                i++;
                            }
                        }
                        row += height;
                    }
                }
            }
            

            // Calculate the height of the table
            int tableHeight = (viewOrders.Rows.Count + 1) * height; // add 1 to account for header row

            // Calculate the height of any additional text
            int additionalHeight = 200; // change this value as needed

            // Calculate the total height of the page
            int pageHeight = tableHeight + additionalHeight;
            //in ra người lập báo cáo ở góc dưới bên phải
            e.Graphics.DrawString("Người lập báo cáo", font, Brushes.Black, 600, pageHeight);
            Font fontSmall = new Font("Arial", 8, FontStyle.Regular);
            e.Graphics.DrawString("Ký và ghi rõ họ tên", fontSmall, Brushes.Black, 620, pageHeight + 30);
            // Set the paper size of the page to match the size of the form
            pageHeight += 300;
            e.PageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom", this.Width, this.Height);

            // Draw a rectangle around the entire page
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(0, 0, this.Width - 1, pageHeight - 1));
        }
    }
}
