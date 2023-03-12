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
    public partial class getReason : Form
    {
        public static string Reason;
        public getReason()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Reason = textBox1.Text;
            this.Close();
        }

        private void getReason_Load(object sender, EventArgs e)
        {

        }
    }
}
