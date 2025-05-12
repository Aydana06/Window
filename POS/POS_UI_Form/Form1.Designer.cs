namespace POS_UI_Form
{
    partial class MyPOS
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flowLayoutPanelProducts = new FlowLayoutPanel();
            txtProductCode = new TextBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            flowLayoutPanel5 = new FlowLayoutPanel();
            label7 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label8 = new Label();
            panel1 = new Panel();
            lblTotalPrice = new Label();
            label1 = new Label();
            button1 = new Button();
            productBtn = new Button();
            categoryBtn = new Button();
            helpBtn = new Button();
            label2 = new Label();
            label3 = new Label();
            btnProfile = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            flowLayoutPanelCategory = new FlowLayoutPanel();
            btnSearch = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            panel2 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            button2 = new Button();
            flowLayoutPanel5.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanelProducts
            // 
            flowLayoutPanelProducts.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            flowLayoutPanelProducts.ForeColor = SystemColors.InfoText;
            flowLayoutPanelProducts.Location = new Point(597, 202);
            flowLayoutPanelProducts.Margin = new Padding(3, 3, 30, 3);
            flowLayoutPanelProducts.Name = "flowLayoutPanelProducts";
            flowLayoutPanelProducts.Padding = new Padding(0, 3, 0, 3);
            flowLayoutPanelProducts.Size = new Size(572, 570);
            flowLayoutPanelProducts.TabIndex = 4;
            flowLayoutPanelProducts.Paint += flowLayoutPanel1_Paint;
            // 
            // txtProductCode
            // 
            txtProductCode.BackColor = SystemColors.ScrollBar;
            txtProductCode.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtProductCode.Location = new Point(597, 118);
            txtProductCode.Multiline = true;
            txtProductCode.Name = "txtProductCode";
            txtProductCode.Size = new Size(419, 35);
            txtProductCode.TabIndex = 4;
            txtProductCode.TextChanged += textBox1_TextChanged_1;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Location = new Point(3, 159);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(588, 449);
            flowLayoutPanel2.TabIndex = 5;
            flowLayoutPanel2.Paint += flowLayoutPanel2_Paint;
            // 
            // flowLayoutPanel5
            // 
            flowLayoutPanel5.BackColor = SystemColors.ScrollBar;
            flowLayoutPanel5.Controls.Add(label7);
            flowLayoutPanel5.Controls.Add(label4);
            flowLayoutPanel5.Controls.Add(label5);
            flowLayoutPanel5.Controls.Add(label6);
            flowLayoutPanel5.Controls.Add(label8);
            flowLayoutPanel5.Controls.Add(button2);
            flowLayoutPanel5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            flowLayoutPanel5.Location = new Point(3, 118);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            flowLayoutPanel5.Size = new Size(586, 35);
            flowLayoutPanel5.TabIndex = 1;
            flowLayoutPanel5.Paint += flowLayoutPanel5_Paint;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 0);
            label7.Name = "label7";
            label7.Size = new Size(18, 25);
            label7.TabIndex = 3;
            label7.Text = " ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(34, 10);
            label4.Margin = new Padding(10);
            label4.Name = "label4";
            label4.Size = new Size(115, 25);
            label4.TabIndex = 0;
            label4.Text = "Item Name";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(189, 10);
            label5.Margin = new Padding(30, 10, 10, 10);
            label5.Name = "label5";
            label5.Size = new Size(61, 25);
            label5.TabIndex = 1;
            label5.Text = "Price";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(310, 10);
            label6.Margin = new Padding(50, 10, 10, 10);
            label6.Name = "label6";
            label6.Size = new Size(93, 25);
            label6.TabIndex = 2;
            label6.Text = "Quantity";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(453, 10);
            label8.Margin = new Padding(40, 10, 10, 10);
            label8.Name = "label8";
            label8.Size = new Size(61, 25);
            label8.TabIndex = 4;
            label8.Text = "Total";
            label8.Click += label8_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblTotalPrice);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button1);
            panel1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            panel1.Location = new Point(3, 609);
            panel1.Name = "panel1";
            panel1.Size = new Size(588, 163);
            panel1.TabIndex = 6;
            // 
            // lblTotalPrice
            // 
            lblTotalPrice.AutoSize = true;
            lblTotalPrice.Location = new Point(351, 31);
            lblTotalPrice.Name = "lblTotalPrice";
            lblTotalPrice.Size = new Size(78, 36);
            lblTotalPrice.TabIndex = 2;
            lblTotalPrice.Text = "0.00";
            lblTotalPrice.Click += lblTotalPrice_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(168, 31);
            label1.Name = "label1";
            label1.Size = new Size(177, 36);
            label1.TabIndex = 1;
            label1.Text = "Total Price:";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(128, 255, 128);
            button1.ForeColor = Color.Snow;
            button1.Location = new Point(3, 92);
            button1.Name = "button1";
            button1.Size = new Size(583, 68);
            button1.TabIndex = 0;
            button1.Text = "Pay";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // productBtn
            // 
            productBtn.Location = new Point(192, 3);
            productBtn.Name = "productBtn";
            productBtn.Size = new Size(171, 37);
            productBtn.TabIndex = 1;
            productBtn.Text = "Product";
            productBtn.UseVisualStyleBackColor = true;
            productBtn.Click += productBtn_Click_1;
            // 
            // categoryBtn
            // 
            categoryBtn.Location = new Point(3, 3);
            categoryBtn.Name = "categoryBtn";
            categoryBtn.Size = new Size(183, 37);
            categoryBtn.TabIndex = 3;
            categoryBtn.Text = "Category";
            categoryBtn.UseVisualStyleBackColor = true;
            categoryBtn.Click += categoryBtn_Click;
            // 
            // helpBtn
            // 
            helpBtn.Location = new Point(369, 3);
            helpBtn.Name = "helpBtn";
            helpBtn.Size = new Size(165, 37);
            helpBtn.TabIndex = 2;
            helpBtn.Text = "Help";
            helpBtn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(20, 43);
            label2.Margin = new Padding(20, 0, 3, 0);
            label2.Name = "label2";
            label2.Padding = new Padding(0, 0, 50, 0);
            label2.Size = new Size(365, 38);
            label2.TabIndex = 0;
            label2.Text = "RETAIL SUPERMARKET";
            label2.TextAlign = ContentAlignment.TopCenter;
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(20, 81);
            label3.Margin = new Padding(20, 0, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(148, 23);
            label3.TabIndex = 1;
            label3.Text = "4/3/2025 4:54 PM";
            label3.Click += label3_Click_1;
            // 
            // btnProfile
            // 
            btnProfile.Location = new Point(1232, 3);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(123, 107);
            btnProfile.TabIndex = 5;
            btnProfile.Text = "Profile";
            btnProfile.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnProfile.UseVisualStyleBackColor = true;
            btnProfile.Click += btnProfile_Click;
            // 
            // flowLayoutPanelCategory
            // 
            flowLayoutPanelCategory.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            flowLayoutPanelCategory.Location = new Point(1174, 118);
            flowLayoutPanelCategory.Name = "flowLayoutPanelCategory";
            flowLayoutPanelCategory.Size = new Size(187, 654);
            flowLayoutPanelCategory.TabIndex = 7;
            flowLayoutPanelCategory.Paint += flowLayoutPanelCategory_Paint;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.Location = new Point(1020, 121);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(137, 75);
            btnSearch.TabIndex = 8;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(597, 159);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(135, 37);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.Location = new Point(738, 159);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(135, 37);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(879, 159);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(135, 37);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(flowLayoutPanel1);
            panel2.Controls.Add(btnProfile);
            panel2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            panel2.Location = new Point(3, 1);
            panel2.Name = "panel2";
            panel2.Size = new Size(1358, 114);
            panel2.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(categoryBtn);
            flowLayoutPanel1.Controls.Add(productBtn);
            flowLayoutPanel1.Controls.Add(helpBtn);
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.Location = new Point(0, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(554, 111);
            flowLayoutPanel1.TabIndex = 6;
            // 
            // button2
            // 
            button2.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(530, 4);
            button2.Margin = new Padding(6, 4, 6, 4);
            button2.Name = "button2";
            button2.Size = new Size(46, 29);
            button2.TabIndex = 11;
            button2.Text = "X";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // MyPOS
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1447, 839);
            Controls.Add(btnSearch);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(flowLayoutPanel5);
            Controls.Add(panel2);
            Controls.Add(txtProductCode);
            Controls.Add(panel1);
            Controls.Add(flowLayoutPanelCategory);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(flowLayoutPanelProducts);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "MyPOS";
            Text = "MyPOS";
            Load += MyPOS_Load;
            flowLayoutPanel5.ResumeLayout(false);
            flowLayoutPanel5.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private FlowLayoutPanel flowLayoutPanelProducts;
        private FlowLayoutPanel flowLayoutPanel2;
        private Panel panel1;
        private Button button1;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel5;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox txtProductCode;
        private Button productBtn;
        private Button categoryBtn;
        private Button helpBtn;
        private Label label2;
        private Label label3;
        private Button btnProfile;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label lblTotalPrice;
        private FlowLayoutPanel flowLayoutPanelCategory;
        private Button btnSearch;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Panel panel2;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button2;
    }
}
