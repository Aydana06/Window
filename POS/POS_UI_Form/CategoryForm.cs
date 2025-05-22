using Microsoft.Data.Sqlite;
using PosLibrary;
using PosLibrary.Services;
using PosLibrary.Repo;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PosLibrary.Model;

namespace POS_UI_Form
{
    public partial class CategoryForm : Form
    {
        private string _connString = DatabaseConfig.ConnectionString;
        private readonly CategoryService _categoryService;
        public CategoryForm()
        {
            InitializeComponent();

            var repo = new CategoryRepository(_connString);
            _categoryService = new CategoryService(repo);
            LoadCategories();
        }

        private void LoadCategories()
        {
           var categories = _categoryService.GetCategories();
           dataGridView1.DataSource = categories.ToList();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {}

        private void CategoryForm_Load(object sender, EventArgs e)
        {}
        private void btnCategoryAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _categoryService.AddCategory(txtCategoryName.Text);
                MessageBox.Show("Category added.");
                LoadCategories();
                txtCategoryName.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }   

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Select a category to edit");
                return;
            }

            var selectedCategory = (Category)dataGridView1.CurrentRow.DataBoundItem;
            var selectedId = selectedCategory.Id;

            try
            {
                _categoryService.UpdateCategory(selectedId, txtCategoryName.Text);
                MessageBox.Show("Category updated.");
                LoadCategories();
                txtCategoryName.Clear();
            }
            catch (Exception ex){
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Select a category to delete.");
                return;
            }

            var selectedCategory = (Category)dataGridView1.CurrentRow.DataBoundItem;
            var selectedId = selectedCategory.Id;

            var result = MessageBox.Show("Are you sure to delete this category?", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    _categoryService.DeleteCategory(selectedId);
                    MessageBox.Show("Category deleted.");
                    LoadCategories();
                    txtCategoryName.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
               
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {}

        private void dataGridViewCategories_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow != null)
            {
                txtCategoryName.Text = dataGridView1.CurrentRow.Cells["CategoryName"].Value.ToString();
            }
        }
    }
}
