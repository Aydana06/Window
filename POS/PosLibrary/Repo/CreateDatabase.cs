using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosLibrary.Repo
{
    public class CreateDatabase
    {
        private readonly string _connString;

        private readonly string _dbPath;

        public CreateDatabase(string connString, string dbPath)
        {
            _connString = connString;
            _dbPath = dbPath;
        }
        public void InitializeDatabase()
        {
            string folder = Path.GetDirectoryName(_dbPath);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            if (!File.Exists(_dbPath))
            {
                using (var connection = new SqliteConnection(_connString))
                {
                    connection.Open();

                    var cmd = connection.CreateCommand();
                    cmd.CommandText =
                    @"
                    CREATE TABLE IF NOT EXISTS Products (
                        Barcode INTEGER NOT NULL UNIQUE,
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Price REAL NOT NULL,
                        ImagePath TEXT,
                        Quantity INTEGER NOT NULL,
                        CategoryId INTEGER
                    );
                    CREATE TABLE IF NOT EXISTS Users (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT NOT NULL,
                        Password TEXT NOT NULL,
                        Role TEXT NOT NULL  -- ""Manager"", ""Cashier""
                    );
                    INSERT INTO Users (Username, Password, Role) VALUES
                    ('manager', '0000', 'Manager'),
                    ('cashier1', '1111', 'Cashier'),
                    ('cashier2', '2222', 'Cashier');

                    CREATE TABLE IF NOT EXISTS Categories (
                        CategoryId INTEGER PRIMARY KEY AUTOINCREMENT,
                        CategoryName TEXT NOT NULL
                    );
                ";

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
