using Microsoft.Data.Sqlite;
using PosLibrary.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_UI_Form
{
    public partial class Login : Form
    {
        private static string DbPath = @"C:\Users\Lenovo\Documents\3th_COURSE\04_Windows\PosLibrary\Database.db";
        private static string ConnectionString = $"Data Source = {DbPath}";
        public Login()
        {
            InitializeComponent();
            string folder = Path.GetDirectoryName(DbPath);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            CreateDatabaseIfNotExists();
        }

        private void CreateDatabaseIfNotExists()
        {
            if (!File.Exists(DbPath))
            {
                using (var connection = new SqliteConnection(ConnectionString))
                {
                    connection.Open();

                    var cmd = connection.CreateCommand();
                    cmd.CommandText =
                    @"
                    CREATE TABLE IF NOT EXISTS Products (
                        Barcode INTEGER,
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

                    MessageBox.Show("Success.");
                }
            }
            else
            {
                MessageBox.Show("Already exist.");
            }
        }
        private void Login_Load(object sender, EventArgs e)
        { }

        private void radialButton1_Load(object sender, EventArgs e)
        { }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT Role FROM Users WHERE Username = $u AND Password = $p";
                cmd.Parameters.AddWithValue("$u", username);
                cmd.Parameters.AddWithValue("$p", password);

                var role = cmd.ExecuteScalar()?.ToString();

                if (role != null)
                {
                    Program.LoggedInUser = new User { Username = username, Role = role };
                    Hide();

                    MyPOS main = new MyPOS(role);
                    main.Show();
                }
                else
                {
                    MessageBox.Show("Invalid login");
                }
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        { }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        { }
    }
}
