using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentennialFlowers
{
    [Serializable]
    class Order
    {
        private int quantity;
        private double unitPrice;
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public string Arrangement { get; set; }
        public int Quantity 
        { 
            get
            {
                return quantity;
            }

            set
            {
                if( value<=0)
                    
                    throw (new Exception("Quantity must be more than 0"));
                else
                        quantity = value;
                
            } 
        }
        public double UnitPrice
        {
            get
            {
                return unitPrice;
            }
                set
            {
                if (value < 0)
                    throw (new Exception("Unit Price must be positive number"));
                unitPrice = value;
            }
                }
        public double TotalPrice{
            get
            {
                return UnitPrice * Quantity;
            }
        }
        public Order()
        {
            Quantity = 1;
            UnitPrice = 0;
        }
    }
}
