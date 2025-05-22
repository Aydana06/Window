using Microsoft.Data.Sqlite;
using PosLibrary.Model;
using PosLibrary.Repo;
using PosLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosTest
{
    [TestClass]
    public class ProductServiceTests
    {
        private SqliteConnection _connection;
        private ProductService _service;

        [TestInitialize]
        public void Setup()
        {
            //var connString = "DataSource=test.db";
            //File.Delete("test.db");
            //var connString = "DataSource=file:memdb1?mode=memory&cache=shared";
            var connString = $"DataSource=file:memdb1_{Guid.NewGuid()}?mode=memory&cache=shared";
            _connection = new SqliteConnection(connString);
            _connection.Open();

            var command = _connection.CreateCommand();
            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Products (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Barcode INTEGER NOT NULL UNIQUE,
                    Name TEXT NOT NULL,
                    Price REAL NOT NULL,
                    Quantity INTEGER NOT NULL,
                    ImagePath TEXT,
                    CategoryId INTEGER
                );
                DELETE FROM Products;
            ";
            command.ExecuteNonQuery();

            var repo = new ProductRepository(connString);
            _service = new ProductService(repo);
        }


        [TestCleanup]
        public void Cleanup()
        {
            _connection.Close();
        }

        private Product GetSampleProduct(int barcode = 12345, string? name = null)
        {
            return new Product
            {
                Barcode = barcode,
                Name = name ?? "Test product",
                Price = 1000.5m,
                QuantityInStock = 10,
                ImagePath = "path/to/image.jpg",
                CategoryId = 1,
            };
        }

        //Барааг амжилттай нэмсэн эсэх
        [TestMethod]
        public void AddProduct_ShouldAddProductSuccesfully()
        {
            var product = GetSampleProduct(2001, "AddProductTest");

            _service.AddProduct(product);
            var result = _service.GetProductByBarcode(product.Barcode);

            Assert.IsNotNull(result);
            Assert.AreEqual(product.Name, result.Name);
        }

        //Ижил баркодтой бараа нэмэх үед алдаа гаргах
        [TestMethod]
        [ExpectedException(typeof(System.Exception), "Баркод давхцаж байна.")]
        public void AddProduct_WithDuplicateBarcode_ShouldThrowException()
        {
            var product = GetSampleProduct(2002, "DuplicateBarcodeTest");
            _service.AddProduct(product);

            _service.AddProduct(product);
        }
        //Өгөгдөл амжилттай шинэчлэгдсэн эсэх
        [TestMethod]
        public void UpdateProduct_ShouldUpdateFields()
        {
            var product = GetSampleProduct(2003, "UpdateProductTest");
            _service.AddProduct(product);

            product.Name = "New name";
            product.Price = 1500;
            product.QuantityInStock = 50;

            _service.UpdateProduct(product);

            var updated = _service.GetProductByBarcode(product.Barcode);

            Assert.AreEqual("New name", updated.Name);
            Assert.AreEqual(1500, updated.Price);
            Assert.AreEqual(50, updated.QuantityInStock);
        }

        //Устгасны дараа байхгүй болсон эсэх
        [TestMethod]
        public void DeleteProduct_ShouldRemoveProduct()
        {
            var product = GetSampleProduct(2004, "DeleteProductTest");
            _service.AddProduct(product);

            _service.DeleteProduct(product.Barcode);
            var result = _service.GetProductByBarcode(product.Barcode);

            Assert.IsNull(result);
        }

        //Бүх бүтээгдэхүүнийг буцааж чаддаг байх
        [TestMethod]
        public void GetAllProducts_ShouldReturnAll()
        {
            _service.AddProduct(GetSampleProduct(1001, "AllProducts1"));
            _service.AddProduct(GetSampleProduct(1002, "AllProducts2"));
            _service.AddProduct(GetSampleProduct(1003, "AllProducts3"));

            var all = _service.GetAllProducts();

            Assert.AreEqual(3, all.Count());
        }
        //Категоригоор зөв ангилж чаддаг байх
        [TestMethod]
        public void getProductByCategory_ShouldReturnCorrectProducts()
        {
            _service.AddProduct(new Product { Barcode = 1, Name = "Apple", Price = 100, QuantityInStock = 10, CategoryId = 1, ImagePath = null});
            _service.AddProduct(new Product { Barcode = 2, Name = "Banana", Price = 200, QuantityInStock = 20, CategoryId = 2 , ImagePath = null });
            _service.AddProduct(new Product { Barcode = 3, Name = "Orange", Price = 300, QuantityInStock = 30, CategoryId = 1, ImagePath = null });

            var cat1 = _service.GetProductsByCategory(1);
            var cat2 = _service.GetProductsByCategory(2);


            Assert.AreEqual(2, cat1.Count());
            Assert.AreEqual(1, cat2.Count());
        }

        [TestMethod]
        public void GetByName_ShouldReturnProduct_WhenNameMatches()
        {
            var product = GetSampleProduct(5001);
            product.Name = "UniqueTestProduct5001";
            _service.AddProduct(product);

            var result = _service.GetProductByName("UniqueTestProduct5001");

            Assert.IsNotNull(result);
            Assert.AreEqual(product.Name, result.Name);
            Assert.AreEqual(product.Barcode, result.Barcode);
        }

        [TestMethod]
        public void GetByName_ShouldReturnNull_WhenNameNotFound()
        {
            var result = _service.GetProductByName("NonExistent");

            Assert.IsNull(result);
        }
    }
}
