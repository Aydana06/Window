using Microsoft.Data.Sqlite;
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
using PosLibrary.Model;

using PosLibrary.Services;
using PosLibrary.Repo;

namespace POS_UI_Form
{
    public partial class Products : Form
    {
        private string connString = DatabaseConfig.ConnectionString;
        private readonly ProductService _service;

        public Products()
        {
            InitializeComponent();
       
            var repo = new ProductRepository(connString);
            _service = new ProductService(repo);
            LoadProducts();
        }

        private void LoadProducts()
        {
            var products = _service.GetAllProducts();
            dataGridView1.DataSource = products.ToList();

            if (dataGridView1.Columns.Contains("Id"))
            {
                dataGridView1.Columns["Id"].Visible = false;
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { }
    }
}
