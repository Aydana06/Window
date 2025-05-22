using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Data.Sqlite;
using PosLibrary.Model;
using PosLibrary.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PosLibrary.Repo
{
    public class ProductRepository: IProductRepository
    {
        private readonly string _connString;

        public ProductRepository(string connString)
        {
            _connString = connString;
        }

        private Product MapProduct(SqliteDataReader reader)
        {
            return new Product
            {
                Id = Convert.ToInt32(reader["Id"]),
                Name = reader["Name"].ToString(),
                Price = Convert.ToDecimal(reader["Price"]),
                ImagePath = reader["ImagePath"].ToString(),
                Barcode = Convert.ToInt32(reader["Barcode"]),
                QuantityInStock = Convert.ToInt32(reader["Quantity"]),
                CategoryId = Convert.ToInt32(reader["CategoryId"])
            };
        }

        public IEnumerable<Product> GetAll()
        {
            var products = new List<Product>();
            using var conn = new SqliteConnection(_connString);
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Products";
            using var reader = cmd.ExecuteReader();

            while (reader.Read()) {
                products.Add(MapProduct(reader));
            }
            return products;
        }

        public IEnumerable<Product> GetByCategoryId(int categoryId)
        {
            var products = new List<Product>();

            using var conn = new SqliteConnection(_connString);
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Products WHERE CategoryId=@CategoryId";
            cmd.Parameters.AddWithValue("@CategoryId", categoryId);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                products.Add(MapProduct(reader));
            }
            return products;
        }

        public Product? GetByName(string productName)
        {
            using var conn = new SqliteConnection(_connString);
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Products WHERE Name=@Name";
            cmd.Parameters.AddWithValue("@Name", productName);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                return MapProduct(reader);
            }
            return null;
        }


        public Product GetByBarcode(int barcode)
        {
            using var conn = new SqliteConnection(_connString);
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Products WHERE Barcode=@Barcode";
            cmd.Parameters.AddWithValue("@Barcode", barcode);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                return MapProduct(reader);
            }
            return null;
        }

        public void Add(Product product)
        {
            using var conn = new SqliteConnection(_connString);
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Products (Barcode, Name, Price, Quantity, ImagePath, CategoryId) " +
                "VALUES (@Barcode, @Name, @Price, @Quantity, @ImagePath, @CategoryId) ";

            cmd.Parameters.AddWithValue("@Barcode", product.Barcode);
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.Parameters.AddWithValue("@Quantity", product.QuantityInStock);
            cmd.Parameters.AddWithValue("@ImagePath", product.ImagePath ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@CategoryId", product.CategoryId);

            cmd.ExecuteNonQuery();

        }

        public void Update(Product product)
        {
            using var conn = new SqliteConnection(_connString);
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Products SET Name=@Name, Price=@Price, Quantity=@Quantity, ImagePath=@ImagePath, CategoryId=@CategoryId WHERE Barcode=@Barcode";

            cmd.Parameters.AddWithValue("@Barcode", product.Barcode);
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.Parameters.AddWithValue("@Quantity", product.QuantityInStock);
            cmd.Parameters.AddWithValue("@ImagePath", product.ImagePath);
            cmd.Parameters.AddWithValue("@CategoryId", product.CategoryId);

            cmd.ExecuteNonQuery();
        }
        public void Delete(int barcode)
        {
            using var conn = new SqliteConnection(_connString);
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Products WHERE Barcode=@Barcode";
            cmd.Parameters.AddWithValue("@Barcode", barcode);
            cmd.ExecuteNonQuery();
        }


    }
}
