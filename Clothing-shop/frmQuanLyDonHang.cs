﻿using Clothing_shop.DAO;
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
    public partial class frmQuanLyDonHang : Form
    {
        private int orderID = -1;
        private OrderDAO ordersDAO = new OrderDAO();
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
            displayOrder();
            quanLyNhanVien_Menu.Visible = true;
            if (!string.Equals("Manager", frmLogin.employeeLogin.EmployeeRole, StringComparison.CurrentCultureIgnoreCase)){
                quanLyNhanVien_Menu.Visible=false;
            }
        }
        public void displayOrder()
        {
            var orders = ordersDAO.GetAllOrders();
            DataTable dt = new DataTable();
            viewOrders.DataSource = orders;
            viewOrders.AutoGenerateColumns = true;
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
    }
}
