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

namespace POS_UI_Form
{
    public partial class ManageProduct : Form

    {
        private readonly string mode;
        private readonly int? barcode;

        private static string DbPath = @"C:\Users\Lenovo\Documents\3th_COURSE\04_Windows\PosLibrary\Database.db";
        private static string ConnectionString = $"Data Source = {DbPath}";
        public ManageProduct(string mode, int? barcode = null)
        {
            InitializeComponent();
            this.mode = mode;
            this.barcode = barcode;
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
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            if (mode == "Add")
            {
                string insertQuery = "INSERT INTO Products (Barcode, Name, Price, Quantity, ImagePath, CategoryId) VALUES (@Barcode, @Name, @Price, @Quantity, @ImagePath, @CategoryId)";
                using var cmd = new SqliteCommand(insertQuery, connection);
                cmd.Parameters.AddWithValue("@Barcode", int.Parse(txtBarcode.Text.Trim()));
                cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@Quantity", int.Parse(txtQuantity.Text.Trim()));
                cmd.Parameters.AddWithValue("@ImagePath", txtImagePath.Text.Trim());
                cmd.Parameters.AddWithValue("@CategoryId", int.Parse(txtCategoryID.Text.Trim()));
                cmd.Parameters.AddWithValue("@Price", decimal.Parse(txtPrice.Text.Trim()));
                cmd.ExecuteNonQuery();
            }
            else if (mode == "Edit")
            {
                string updateQuery = "UPDATE Products SET Name=@Name, Price=@Price, Quantity=@Quantity, ImagePath=@ImagePath, CategoryId=@CategoryId WHERE Barcode=@Barcode";
                using var cmd = new SqliteCommand(updateQuery, connection);
                cmd.Parameters.AddWithValue("@Barcode", barcode);
                cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@Quantity", int.Parse(txtQuantity.Text.Trim()));
                cmd.Parameters.AddWithValue("@ImagePath", txtImagePath.Text.Trim());
                cmd.Parameters.AddWithValue("@CategoryId", int.Parse(txtCategoryID.Text.Trim()));
                cmd.Parameters.AddWithValue("@Price", decimal.Parse(txtPrice.Text.Trim()));
                cmd.ExecuteNonQuery();
            }
            else if (mode == "Delete")
            {
                string deleteQuery = "DELETE FROM Products WHERE Barcode=@Barcode";
                using var cmd = new SqliteCommand(deleteQuery, connection);
                cmd.Parameters.AddWithValue("@Barcode", barcode);
                cmd.ExecuteNonQuery();
            }

            DialogResult = DialogResult.OK;
            Close();
        }


        private void ManageProduct_Load(object sender, EventArgs e)
        {
            Text = mode + " Product";

            if (mode == "Edit" || mode == "Delete")
            {
                LoadProduct((int)barcode);
            }
        }

        private void LoadProduct(int barcode)
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();
            string query = "SELECT * FROM Products WHERE Barcode=@Barcode";
            using var cmd = new SqliteCommand(query, connection);
            cmd.Parameters.AddWithValue("@Barcode", barcode);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtName.Text = reader["Name"].ToString();
                txtPrice.Text = reader["Price"].ToString();
                txtCategoryID.Text = reader["CategoryId"].ToString();
                txtImagePath.Text = reader["ImagePath"].ToString();
                txtQuantity.Text = reader["Quantity"].ToString();
                txtBarcode.Text = reader["Barcode"].ToString();
                if (mode == "Delete")
                {
                    // текст оруулахыг хориглох
                    txtName.ReadOnly = true;
                    txtPrice.ReadOnly = true;
                    txtImagePath.ReadOnly = true;
                    txtQuantity.ReadOnly = true;
                    txtBarcode.ReadOnly = true;
                    txtCategoryID.ReadOnly = true;

                    btnSave.Text = "Delete";
                }
                if (mode == "Edit") btnSave.Text = "Update";
            }
        }
    }
}
