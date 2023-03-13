namespace Clothing_shop
{
    partial class AddOrderDeatail
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
            this.productsView = new System.Windows.Forms.DataGridView();
            this.label = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnback = new System.Windows.Forms.Button();
            this.amount = new System.Windows.Forms.NumericUpDown();
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
            ((System.ComponentModel.ISupportInitialize)(this.productsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amount)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // productsView
            // 
            this.productsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productsView.Location = new System.Drawing.Point(12, 267);
            this.productsView.Name = "productsView";
            this.productsView.Size = new System.Drawing.Size(776, 171);
            this.productsView.TabIndex = 10;
            this.productsView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.productsView_CellClick);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(13, 248);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(75, 13);
            this.label.TabIndex = 11;
            this.label.Text = "Các sản phẩm";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(292, 129);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(455, 20);
            this.txtPrice.TabIndex = 17;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(292, 88);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(455, 20);
            this.txtName.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(86, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 24);
            this.label3.TabIndex = 14;
            this.label3.Text = "Giá Tiền";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(86, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 24);
            this.label2.TabIndex = 13;
            this.label2.Text = "Tên Sản Phẩm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(86, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 24);
            this.label1.TabIndex = 18;
            this.label1.Text = "Số Lượng";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(481, 210);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnback
            // 
            this.btnback.Location = new System.Drawing.Point(644, 210);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(103, 23);
            this.btnback.TabIndex = 21;
            this.btnback.Text = "Thêm Đơn Hàng";
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // amount
            // 
            this.amount.Location = new System.Drawing.Point(292, 174);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(142, 20);
            this.amount.TabIndex = 22;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 23;
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
            this.xemHangTraLai.Click += new System.EventHandler(this.xemHangTraLai_Click);
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
            // AddOrderDeatail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.amount);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label);
            this.Controls.Add(this.productsView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddOrderDeatail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý cửa hàng";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddOrderDeatail_FormClosed);
            this.Load += new System.EventHandler(this.AddOrderDeatail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amount)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView productsView;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.NumericUpDown amount;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quanLyDonHang;
        private System.Windows.Forms.ToolStripMenuItem quanLyNhanVien_Menu;
        private System.Windows.Forms.ToolStripMenuItem xemHangTraLai;
        private System.Windows.Forms.ToolStripMenuItem theemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xemKhachHangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quanLySanPhamToolStripMenuItem;
    }
}