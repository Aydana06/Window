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
    public partial class Products : Form
    {
        private static string DbPath = @"C:\Users\Lenovo\Documents\3th_COURSE\04_Windows\PosLibrary\Database.db";
        private static string ConnectionString = $"Data Source = {DbPath}";
        public Products()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts()
        {
            var table = new DataTable();

            using (var conn = new SqliteConnection(ConnectionString))
            {
                conn.Open();
                var cmd = new SqliteCommand("SELECT * FROM Products", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    table.Load(reader);
                }
            }

            dataGridView1.DataSource = table;

            if (dataGridView1.Columns.Contains("Id"))
            {
                dataGridView1.Columns["Id"].Visible = false;
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { }
    }
}
