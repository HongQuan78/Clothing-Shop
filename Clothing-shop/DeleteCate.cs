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
    public partial class DeleteCate : Form
    {
        public DeleteCate()
        {
            InitializeComponent();
        }

        private void DeleteCate_Load(object sender, EventArgs e)
        {
            fillComboBox();
        }
        public void fillComboBox()
        {
            CategoryDAO categoryDAO = new CategoryDAO();
            var comboBox = categoryDAO.GetAllCategories();
            CategoryBox.DataSource = comboBox;
            CategoryBox.DisplayMember = "CategoryName";
            CategoryBox.ValueMember = "CategoryID";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = (int)CategoryBox.SelectedValue;
                new CategoryDAO().DeleteCategory(id);
                MessageBox.Show("Xóa thành công!");
                fillComboBox();
            }
            catch (Exception)
            {

                MessageBox.Show("Không thể xóa");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
