namespace UserControlLibrary
{
    partial class OrderItemControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnDecrease = new Button();
            btnIncrease = new Button();
            lblItemName = new Label();
            lblQty = new Label();
            lblAmount = new Label();
            lblPrice = new Label();
            SuspendLayout();
            // 
            // btnDecrease
            // 
            btnDecrease.Location = new Point(374, 13);
            btnDecrease.Margin = new Padding(6, 4, 6, 4);
            btnDecrease.Name = "btnDecrease";
            btnDecrease.Size = new Size(46, 29);
            btnDecrease.TabIndex = 0;
            btnDecrease.Text = "-";
            btnDecrease.UseVisualStyleBackColor = true;
            btnDecrease.Click += btnDecrease_Click;
            // 
            // btnIncrease
            // 
            btnIncrease.Location = new Point(274, 13);
            btnIncrease.Margin = new Padding(6, 4, 6, 4);
            btnIncrease.Name = "btnIncrease";
            btnIncrease.Size = new Size(49, 29);
            btnIncrease.TabIndex = 1;
            btnIncrease.Text = "+";
            btnIncrease.UseVisualStyleBackColor = true;
            btnIncrease.Click += btnIncrease_Click;
            // 
            // lblItemName
            // 
            lblItemName.AutoSize = true;
            lblItemName.Location = new Point(6, 13);
            lblItemName.Margin = new Padding(6, 0, 6, 0);
            lblItemName.Name = "lblItemName";
            lblItemName.Size = new Size(132, 29);
            lblItemName.TabIndex = 3;
            lblItemName.Text = "ItemName";
            lblItemName.Click += lblItemName_Click;
            // 
            // lblQty
            // 
            lblQty.AutoSize = true;
            lblQty.Location = new Point(335, 13);
            lblQty.Margin = new Padding(6, 0, 6, 0);
            lblQty.Name = "lblQty";
            lblQty.Size = new Size(27, 29);
            lblQty.TabIndex = 4;
            lblQty.Text = "0";
            lblQty.Click += lblQty_Click;
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Location = new Point(444, 13);
            lblAmount.Margin = new Padding(6, 0, 6, 0);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(73, 29);
            lblAmount.TabIndex = 5;
            lblAmount.Text = "Total";
            lblAmount.Click += lblAmount_Click;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(171, 13);
            lblPrice.Margin = new Padding(6, 0, 6, 0);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(74, 29);
            lblPrice.TabIndex = 6;
            lblPrice.Text = "Price";
            lblPrice.Click += lblPrice_Click;
            // 
            // OrderItem
            // 
            AutoScaleDimensions = new SizeF(15F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblPrice);
            Controls.Add(lblAmount);
            Controls.Add(lblQty);
            Controls.Add(lblItemName);
            Controls.Add(btnIncrease);
            Controls.Add(btnDecrease);
            Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(6, 4, 6, 4);
            Name = "OrderItem";
            Size = new Size(577, 60);
            Load += OrderItem_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDecrease;
        private Button btnIncrease;
        private Label lblItemName;
        private Label lblQty;
        private Label lblAmount;
        private Label lblPrice;
    }
}
