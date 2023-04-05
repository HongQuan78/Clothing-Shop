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
    public partial class frmChonThang : Form
    {   
        public frmChonThang()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmQuanLyDonHang frm = Application.OpenForms.OfType<frmQuanLyDonHang>().FirstOrDefault();
            if (frm != null)
            {
                OrderDAO dao = new OrderDAO();
                var data = dao.GetOrderByMonth(dateTimePicker.Text);
                frm.totalText = dao.GetTotalAmountByMonth(dateTimePicker.Value).ToString();
                frm.DGVConfig(data);
            }
            this.Close();
        }

        private void frmChonThang_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void frmChonThang_Load(object sender, EventArgs e)
        {

        }
    }
}
