using Microsoft.Data.Sqlite;
using PosLibrary.Model;
using PosLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosTest
{
    [TestClass]
    public class OrderServiceTests
    {
        private SqliteConnection _connection;
        private OrderService _service;

        [TestInitialize]
        public void Setup()
        {
            var connString = $"DataSource=file:memdb_{Guid.NewGuid()};mode=memory;cache=shared";
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
                INSERT INTO Products (Barcode, Name, Price, Quantity, ImagePath, CategoryId)
                VALUES (1001, 'Apple', 100, 20, NULL, 1);
            ";
            command.ExecuteNonQuery();

            _service = new OrderService(connString);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _connection.Close();
        }

        [TestMethod]
        public void CalculateOrderTotal_ShouldReturnCorrectSum()
        {
            var items = new List<OrderItem>
            {
                new OrderItem { ProductName = "Apple", Quantity = 2, Price = 100},
                new OrderItem { ProductName = "Banana", Quantity = 1, Price = 150, }
            };

            var total = _service.CalculateOrderTotal(items);

            Assert.AreEqual(350, total);
        }

        [TestMethod]
        public void CalculateChange_ShouldReturnCorrectChange()
        {
            decimal totalAmount = 800;
            decimal amountPaid = 1000;

            var change = _service.CalculateChange(totalAmount, amountPaid);

            Assert.AreEqual(200, change);
        }

        [TestMethod]
        public void ReduceQuantity_ShouldSubtractQuantity_WhenEnoughInStock()
        {
            _service.ReduceQuantity("Apple", 5);

            using var checkCmd = _connection.CreateCommand();
            checkCmd.CommandText = "SELECT Quantity FROM Products WHERE Name='Apple'";
            var newQuantity = (long)checkCmd.ExecuteScalar();

            Assert.AreEqual(15, newQuantity);
        }

        [TestMethod]
        public void ReduceQuantity_ShouldNotSubtract_WhenNotEnoughStock()
        {
            _service.ReduceQuantity("Apple", 999);

            using var checkCmd = _connection.CreateCommand();
            checkCmd.CommandText = "SELECT Quantity FROM Products WHERE Name='Apple'";
            var quantity = (long)checkCmd.ExecuteScalar();

            Assert.AreEqual(20, quantity);
        }
    }
}
