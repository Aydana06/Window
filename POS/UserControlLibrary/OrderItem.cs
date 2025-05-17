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

namespace UserControlLibrary
{
    public partial class OrderItem : UserControl
    {
        private int quantity;
        private double price;
        public event EventHandler QuantityChanged;
        public double total => quantity * price;


        public string ItemName
        {
            get => lblItemName.Text;
            set => lblItemName.Text = value;
        }

        public double Price
        {
            get => price;
            set
            {
                price = value;
                lblPrice.Text = price.ToString();
                UpdateAmount();
            }
        }


        public int Quantity
        {
            get => quantity;
            set
            {
                quantity = Math.Max(1, value);
                lblQty.Text = quantity.ToString();
                UpdateAmount();
            }
        }
        public OrderItem()
        {
            InitializeComponent();
        }

        private void OrderItem_Load(object sender, EventArgs e)
        {}

        private void UpdateAmount()
        {
            lblAmount.Text = total.ToString();
        }

        private void btnIncrease_Click(object sender, EventArgs e)
        {
            Quantity++;
            QuantityChanged?.Invoke(this, EventArgs.Empty);
        }

        private void btnDecrease_Click(object sender, EventArgs e)
        {
            if (Quantity > 1)
            {
                Quantity--;
                QuantityChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private void lblQty_Click(object sender, EventArgs e)
        {  }

        private void lblAmount_Click(object sender, EventArgs e)
        { }

        private void lblPrice_Click(object sender, EventArgs e)
        { }

        private void lblItemName_Click(object sender, EventArgs e)
        { }

        private void button1_Click(object sender, EventArgs e)
        {}
    }
}
