using Clothing_shop.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clothing_shop
{
    public partial class frmChonMatHang : Form
    {
        public frmChonMatHang()
        {
            InitializeComponent();
        }

        private void frmChonMatHang_Load(object sender, EventArgs e)
        {
            fillCombobox();
        }
        private void fillCombobox()
        {
            ProductDAO productDAO = new ProductDAO();
            var data = productDAO.GetAllProducts();
            //fill combobox
            comboBox1.DataSource= data;
            comboBox1.DisplayMember = "ProductName";
            comboBox1.ValueMember = "ProductID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmQuanLyDonHang frm = Application.OpenForms.OfType<frmQuanLyDonHang>().FirstOrDefault();
            if (frm != null)
            {
                OrderDAO dao = new OrderDAO();
                var data = dao.GetOrderByProductName(comboBox1.Text);
                frm.totalText = dao.GetTotalAmountByProductName(comboBox1.Text).ToString();
                frm.DGVConfig(data);

            }
            this.Close();
        }

        private void frmChonMatHang_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }
    }
}
