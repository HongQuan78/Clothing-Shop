using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clothing_shop.DBConnection
{
    public class DBConnect
    {
        public SqlConnection connection;
        public DBConnect()
        {

        }
        string connectionString = "Server=HongQuan\\SQLEXPRESS;Database=clothing_shop_management;User Id=sa;Password=123456;";
        public SqlConnection getConnection() {
            try
            {
                connection = new SqlConnection(connectionString);
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi xảy ra!");
            }   
            return connection;
        }
    }
}
