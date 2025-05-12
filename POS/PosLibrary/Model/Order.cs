using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosLibrary.Model
{
    public class Order
    {
        public int orderId { get; set; }
        public string ProductName { get; set; }
        public int Quantity {  get; set; }
        public double Price { get; set; }

        public double Total => Quantity * Price;

        public double AmountToPay { get; set; }
        public double Change {  get; set; }
    }
}
