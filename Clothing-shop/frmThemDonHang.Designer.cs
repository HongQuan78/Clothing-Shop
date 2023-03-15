namespace Clothing_shop
{
    partial class frmThemDonHang
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chooseCustomer = new System.Windows.Forms.Button();
            this.addOrderItems = new System.Windows.Forms.Button();
            this.OrderView = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
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
            this.btnDeleteOrderItems = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.OrderView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(301, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Thêm Đơn Hàng ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(118, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên Khách Hàng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(118, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Số Điện Thoại";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(118, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "Địa Chỉ";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(290, 120);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(382, 20);
            this.txtName.TabIndex = 9;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(290, 208);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(382, 20);
            this.txtAddress.TabIndex = 10;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(290, 164);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(382, 20);
            this.txtPhone.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(122, 294);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Thêm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chooseCustomer
            // 
            this.chooseCustomer.Location = new System.Drawing.Point(250, 294);
            this.chooseCustomer.Name = "chooseCustomer";
            this.chooseCustomer.Size = new System.Drawing.Size(114, 23);
            this.chooseCustomer.TabIndex = 13;
            this.chooseCustomer.Text = "Chọn Khách Hàng";
            this.chooseCustomer.UseVisualStyleBackColor = true;
            this.chooseCustomer.Click += new System.EventHandler(this.chooseCustomer_Click);
            // 
            // addOrderItems
            // 
            this.addOrderItems.Location = new System.Drawing.Point(390, 294);
            this.addOrderItems.Name = "addOrderItems";
            this.addOrderItems.Size = new System.Drawing.Size(110, 23);
            this.addOrderItems.TabIndex = 15;
            this.addOrderItems.Text = "Thêm sản phẩm";
            this.addOrderItems.UseVisualStyleBackColor = true;
            this.addOrderItems.Click += new System.EventHandler(this.addOrderItems_Click);
            // 
            // OrderView
            // 
            this.OrderView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrderView.Location = new System.Drawing.Point(12, 350);
            this.OrderView.Name = "OrderView";
            this.OrderView.Size = new System.Drawing.Size(784, 190);
            this.OrderView.TabIndex = 16;
            this.OrderView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OrderView_CellClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 331);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Các sản phẩm";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.Location = new System.Drawing.Point(290, 250);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(382, 20);
            this.txtTotalAmount.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(118, 250);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 24);
            this.label6.TabIndex = 18;
            this.label6.Text = "Tổng giá tiền";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(808, 24);
            this.menuStrip1.TabIndex = 20;
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
            this.quanLyNhanVien_Menu.Click += new System.EventHandler(this.quanLyNhanVien_Menu_Click_1);
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
            // 
            // xemKhachHangToolStripMenuItem
            // 
            this.xemKhachHangToolStripMenuItem.Name = "xemKhachHangToolStripMenuItem";
            this.xemKhachHangToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.xemKhachHangToolStripMenuItem.Text = "Xem Khách Hàng";
            this.xemKhachHangToolStripMenuItem.Click += new System.EventHandler(this.xemKhachHangToolStripMenuItem_Click);
            // 
            // btnDeleteOrderItems
            // 
            this.btnDeleteOrderItems.Location = new System.Drawing.Point(530, 294);
            this.btnDeleteOrderItems.Name = "btnDeleteOrderItems";
            this.btnDeleteOrderItems.Size = new System.Drawing.Size(109, 23);
            this.btnDeleteOrderItems.TabIndex = 22;
            this.btnDeleteOrderItems.Text = "Xóa sản phẩm";
            this.btnDeleteOrderItems.UseVisualStyleBackColor = true;
            this.btnDeleteOrderItems.Click += new System.EventHandler(this.btnDeleteOrderItems_Click);
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(671, 294);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(109, 23);
            this.btnDone.TabIndex = 23;
            this.btnDone.Text = "Xong";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // frmThemDonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 552);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.btnDeleteOrderItems);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.OrderView);
            this.Controls.Add(this.addOrderItems);
            this.Controls.Add(this.chooseCustomer);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThemDonHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý cửa hàng ";
            this.Load += new System.EventHandler(this.frmThemDonHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OrderView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button chooseCustomer;
        private System.Windows.Forms.Button addOrderItems;
        private System.Windows.Forms.DataGridView OrderView;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label label6;
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
        private System.Windows.Forms.Button btnDeleteOrderItems;
        private System.Windows.Forms.Button btnDone;
    }
}