using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosLibrary.Model
{
    public class Order
    {
        public int Id { get; set; }
        public List<OrderItem> Items { get; set; } = new();
        public decimal TotalAmount
        {
            get
            {
                decimal totalAmount = 0;
                foreach (var item in Items)
                {
                    totalAmount += item.Total;
                }
                return totalAmount;
            }
        }
    }
}
