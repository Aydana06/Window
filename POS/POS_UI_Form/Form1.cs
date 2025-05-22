using UserControlLibrary;
using PosLibrary.Model;
using PosLibrary;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;
using System.Net.NetworkInformation;
using Microsoft.Data.Sqlite;
using System.Data;
using System.Windows.Forms;
using PosLibrary.Services;
using PosLibrary.Repo;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace POS_UI_Form
{
    public partial class MyPOS : Form
    {
        private string? userRole;
        public int barcode;
        decimal totalAmount;
        private readonly CategoryService _categoryService;
        private readonly ProductService _productService;

        List<PosLibrary.Model.OrderItem> orders = new List<PosLibrary.Model.OrderItem>();

        private void UpdateTotalAmount()
        {
            totalAmount = 0;
            foreach (OrderItemControl item in flowLayoutPanel2.Controls.OfType<OrderItemControl>())
            {
                totalAmount += item.Total;
            }
            lblTotalPrice.Text = $"{totalAmount}₮";
        }

        private void LoadOrdersFromUI()
        {
            orders.Clear();
            foreach (var orderItemControl in flowLayoutPanel2.Controls.OfType<OrderItemControl>())
            {
                orders.Add(new PosLibrary.Model.OrderItem
                {
                    ProductName = orderItemControl.ItemName,
                    Price = orderItemControl.Price,
                    Quantity = orderItemControl.Quantity
                });
            }
        }
        public MyPOS(string role, CategoryService categoryService, ProductService productService)
        {
            InitializeComponent();
            _categoryService = categoryService;
            userRole = role;
            _productService = productService;
            LoadCategoryButtons();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        { }

        //Төлбөр төлөх 
        private void button1_Click(object sender, EventArgs e)
        {
            LoadOrdersFromUI();
            Payment form = new Payment(totalAmount, orders);
            form.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        { }

        private void textBox1_TextChanged(object sender, EventArgs e)
        { }

        private void label2_Click(object sender, EventArgs e)
        { }

        private void label3_Click(object sender, EventArgs e)
        { }

        private void label3_Click_1(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString("M/d/yyyy h:mm tt");
        }

        private void orderItem1_Load(object sender, EventArgs e)
        { }

        private void flowLayoutPanel5_Paint(object sender, PaintEventArgs e)
        { }

        private void label8_Click(object sender, EventArgs e)
        { }

        private void textBox2_TextChanged(object sender, EventArgs e)
        { }

        private void productBtn_Click(object sender, EventArgs e)
        { }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        { }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        { }

        private void Timer_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString("M/d/yyyy h:mm tt");
        }
        private void MyPOS_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
            if (userRole == "Manager")
            {
                productBtn.Enabled = true;
                categoryBtn.Enabled = true;
                helpBtn.Enabled = true;

                btnAdd.Visible = true;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
            }
            else
            {
                productBtn.Enabled = true;
                categoryBtn.Visible = false;
                helpBtn.Enabled = true;

                btnAdd.Visible = false;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;

            }

            LoadCategoryButtons();
            btnProfile.Text = userRole;
        }

        //CategoryBtn
        void LoadCategoryButtons()
        {
            flowLayoutPanelCategory.Controls.Clear();
            int y = 20;
            var categories = _categoryService.GetCategories();
            foreach (var c in categories)
            {
                var btn = new Button
                {
                    Text = c.Name,
                    Width = 180,
                    Height = 100,
                    Top = y,
                    Left = 20,
                    Tag = c.Id
                };

                btn.Click += (s, e) => showCategoryProducts(Convert.ToInt32(((Button)s).Tag));
                flowLayoutPanelCategory.Controls.Add(btn);
                y += 50;
            }
        }

        //CategoryBtn дээр дарахад гарах products
        void showCategoryProducts(int categoryId)
        {
            flowLayoutPanelProducts.Controls.Clear();
            flowLayoutPanelProducts.AutoScroll = true;
            var products = _productService.GetProductsByCategory(categoryId);
            foreach (var product in products)
            {
                var panel = CreateProductPanel(product);
                flowLayoutPanelProducts.Controls.Add(panel);
            }
        }

        private Panel CreateProductPanel(Product product)
        {
            int y = 10;
            var panel = new Panel
            {
                Width = 135,
                Height = 180,
                Top = y,
                Left = 10,
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand,
            };

            var pictureBox = new PictureBox
            {
                Width = 115,
                Height = 100,
                Top = 5,
                Left = 10,
                SizeMode = PictureBoxSizeMode.Zoom,
            };
            if (!string.IsNullOrEmpty(product.ImagePath) && File.Exists(product.ImagePath)) {
                try
                {
                    using var img = Image.FromFile(product.ImagePath);
                    pictureBox.Image = new Bitmap(img);
                }
                catch (OutOfMemoryException ex)
                {
                    MessageBox.Show("Зураг ачаалж чадсангүй: {product.ImagePath}\n{ex.Message}");
                }
            }

            var nameLabel = new Label
            {
                Text = product.Name,
                Top = 110,
                Left = 5,
                Width = 125,
                Height = 25,
                TextAlign = ContentAlignment.MiddleCenter,

            };

            var priceLabel = new Label
            {
                Text = $"{product.Price:0.00}",
                Top = 135,
                Left = 5,
                Width = 125,
                Height = 20,
                ForeColor = Color.Green,
                Font = new Font("Arial", 9, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
            };

            panel.Controls.Add(pictureBox);
            panel.Controls.Add(nameLabel);
            panel.Controls.Add(priceLabel);

            void panelClickHandler(object sender, EventArgs e)
            {
                AddOrderItemByProductName(product.Name);
                txtProductCode.Text = product.Barcode.ToString();
                UpdateTotalAmount();
            };
            panel.Click += panelClickHandler;
            nameLabel.Click += panelClickHandler;
            pictureBox.Click += panelClickHandler;
            priceLabel.Click += panelClickHandler;
            return panel;
        }
        //OrderItem-үүдийг нэмэх

        void AddOrderItemByProductName(string? name)
        {
            if (string.IsNullOrWhiteSpace(name)) return;
            var product = _productService.GetProductByName(name);

            // Хэрэв өмнө нь Panel-д байгаа бол тоог нэмэгдүүл
            var existingItem = flowLayoutPanel2.Controls
                                    .OfType<OrderItemControl>()
                                    .FirstOrDefault(item => item.ItemName == name);

            if (existingItem != null)
            {
                existingItem.Quantity++;
                UpdateTotalAmount();
            }
            else
            {
                // Шинээр OrderItem үүсгээд panel рүү нэмэх
                var orderItem = new OrderItemControl
                {
                    ItemName = name,
                    Price = product.Price,
                    Quantity = 1,
                    Width = flowLayoutPanel2.Width - 20,
                    Dock = DockStyle.None,
                };

                orderItem.QuantityChanged += (sender, args) => UpdateTotalAmount();

                flowLayoutPanel2.Controls.Add(orderItem);
                flowLayoutPanel2.Controls.SetChildIndex(orderItem, 0);
                orders.Add(new PosLibrary.Model.OrderItem
                {
                    ProductName = name,
                    Price = product.Price,
                    Quantity = 1
                });
            }
        }

        private void btnProfile_Click(object sender, EventArgs e)
        { }

        private void button7_Click(object sender, EventArgs e)
        { }

        private void flowLayoutPanelCategory_Paint(object sender, PaintEventArgs e)
        { }

        private void productBtn_Click_1(object sender, EventArgs e)
        {
            Products productForm = new Products();
            productForm.ShowDialog();

        }

        //SearchBtn дарахад хийгдэх үйлдэл
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtProductCode.Text, out barcode))
            {
                MessageBox.Show("Барааны код оруулна уу.");
                return;
            }
            barcode = int.Parse(txtProductCode.Text);
            LoadByBarcodeToPanel(barcode);
        }


        //Barcode-аар хайж products харуулах
        private void LoadByBarcodeToPanel(int barcode)
        {
            flowLayoutPanelProducts.Controls.Clear();
            flowLayoutPanelProducts.AutoScroll = true;
            flowLayoutPanelProducts.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanelProducts.WrapContents = true;
            var product = _productService.GetProductByBarcode(barcode);

            void panelClickHandler(object sender, EventArgs e)
            {
                AddOrderItemByProductName(product.Name);
            }

            var panel = CreateProductPanel(product);
            flowLayoutPanelProducts.Controls.Add(panel);


            if (flowLayoutPanelProducts.Controls.Count == 0)
            {
                MessageBox.Show("Ийм кодтой бараа олдсонгүй.");
            }
        }

        //Delete цонх гарч ирнэ
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductCode.Text))
            {
                MessageBox.Show("Барааны код оруулна уу.");
                return;
            }
            barcode = int.Parse(txtProductCode.Text);
            ManageProduct form = new ManageProduct("Delete", barcode);
            form.ShowDialog();
        }

        //Update цонх гарч ирнэ
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductCode.Text))
            {
                MessageBox.Show("Барааны код оруулна уу.");
                return;
            }

            barcode = int.Parse(txtProductCode.Text);
            var product = _productService.GetProductByBarcode(barcode);
            if (product != null)
            {
                ManageProduct form = new("Update", barcode);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Бараа олдсонгүй.");
                return;
            }
        }

        //Шинээр бараа нэмэх
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ManageProduct form = new ManageProduct("Add");
            form.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {}

        private void lblTotalPrice_Click(object sender, EventArgs e)
        { }

        private void categoryBtn_Click(object sender, EventArgs e)
        {
            CategoryForm categoryForm = new CategoryForm();
            categoryForm.ShowDialog();
            LoadCategoryButtons();
        }

        private void button2_Click(object sender, EventArgs e)
        { 
            var result = MessageBox.Show("Та бүх барааг цэвэрлэхдээ итгэлтэй байна уу?",
                                "Баталгаажуулалт", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                flowLayoutPanel2.Controls.Clear();
                lblTotalPrice.Text = "";
            }

        }
    }
}
