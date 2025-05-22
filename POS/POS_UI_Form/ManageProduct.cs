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
using SQLitePCL;
using PosLibrary.Repo;
using PosLibrary.Services;

namespace POS_UI_Form
{
    public partial class ManageProduct : Form

    {
        private readonly string mode;
        private readonly int? _barcode;
        private string _connString = DatabaseConfig.ConnectionString;
        private readonly ProductService _service;
        public ManageProduct(string mode, int? barcode = null)
        {
            InitializeComponent();
            this.mode = mode;
            this._barcode = barcode;
            var repo = new ProductRepository(_connString);
            _service = new ProductService(repo);

            Load += ManageProduct_Load;
        }

        private void label1_Click(object sender, EventArgs e)
        { }

        private void label3_Click(object sender, EventArgs e)
        { }

        private void button2_Click(object sender, EventArgs e)
        { }

        private void btnUpdate_Click(object sender, EventArgs e)
        { }

        private void btnDelete_Click(object sender, EventArgs e)
        { }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var product = new Product
            {
                Barcode = int.Parse(txtBarcode.Text),
                Name = txtName.Text,
                Price = decimal.Parse(txtPrice.Text),
                QuantityInStock = int.Parse(txtQuantity.Text),
                ImagePath = txtImagePath.Text,
                CategoryId = int.Parse(txtCategoryID.Text),
            };
            if (mode == "Add")
            {
                try
                {
                    _service.AddProduct(product);
                    MessageBox.Show("Бүтээгдэхүүн амжилттай нэмэгдлээ.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Алдаа: {ex.Message}");
                }
            }
            else if (mode == "Update")
            {
                _service.UpdateProduct(product);      
            }
            else if (mode == "Delete")
            {
                _service.DeleteProduct(product.Barcode);
            }

            DialogResult = DialogResult.OK;
        }


        private void ManageProduct_Load(object sender, EventArgs e)
        {
            Text = mode + " Product";

            if (mode == "Update" || mode == "Delete")
            {
                LoadProduct((int)_barcode);
            }
        }

        private void LoadProduct(int barcode)
        {
            var product = _service.GetProductByBarcode(barcode);
            txtName.Text = product.Name;
            txtPrice.Text = product.Price.ToString();
            txtCategoryID.Text = product.CategoryId.ToString();
            txtImagePath.Text = product.ImagePath.ToString();
            txtQuantity.Text = product.QuantityInStock.ToString();
            txtBarcode.Text = product.Barcode.ToString();
            if (mode == "Delete")
            {
                txtName.ReadOnly = true;
                txtPrice.ReadOnly = true;
                txtImagePath.ReadOnly = true;
                txtQuantity.ReadOnly = true;
                txtBarcode.ReadOnly = true;
                txtCategoryID.ReadOnly = true;

                btnSave.Text = "Delete";
            }
            if (mode == "Update") btnSave.Text = "Update";
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        { }
    }
}
