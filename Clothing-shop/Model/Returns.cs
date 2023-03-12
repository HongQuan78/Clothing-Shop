using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothing_shop.Model
{
    public class Returns
    {
        public int ReturnID { get; set; }
        public int OrderID { get; set; }
        public string Reason { get; set; }
        public Returns()
        {

        }
        public Returns(int returnID, int orderID, string reason)
        {
            ReturnID = returnID;
            OrderID = orderID;
            Reason = reason;
        }
    }
}
