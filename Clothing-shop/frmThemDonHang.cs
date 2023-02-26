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
    public partial class frmThemDonHang : Form
    {
        public frmThemDonHang()
        {
            InitializeComponent();
        }

        private void ProductViews_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // I suppose your check box is at column index 0
            if (e.ColumnIndex == 0 && e.RowIndex == ProductViews.NewRowIndex)
            {
                e.PaintBackground(e.ClipBounds, true);
                e.Handled = true;
            }

        }

        private void quanLyNhanVien_Menu_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(showFormQuanLyNhanVien));
            thread.Start();
            this.Close();
        }

        private void showFormQuanLyNhanVien()
        {
            frmQuanLyNhanVien quanLyNhanVien = new frmQuanLyNhanVien(); 
            quanLyNhanVien.ShowDialog();
        }
    }
}
