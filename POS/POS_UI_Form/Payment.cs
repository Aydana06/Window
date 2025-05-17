using PosLibrary.Model;
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
using Microsoft.Data.Sqlite;

namespace POS_UI_Form
{
    public partial class Payment : Form
    {
        private static string DbPath = @"C:\Users\Lenovo\Documents\3th_COURSE\04_Windows\PosLibrary\Database.db";
        private static string ConnectionString = $"Data Source = {DbPath}";
        public double totalPrice { get; set; }
        private List<Order> orders;
        public Payment(double totalAmount, List<Order> orderList)
        {
            InitializeComponent();
            totalPrice = totalAmount;
            txtTotalPrice.Text = totalAmount.ToString();
            orders = orderList;
        }

        private void label2_Click(object sender, EventArgs e)
        { }
        //Үндсэн форм руу буцаана
        private void btnBack_Click(object sender, EventArgs e)
        {
            totalPrice = 0;
            this.Close();
        }

        public void ReduceQuantity(String productName, int amount)
        {
            using (var conn = new SqliteConnection(ConnectionString))
            {
                conn.Open();
                string query = "UPDATE Products SET Quantity = Quantity - @amount WHERE Name= @Name AND Quantity >= @amount";

                using (var cmd = new SqliteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@Name", productName);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //Баталгаажуулах буюу printForm гарч ирнэ
        private void btnValidate_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtPaid.Text, out double amountPaid)
                && double.TryParse(txtChange.Text, out double change))
            {
                PrintOrder printer = new PrintOrder(orders, amountPaid, change, totalPrice);
                printer.printReceipt();

                foreach (var order in orders)
                {
                    ReduceQuantity(order.ProductName, order.Quantity);
                }

                MessageBox.Show("Зарагдсан барааны мэдээлэл хадгалагдлаа.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Төлсөн дүн буруу байна!");
            }
        }

        private void btnCash_Click(object sender, EventArgs e)
        { }

        private void textBox1_TextChanged(object sender, EventArgs e)
        { }

        private void textBox2_TextChanged(object sender, EventArgs e)
        { }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTotalPrice.Clear();
        }

        //Change мөнгө тоцоолох
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtTotalPrice.Text, out int amountToPay) &&
                int.TryParse(txtPaid.Text, out int amountPaid))
            {
                int change = amountPaid - amountToPay;
                txtChange.Text = change >= 0 ? change.ToString("0.00") : "0.00";
            }
            else
            {
                MessageBox.Show("Invalid input values.");
            }
        }

        private void NumericButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            txtPaid.Text += btn.Text;
        }
        private void btn1_Click(object sender, EventArgs e)
        { }

        private void Payment_Load(object sender, EventArgs e)
        { }

        private void button1_Click(object sender, EventArgs e)
        {
            string amountPaid = txtPaid.Text;
            txtPaid.Text = amountPaid.Substring(0, amountPaid.Length - 1);
        }

        private void txtChange_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
