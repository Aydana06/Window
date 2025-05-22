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
using PosLibrary.Services;
using PosLibrary.Repo;

namespace POS_UI_Form
{
    public partial class Payment : Form
    {
        public decimal _totalPrice { get; set; }
        private List<OrderItem> _orders;
        private readonly OrderService _service;
        private string _connString = DatabaseConfig.ConnectionString;
        public Payment(decimal totalAmount, List<OrderItem> orderList)
        {
            InitializeComponent();
            _totalPrice = totalAmount;
            txtTotalPrice.Text = totalAmount.ToString();
            _orders = orderList;

            _service = new OrderService(_connString);
        }

        private void label2_Click(object sender, EventArgs e)
        { }
        //Үндсэн форм руу буцаана
        private void btnBack_Click(object sender, EventArgs e)
        {
            _totalPrice = 0;
            this.Close();
        }


        //Баталгаажуулах буюу printForm гарч ирнэ
        private void btnValidate_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtPaid.Text, out decimal amountPaid))
            {
                PrintOrder printer = new PrintOrder(_orders, amountPaid, _totalPrice);
                printer.printReceipt();

                foreach (var order in _orders)
                {
                    _service.ReduceQuantity(order.ProductName, order.Quantity);
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
            if (decimal.TryParse(txtPaid.Text, out decimal amountPaid))
            {
                decimal change = _service.CalculateChange(_totalPrice, amountPaid);
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
