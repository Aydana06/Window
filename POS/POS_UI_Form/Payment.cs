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

namespace POS_UI_Form
{
    public partial class Payment : Form
    {
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

        //Баталгаажуулах буюу printForm гарч ирнэ
        private void btnValidate_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtPaid.Text, out double amountPaid) 
                && double.TryParse(txtChange.Text, out double change))
            {
                PrintOrder printer = new PrintOrder(orders, amountPaid, change, totalPrice);
                printer.printReceipt();
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
