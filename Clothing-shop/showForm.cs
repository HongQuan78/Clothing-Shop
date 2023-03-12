using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothing_shop
{
    public class showForm
    {
        public void showFormQuanLyNhanVien()
        {
            new frmQuanLyNhanVien().ShowDialog();
        }

        public void showFormLogin()
        {
            new frmLogin().ShowDialog();
        }

        public void showFormQuanLyDonHang()
        {
            new frmQuanLyDonHang().ShowDialog();
        }

        public void showFormThemDonHang()
        {
            new frmThemDonHang().ShowDialog();
        }

        public void showFormHangBiTraLai()
        {
            new frmHangBiTraLai().ShowDialog();
        }
        public void showChonKhachHang()
        {
            new ChonKhachHang().ShowDialog();
        }
        public void showAddOrderDetail()
        {
            new AddOrderDeatail().ShowDialog();
        }
    }
}
