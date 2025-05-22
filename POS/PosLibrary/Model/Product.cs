using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosLibrary.Model
{
    public class Product
    {
        public int Id { get; set; }
        public int Barcode { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public int CategoryId { get; set; }
        public string? ImagePath { get; set; }
    }
}
