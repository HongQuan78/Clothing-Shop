namespace Clothing_shop
{
    partial class frmQuanLyDonHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLyDonHang));
            this.viewOrders = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.btnDeleteOrder = new System.Windows.Forms.Button();
            this.txtSearchBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quanLyDonHang = new System.Windows.Forms.ToolStripMenuItem();
            this.quanLyNhanVien_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.quanLySanPhamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xemHangTraLai = new System.Windows.Forms.ToolStripMenuItem();
            this.theemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xemKhachHangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.timeFilter = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbtotal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnChonThang = new System.Windows.Forms.Button();
            this.btnXemTheomatHang = new System.Windows.Forms.Button();
            this.lbdoanhthu = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.employeesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.btnPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.viewOrders)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // viewOrders
            // 
            this.viewOrders.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.viewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewOrders.Location = new System.Drawing.Point(19, 102);
            this.viewOrders.Name = "viewOrders";
            this.viewOrders.Size = new System.Drawing.Size(569, 318);
            this.viewOrders.TabIndex = 0;
            this.viewOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.viewOrders_CellClick);
            this.viewOrders.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.viewOrders.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.viewOrders_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(190, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Quản Lý Đơn Hàng";
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.BackColor = System.Drawing.Color.Cyan;
            this.btnAddOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddOrder.Location = new System.Drawing.Point(227, 129);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(102, 26);
            this.btnAddOrder.TabIndex = 2;
            this.btnAddOrder.Text = "Thêm";
            this.btnAddOrder.UseVisualStyleBackColor = false;
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
            // 
            // btnDeleteOrder
            // 
            this.btnDeleteOrder.BackColor = System.Drawing.Color.Red;
            this.btnDeleteOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteOrder.Location = new System.Drawing.Point(354, 129);
            this.btnDeleteOrder.Name = "btnDeleteOrder";
            this.btnDeleteOrder.Size = new System.Drawing.Size(102, 26);
            this.btnDeleteOrder.TabIndex = 3;
            this.btnDeleteOrder.Text = "Xóa";
            this.btnDeleteOrder.UseVisualStyleBackColor = false;
            this.btnDeleteOrder.Click += new System.EventHandler(this.btnDeleteOrder_Click);
            // 
            // txtSearchBox
            // 
            this.txtSearchBox.Location = new System.Drawing.Point(179, 103);
            this.txtSearchBox.Name = "txtSearchBox";
            this.txtSearchBox.Size = new System.Drawing.Size(193, 20);
            this.txtSearchBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(83, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tìm Kiếm";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quanLyDonHang,
            this.quanLyNhanVien_Menu,
            this.quanLySanPhamToolStripMenuItem,
            this.xemHangTraLai,
            this.theemToolStripMenuItem,
            this.xemKhachHangToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // quanLyDonHang
            // 
            this.quanLyDonHang.Name = "quanLyDonHang";
            this.quanLyDonHang.Size = new System.Drawing.Size(170, 22);
            this.quanLyDonHang.Text = "Quản lý đơn hàng";
            this.quanLyDonHang.Click += new System.EventHandler(this.quanLyDonHang_Click);
            // 
            // quanLyNhanVien_Menu
            // 
            this.quanLyNhanVien_Menu.Name = "quanLyNhanVien_Menu";
            this.quanLyNhanVien_Menu.Size = new System.Drawing.Size(170, 22);
            this.quanLyNhanVien_Menu.Text = "Quản lý nhân viên";
            this.quanLyNhanVien_Menu.Click += new System.EventHandler(this.quanLyNhanVien_Menu_Click);
            // 
            // quanLySanPhamToolStripMenuItem
            // 
            this.quanLySanPhamToolStripMenuItem.Name = "quanLySanPhamToolStripMenuItem";
            this.quanLySanPhamToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.quanLySanPhamToolStripMenuItem.Text = "Quản lý sản phẩm";
            this.quanLySanPhamToolStripMenuItem.Click += new System.EventHandler(this.quanLySanPhamToolStripMenuItem_Click);
            // 
            // xemHangTraLai
            // 
            this.xemHangTraLai.Name = "xemHangTraLai";
            this.xemHangTraLai.Size = new System.Drawing.Size(170, 22);
            this.xemHangTraLai.Text = "Xem Hàng Trả Lại";
            this.xemHangTraLai.Click += new System.EventHandler(this.xemHangTraLaiToolStripMenuItem_Click);
            // 
            // theemToolStripMenuItem
            // 
            this.theemToolStripMenuItem.Name = "theemToolStripMenuItem";
            this.theemToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.theemToolStripMenuItem.Text = "Thêm Đơn Hàng";
            this.theemToolStripMenuItem.Click += new System.EventHandler(this.theemToolStripMenuItem_Click);
            // 
            // xemKhachHangToolStripMenuItem
            // 
            this.xemKhachHangToolStripMenuItem.Name = "xemKhachHangToolStripMenuItem";
            this.xemKhachHangToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.xemKhachHangToolStripMenuItem.Text = "Xem Khách Hàng";
            this.xemKhachHangToolStripMenuItem.Click += new System.EventHandler(this.xemKhachHangToolStripMenuItem_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(391, 103);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.Cyan;
            this.btnShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(100, 129);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(102, 26);
            this.btnShow.TabIndex = 9;
            this.btnShow.Text = "Hiển thị";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // timeFilter
            // 
            this.timeFilter.CustomFormat = "MM";
            this.timeFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.timeFilter.Location = new System.Drawing.Point(468, 80);
            this.timeFilter.Name = "timeFilter";
            this.timeFilter.Size = new System.Drawing.Size(120, 20);
            this.timeFilter.TabIndex = 10;
            this.timeFilter.ValueChanged += new System.EventHandler(this.timeFilter_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.lbtotal);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnChonThang);
            this.panel1.Controls.Add(this.btnXemTheomatHang);
            this.panel1.Controls.Add(this.lbdoanhthu);
            this.panel1.Controls.Add(this.viewOrders);
            this.panel1.Controls.Add(this.timeFilter);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(581, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(591, 472);
            this.panel1.TabIndex = 11;
            // 
            // lbtotal
            // 
            this.lbtotal.AutoSize = true;
            this.lbtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtotal.Location = new System.Drawing.Point(147, 31);
            this.lbtotal.Name = "lbtotal";
            this.lbtotal.Size = new System.Drawing.Size(20, 18);
            this.lbtotal.TabIndex = 21;
            this.lbtotal.Text = "...";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 18);
            this.label6.TabIndex = 20;
            this.label6.Text = "Tổng doanh thu";
            // 
            // btnChonThang
            // 
            this.btnChonThang.Location = new System.Drawing.Point(150, 77);
            this.btnChonThang.Name = "btnChonThang";
            this.btnChonThang.Size = new System.Drawing.Size(122, 23);
            this.btnChonThang.TabIndex = 19;
            this.btnChonThang.Text = "Xem theo tháng";
            this.btnChonThang.UseVisualStyleBackColor = true;
            this.btnChonThang.Click += new System.EventHandler(this.btnChonThang_Click);
            // 
            // btnXemTheomatHang
            // 
            this.btnXemTheomatHang.Location = new System.Drawing.Point(19, 77);
            this.btnXemTheomatHang.Name = "btnXemTheomatHang";
            this.btnXemTheomatHang.Size = new System.Drawing.Size(122, 23);
            this.btnXemTheomatHang.TabIndex = 17;
            this.btnXemTheomatHang.Text = "Xem theo mặt hàng";
            this.btnXemTheomatHang.UseVisualStyleBackColor = true;
            this.btnXemTheomatHang.Click += new System.EventHandler(this.btnXemTheomatHang_Click);
            // 
            // lbdoanhthu
            // 
            this.lbdoanhthu.AutoSize = true;
            this.lbdoanhthu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbdoanhthu.Location = new System.Drawing.Point(124, 423);
            this.lbdoanhthu.Name = "lbdoanhthu";
            this.lbdoanhthu.Size = new System.Drawing.Size(20, 18);
            this.lbdoanhthu.TabIndex = 12;
            this.lbdoanhthu.Text = "...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 423);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "Tổng số tiền";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Thống kê doanh thu theo tháng";
            // 
            // chart
            // 
            chartArea2.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart.Legends.Add(legend2);
            this.chart.Location = new System.Drawing.Point(15, 205);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart.Series.Add(series2);
            this.chart.Size = new System.Drawing.Size(560, 278);
            this.chart.TabIndex = 13;
            this.chart.Text = "Thống kê doanh thu";
            // 
            // employeesBindingSource
            // 
            this.employeesBindingSource.DataSource = typeof(Clothing_shop.Model.Employees);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnPrint.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnPrint.Location = new System.Drawing.Point(513, 446);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 22;
            this.btnPrint.Text = "In";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmQuanLyDonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 511);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSearchBox);
            this.Controls.Add(this.btnDeleteOrder);
            this.Controls.Add(this.btnAddOrder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQuanLyDonHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý cửa hàng";
            this.Load += new System.EventHandler(this.frmQuanLyDonHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.viewOrders)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView viewOrders;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.Button btnDeleteOrder;
        private System.Windows.Forms.TextBox txtSearchBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quanLyDonHang;
        private System.Windows.Forms.ToolStripMenuItem quanLyNhanVien_Menu;
        private System.Windows.Forms.ToolStripMenuItem xemHangTraLai;
        private System.Windows.Forms.BindingSource employeesBindingSource;
        private System.Windows.Forms.ToolStripMenuItem theemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xemKhachHangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quanLySanPhamToolStripMenuItem;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.DateTimePicker timeFilter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbdoanhthu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Button btnXemTheomatHang;
        private System.Windows.Forms.Button btnChonThang;
        private System.Windows.Forms.Label lbtotal;
        private System.Windows.Forms.Label label6;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}