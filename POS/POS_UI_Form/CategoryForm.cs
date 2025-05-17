using Microsoft.Data.Sqlite;
using PosLibrary;
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
    public partial class CategoryForm : Form
    {
        private static string DbPath = @"C:\Users\Lenovo\Documents\3th_COURSE\04_Windows\PosLibrary\Database.db";
        private static string ConnectionString = $"Data Source = {DbPath}";

        public CategoryForm()
        {
            InitializeComponent();
            LoadCategories();
        }

        private void LoadCategories()
        {
            var table = new DataTable();

            using (var conn = new SqliteConnection(ConnectionString))
            {
                conn.Open();
                var cmd = new SqliteCommand("SELECT * FROM Categories", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    table.Load(reader);
                }
            }

            dataGridView1.DataSource = table;

            if (dataGridView1.Columns.Contains("CategoryId"))
            {
                dataGridView1.Columns["CategoryId"].Visible = true;
            }

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {}

        private void CategoryForm_Load(object sender, EventArgs e)
        {}
        private void btnCategoryAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Please enter a category name.");
                return;
            }

            using (var conn = new SqliteConnection(ConnectionString))
            {
                conn.Open();
                var cmd = new SqliteCommand("INSERT INTO Categories (CategoryName) VALUES (@CategoryName)", conn);
                cmd.Parameters.AddWithValue("@CategoryName", txtCategoryName.Text.Trim());

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Category added.");
                    LoadCategories();
                    txtCategoryName.Clear();
                }
                catch (SqliteException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Select a category and enter new name.");
                return;
            }

            var selectedId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["CategoryId"].Value);

            using (var conn = new SqliteConnection(ConnectionString))
            {
                conn.Open();
                var cmd = new SqliteCommand("UPDATE Categories SET CategoryName = @CategoryName WHERE CategoryId = @CategoryId", conn);
                cmd.Parameters.AddWithValue("@CategoryName", txtCategoryName.Text.Trim());
                cmd.Parameters.AddWithValue("@CategoryId", selectedId);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Category updated.");
                LoadCategories();
                txtCategoryName.Clear();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Select a category to delete.");
                return;
            }

            var selectedId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["CategoryId"].Value);

            var result = MessageBox.Show("Are you sure to delete this category?", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (var conn = new SqliteConnection(ConnectionString))
                {
                    conn.Open();
                    var cmd = new SqliteCommand("DELETE FROM Categories WHERE CategoryId = @CategoryId", conn);
                    cmd.Parameters.AddWithValue("@CategoryId", selectedId);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Category deleted.");
                LoadCategories();
                txtCategoryName.Clear();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {}

        private void dataGridViewCategories_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                txtCategoryName.Text = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
            }
        }
    }
}
