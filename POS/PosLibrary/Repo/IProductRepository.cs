using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PosLibrary.Model;

namespace PosLibrary.Repo
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
        Product GetByBarcode(int barcode);
        IEnumerable<Product> GetByCategoryId(int id);
        Product? GetByName(string name);
        IEnumerable<Product> GetAll();

    }
}
