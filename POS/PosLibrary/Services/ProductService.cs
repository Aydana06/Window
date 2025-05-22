using PosLibrary.Repo;
using PosLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Reflection.Emit;
using Microsoft.Data.Sqlite;

namespace PosLibrary.Services
{
    public class ProductService
    {
        private readonly ProductRepository _repo;

        public ProductService(ProductRepository repo) {
            _repo = repo;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _repo.GetAll();
        }
        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            return _repo.GetByCategoryId(categoryId);
        }

        public Product? GetProductByName(string name)
        {
            return _repo.GetByName(name);
        }

        public Product? GetProductByBarcode(int barcode) {
            return _repo.GetByBarcode(barcode);
        }

        public void AddProduct(Product product)
        {
            var existingProduct = _repo.GetByBarcode(product.Barcode);

            if (existingProduct != null) {
                throw new Exception("Баркод давхцаж байна.");
            }
            _repo.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            _repo.Update(product);
        }

        public void DeleteProduct(int barcode) {
            _repo.Delete(barcode);
        }
        
    }
}
