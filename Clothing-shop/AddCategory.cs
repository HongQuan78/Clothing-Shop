using Clothing_shop.DAO;
using Clothing_shop.Model;
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
    public partial class AddCategory : Form
    {
        public AddCategory()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Categories cate = new Categories();
            cate.CategoryName = txtName.Text;
            cate.CategoryDescription = txtDescription.Text;
            new CategoryDAO().CreateCategory(cate);
            MessageBox.Show("Thêm thành công!");
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
