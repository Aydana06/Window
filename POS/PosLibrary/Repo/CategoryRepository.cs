using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PosLibrary.Model;
using Microsoft.Data.Sqlite;

namespace PosLibrary.Repo
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly string _connectionString;
        public CategoryRepository(string connectionString){
            _connectionString = connectionString;
        }

        public IEnumerable<Category> GetAll()
        {
            var categories = new List<Category>();

            using var conn = new SqliteConnection(_connectionString);
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Categories";

            using var reader = cmd.ExecuteReader();
                    
            while (reader.Read()) {
                categories.Add(new Category
                {
                    Id = Convert.ToInt32(reader["CategoryId"]),
                    Name = reader["CategoryName"].ToString()
                });
            }
            return categories;
        }

        public Category GetById(int id)
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Categories WHERE CategoryId = @CategoryId";
            cmd.Parameters.AddWithValue("CategoryId", id);
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) {
                return new Category
                {
                    Id = Convert.ToInt32(reader["CategoryId"]),
                    Name = reader["CategoryName"].ToString()
                };
            }
            return null;
        }

        public void Add(Category category)
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Categories (CategoryName) VALUES (@CategoryName)";
            cmd.Parameters.AddWithValue("@CategoryName", category.Name);

            cmd.ExecuteNonQuery();
        }

        public void Update(Category category)
        {
            using var conn = new SqliteConnection(_connectionString); 
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Categories SET CategoryName=@CategoryName WHERE CategoryId=@CategoryId";
            cmd.Parameters.AddWithValue("@CategoryName", category.Name);
            cmd.Parameters.AddWithValue("@CategoryId", category.Id);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id) {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Categories WHERE CategoryId = @CategoryId";
            cmd.Parameters.AddWithValue("@CategoryId", id);
            cmd.ExecuteNonQuery();
        } 
    }
}
