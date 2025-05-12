namespace POS_UI_Form
{
    partial class ManageProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtName = new TextBox();
            txtBarcode = new TextBox();
            label2 = new Label();
            txtPrice = new TextBox();
            label3 = new Label();
            txtImagePath = new TextBox();
            label4 = new Label();
            txtCategoryID = new TextBox();
            label5 = new Label();
            txtQuantity = new TextBox();
            label6 = new Label();
            btnSave = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(73, 62);
            label1.Name = "label1";
            label1.Size = new Size(68, 25);
            label1.TabIndex = 0;
            label1.Text = "Name";
            label1.Click += label1_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(73, 90);
            txtName.Name = "txtName";
            txtName.Size = new Size(125, 30);
            txtName.TabIndex = 1;
            // 
            // txtBarcode
            // 
            txtBarcode.Location = new Point(73, 163);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(125, 30);
            txtBarcode.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(73, 135);
            label2.Name = "label2";
            label2.Size = new Size(92, 25);
            label2.TabIndex = 2;
            label2.Text = "Barcode";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(73, 231);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(125, 30);
            txtPrice.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(73, 203);
            label3.Name = "label3";
            label3.Size = new Size(61, 25);
            label3.TabIndex = 4;
            label3.Text = "Price";
            label3.Click += label3_Click;
            // 
            // txtImagePath
            // 
            txtImagePath.Location = new Point(73, 304);
            txtImagePath.Name = "txtImagePath";
            txtImagePath.Size = new Size(125, 30);
            txtImagePath.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(73, 276);
            label4.Name = "label4";
            label4.Size = new Size(114, 25);
            label4.TabIndex = 6;
            label4.Text = "imagePath";
            // 
            // txtCategoryID
            // 
            txtCategoryID.Location = new Point(73, 379);
            txtCategoryID.Name = "txtCategoryID";
            txtCategoryID.Size = new Size(125, 30);
            txtCategoryID.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(73, 351);
            label5.Name = "label5";
            label5.Size = new Size(121, 25);
            label5.TabIndex = 8;
            label5.Text = "CategoryID";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(73, 452);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(125, 30);
            txtQuantity.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(73, 424);
            label6.Name = "label6";
            label6.Size = new Size(93, 25);
            label6.TabIndex = 10;
            label6.Text = "Quantity";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(303, 231);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(122, 48);
            btnSave.TabIndex = 12;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // ManageProduct
            // 
            AutoScaleDimensions = new SizeF(13F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(506, 562);
            Controls.Add(btnSave);
            Controls.Add(txtQuantity);
            Controls.Add(label6);
            Controls.Add(txtCategoryID);
            Controls.Add(label5);
            Controls.Add(txtImagePath);
            Controls.Add(label4);
            Controls.Add(txtPrice);
            Controls.Add(label3);
            Controls.Add(txtBarcode);
            Controls.Add(label2);
            Controls.Add(txtName);
            Controls.Add(label1);
            Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(5, 4, 5, 4);
            Name = "ManageProduct";
            Text = "ManageProduct";
            Load += ManageProduct_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtName;
        private TextBox txtBarcode;
        private Label label2;
        private TextBox txtPrice;
        private Label label3;
        private TextBox txtImagePath;
        private Label label4;
        private TextBox txtCategoryID;
        private Label label5;
        private TextBox txtQuantity;
        private Label label6;
        private Button btnSave;
    }
}