using UserControlLibrary;
using PosLibrary.Model;
using PosLibrary;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;
using System.Net.NetworkInformation;
using Microsoft.Data.Sqlite;
using System.Data;
using System.Windows.Forms;

namespace POS_UI_Form
{
    public partial class MyPOS : Form
    {
        private static string DbPath = @"C:\Users\Lenovo\Documents\3th_COURSE\04_Windows\PosLibrary\Database.db";
        private static string ConnectionString = $"Data Source = {DbPath}";
        private string? userRole;
        public int barcode;
        double totalAmount;
        List<Order> orders = new List<Order>();

        private void UpdateTotalAmount()
        {
            totalAmount = 0;
            foreach (OrderItem item in flowLayoutPanel2.Controls.OfType<OrderItem>())
            {
                totalAmount += item.Price * item.Quantity;
            }

            lblTotalPrice.Text = $"{totalAmount}₮";
        }

        private void LoadOrdersFromUI()
        {
            orders.Clear();
            foreach (var orderItem in flowLayoutPanel2.Controls.OfType<OrderItem>())
            {
                orders.Add(new Order
                {
                    ProductName = orderItem.ItemName,
                    Price = orderItem.Price,
                    Quantity = orderItem.Quantity,
                });
            }
        }
        public MyPOS(string role)
        {
            InitializeComponent();
            userRole = role;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        { }

        //Нийт дүнийг тооцоолох
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

            LoadCategory();
            btnProfile.Text = userRole;
        }

        //CategoryBtn
        void LoadCategory()
        {
            flowLayoutPanelCategory.Controls.Clear();
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT DISTINCT * FROM Categories WHERE CategoryId IS NOT NULL";
                using (SqliteCommand cmd = new SqliteCommand(query, connection))
                using (SqliteDataReader reader = cmd.ExecuteReader())
                {
                    int y = 20;
                    while (reader.Read())
                    {
                        string? category = reader["CategoryId"].ToString();
                        string? categoryName = reader["CategoryName"].ToString();
                        Button btn = new Button();
                        btn.Text = $"{categoryName}";
                        btn.Width = 180;
                        btn.Height = 100;
                        btn.Top = y;
                        btn.Left = 20;
                        btn.Click += (s, e) => showCategoryProducts(Convert.ToInt32(category));
                        flowLayoutPanelCategory.Controls.Add(btn);
                        y += 50;
                    }
                }
            }
        }
        //CategoryBtn дээр дарахад гарах products
        void showCategoryProducts(int categoryId)
        {
            flowLayoutPanelProducts.Controls.Clear();
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Products WHERE CategoryId=@CategoryId";
                using (SqliteCommand cmd = new SqliteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        flowLayoutPanelCategory.AutoScroll = true;
                        int y = 10;
                        while (reader.Read())
                        {
                            string productName = reader["Name"].ToString();
                            string imagePath = reader["ImagePath"].ToString();
                            int barcode = Convert.ToInt32(reader["Barcode"]);
                            decimal price = Convert.ToDecimal(reader["Price"]);

                            //products deer darahad hiigdeh uildel
                            void panelClickHandler(object sender, EventArgs e)
                            {
                                AddOrderItemByProductName(productName);
                                txtProductCode.Text = barcode.ToString();
                                UpdateTotalAmount();
                            }

                            Panel panel = new Panel
                            {
                                Width = 135,
                                Height = 180,
                                Top = y,
                                Left = 10,
                                BorderStyle = BorderStyle.FixedSingle,
                                Cursor = Cursors.Hand
                            };

                            PictureBox pictureBox = new PictureBox
                            {
                                Width = 115,
                                Height = 100,
                                Top = 5,
                                Left = 10,
                                SizeMode = PictureBoxSizeMode.Zoom
                            };

                            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                            {
                                try
                                {
                                    if (File.Exists(imagePath))
                                    {
                                        using (var img = Image.FromFile(imagePath))
                                        {
                                            pictureBox.Image = new Bitmap(img);
                                        }
                                    }
                                }
                                catch (OutOfMemoryException ex)
                                {
                                    MessageBox.Show($"Зураг ачаалж чадсангүй: {imagePath}\n{ex.Message}");
                                }
                            }

                            Label nameLabel = new Label
                            {
                                Text = productName,
                                Top = 110,
                                Left = 5,
                                Width = 125,
                                Height = 25,
                                TextAlign = ContentAlignment.MiddleCenter
                            };

                            Label priceLabel = new Label
                            {
                                Text = $"{price:0.00}₮",
                                Top = 135,
                                Left = 5,
                                Width = 125,
                                Height = 20,
                                ForeColor = Color.Green,
                                Font = new Font("Arial", 9, FontStyle.Bold),
                                TextAlign = ContentAlignment.MiddleCenter
                            };

                            panel.Controls.Add(pictureBox);
                            panel.Controls.Add(nameLabel);
                            panel.Controls.Add(priceLabel);

                            panel.Click += panelClickHandler;
                            nameLabel.Click += panelClickHandler;
                            pictureBox.Click += panelClickHandler;
                            priceLabel.Click += panelClickHandler;
                            flowLayoutPanelProducts.Controls.Add(panel);
                            y += 190;
                        }

                    }
                }
            }
        }

        //OrderItem-үүдийг нэмэх

        void AddOrderItemByProductName(string? productName)
        {
            if (string.IsNullOrWhiteSpace(productName)) return;

            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Products WHERE Name=@Name";
                using (var cmd = new SqliteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", productName);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            flowLayoutPanel2.AutoScroll = true;
                            string name = reader["Name"].ToString()!;
                            double price = Convert.ToDouble(reader["Price"]);

                            // Хэрэв өмнө нь Panel-д байгаа бол тоог нэмэгдүүл
                            var existingItem = flowLayoutPanel2.Controls
                                .OfType<OrderItem>()
                                .FirstOrDefault(item => item.ItemName == name);

                            if (existingItem != null)
                            {
                                existingItem.Quantity++;
                                UpdateTotalAmount();

                            }
                            else
                            {
                                // Шинээр OrderItem үүсгээд panel рүү нэмэх
                                var orderItem = new OrderItem
                                {
                                    ItemName = name,
                                    Price = price,
                                    Quantity = 1,
                                    Width = flowLayoutPanel2.Width - 20,
                                    Dock = DockStyle.None,
                                };

                                orderItem.QuantityChanged += (sender, args) => UpdateTotalAmount();

                                flowLayoutPanel2.Controls.Add(orderItem);
                                flowLayoutPanel2.Controls.SetChildIndex(orderItem, 0); // Шинэ хамгийн дээр гарна
                                orders.Add(new Order
                                {
                                    ProductName = name,
                                    Price = price,
                                    Quantity = 1
                                });
                            }
                        }
                    }
                }
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



            using (var connection = new SqliteConnection(ConnectionString))
            {
                flowLayoutPanelProducts.AutoScroll = true;
                flowLayoutPanelProducts.FlowDirection = FlowDirection.LeftToRight;
                flowLayoutPanelProducts.WrapContents = true;

                connection.Open();
                string query = "SELECT * FROM Products WHERE Barcode=@Barcode";
                using (SqliteCommand cmd = new SqliteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Barcode", barcode);
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        int y = 10;
                        while (reader.Read())
                        {
                            string productName = reader["Name"].ToString();
                            string imagePath = reader["ImagePath"].ToString();
                            decimal price = Convert.ToDecimal(reader["Price"]);

                            void panelClickHandler(object sender, EventArgs e)
                            {
                                AddOrderItemByProductName(productName);
                            }

                            Panel panel = new Panel
                            {
                                Width = 135,
                                Height = 180,
                                BorderStyle = BorderStyle.FixedSingle,
                                Cursor = Cursors.Hand
                            };

                            PictureBox pictureBox = new PictureBox
                            {
                                Width = 115,
                                Height = 100,
                                Top = 5,
                                Left = 10,
                                SizeMode = PictureBoxSizeMode.Zoom
                            };

                            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                            {
                                pictureBox.Image = Image.FromFile(imagePath);
                            }

                            Label nameLabel = new Label
                            {
                                Text = productName,
                                Top = 110,
                                Left = 5,
                                Width = 125,
                                Height = 25,
                                TextAlign = ContentAlignment.MiddleCenter
                            };

                            Label priceLabel = new Label
                            {
                                Text = $"{price:0.00}₮",
                                Top = 135,
                                Left = 5,
                                Width = 125,
                                Height = 20,
                                ForeColor = Color.Green,
                                Font = new Font("Arial", 9, FontStyle.Bold),
                                TextAlign = ContentAlignment.MiddleCenter
                            };

                            panel.Controls.Add(pictureBox);
                            panel.Controls.Add(nameLabel);
                            panel.Controls.Add(priceLabel);

                            panel.Click += panelClickHandler;
                            nameLabel.Click += panelClickHandler;
                            pictureBox.Click += panelClickHandler;
                            priceLabel.Click += panelClickHandler;
                            flowLayoutPanelProducts.Controls.Add(panel);
                            y += 190;
                        }

                        if (flowLayoutPanelProducts.Controls.Count == 0)
                        {
                            MessageBox.Show("Ийм кодтой бараа олдсонгүй.");
                        }
                    }
                }
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
            Product product = GetProductByBarcode(barcode);
            if (product != null)
            {
                ManageProduct form = new("Edit", barcode);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Бараа олдсонгүй.");
                return;
            }
        }

        //Barcode-аар products авах
        private Product GetProductByBarcode(int barcode)
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Products WHERE Barcode=@Barcode";

                using (var cmd = new SqliteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Barcode", barcode);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Product
                            {
                                Price = Convert.ToInt32(reader["Price"]),
                                Name = (reader["Name"].ToString()),
                                Barcode = Convert.ToInt32(reader["Barcode"]),
                                Quantity = Convert.ToInt32(reader["Quantity"]),
                                ImagePath = reader["ImagePath"].ToString(),
                                CategoryId = Convert.ToInt32(reader["CategoryId"])
                            };
                        }
                    }
                }
            }
            return null;
        }

        //Шинээр бараа нэмэх
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ManageProduct form = new ManageProduct("Add");
            form.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalPrice_Click(object sender, EventArgs e)
        {

        }

        private void categoryBtn_Click(object sender, EventArgs e)
        {
            CategoryForm categoryForm = new CategoryForm();
            categoryForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.Controls.Clear();
        }
    }
}
