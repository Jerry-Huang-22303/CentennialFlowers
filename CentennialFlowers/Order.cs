using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentennialFlowers
{
    class Order
    {
        private int quantity;
        private double unitPrice;
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public string Arrangement { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice{
            get
            {
                return UnitPrice * Quantity;
            }
        }
        public Order()
        {
            Quantity = 0;
            UnitPrice = 0;
        }
    }
}
