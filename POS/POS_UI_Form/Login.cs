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
using PosLibrary;
using PosLibrary.Repo;
using PosLibrary.Services;
namespace POS_UI_Form
{
    public partial class Login : Form
    {
        private readonly UserService _userService;
        private readonly CategoryService _categoryService;
        private readonly ProductService _productService;
        private readonly CreateDatabase _database;
        string _connString = DatabaseConfig.ConnectionString;
        string _dbPath = DatabaseConfig.DatabaseFilePath;
        public Login()
        {
            InitializeComponent();

            var userRepo = new UserRepository(_connString);
            _userService = new UserService(userRepo);

            var categoryRepo = new CategoryRepository(_connString);
            _categoryService = new CategoryService(categoryRepo);

            var productRepo = new ProductRepository(_connString);
            _productService = new ProductService(productRepo);

            _database = new CreateDatabase(_connString, _dbPath);
            _database.InitializeDatabase();

        }

        private void Login_Load(object sender, EventArgs e)
        { }

        private void radialButton1_Load(object sender, EventArgs e)
        { }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

           var user = _userService.Authenticate(username, password);
            if (user != null) { 
                Program.LoggedInUser = user;
                Hide();
                
                var mainForm = new MyPOS(user.Role, _categoryService, _productService);
                mainForm.Show();

            }
            else
            {
                MessageBox.Show("Invalid Login");
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        { }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        { }
    }
}
