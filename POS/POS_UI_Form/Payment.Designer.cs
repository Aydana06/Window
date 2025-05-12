namespace POS_UI_Form
{
    partial class Payment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Payment));
            btnCash = new Button();
            btnCard = new Button();
            lbl1 = new Label();
            btnBack = new Button();
            btnPrint = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btn1 = new Button();
            btn2 = new Button();
            btn3 = new Button();
            btn4 = new Button();
            btn5 = new Button();
            btn6 = new Button();
            btn7 = new Button();
            btn8 = new Button();
            btn9 = new Button();
            button12 = new Button();
            btn0 = new Button();
            btnZero = new Button();
            btnClear = new Button();
            txtTotalPrice = new TextBox();
            txtPaid = new TextBox();
            label1 = new Label();
            txtChange = new TextBox();
            label2 = new Label();
            label3 = new Label();
            btnConfirm = new Button();
            button1 = new Button();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnCash
            // 
            btnCash.Location = new Point(12, 297);
            btnCash.Name = "btnCash";
            btnCash.Size = new Size(160, 60);
            btnCash.TabIndex = 0;
            btnCash.Text = "Cash";
            btnCash.UseVisualStyleBackColor = true;
            btnCash.Click += btnCash_Click;
            // 
            // btnCard
            // 
            btnCard.Location = new Point(12, 231);
            btnCard.Name = "btnCard";
            btnCard.Size = new Size(160, 60);
            btnCard.TabIndex = 1;
            btnCard.Text = "Card";
            btnCard.UseVisualStyleBackColor = true;
            // 
            // lbl1
            // 
            lbl1.AutoSize = true;
            lbl1.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            lbl1.Location = new Point(263, 16);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(113, 29);
            lbl1.TabIndex = 2;
            lbl1.Text = "Payment";
            // 
            // btnBack
            // 
            btnBack.Location = new Point(12, 12);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(129, 43);
            btnBack.TabIndex = 3;
            btnBack.Text = "<<  Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(510, 12);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(129, 43);
            btnPrint.TabIndex = 4;
            btnPrint.Text = "Validate  >>";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnValidate_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btn1);
            flowLayoutPanel1.Controls.Add(btn2);
            flowLayoutPanel1.Controls.Add(btn3);
            flowLayoutPanel1.Controls.Add(btn4);
            flowLayoutPanel1.Controls.Add(btn5);
            flowLayoutPanel1.Controls.Add(btn6);
            flowLayoutPanel1.Controls.Add(btn7);
            flowLayoutPanel1.Controls.Add(btn8);
            flowLayoutPanel1.Controls.Add(btn9);
            flowLayoutPanel1.Controls.Add(button12);
            flowLayoutPanel1.Controls.Add(btn0);
            flowLayoutPanel1.Controls.Add(btnZero);
            flowLayoutPanel1.Location = new Point(226, 178);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(183, 243);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // btn1
            // 
            btn1.Location = new Point(3, 3);
            btn1.Name = "btn1";
            btn1.Size = new Size(55, 55);
            btn1.TabIndex = 0;
            btn1.Text = "1";
            btn1.UseVisualStyleBackColor = true;
            btn1.Click += NumericButton_Click;
            // 
            // btn2
            // 
            btn2.Location = new Point(64, 3);
            btn2.Name = "btn2";
            btn2.Size = new Size(55, 55);
            btn2.TabIndex = 1;
            btn2.Text = "2";
            btn2.UseVisualStyleBackColor = true;
            btn2.Click += NumericButton_Click;
            // 
            // btn3
            // 
            btn3.Location = new Point(125, 3);
            btn3.Name = "btn3";
            btn3.Size = new Size(55, 55);
            btn3.TabIndex = 2;
            btn3.Text = "3";
            btn3.UseVisualStyleBackColor = true;
            btn3.Click += NumericButton_Click;
            // 
            // btn4
            // 
            btn4.Location = new Point(3, 64);
            btn4.Name = "btn4";
            btn4.Size = new Size(55, 55);
            btn4.TabIndex = 4;
            btn4.Text = "4";
            btn4.UseVisualStyleBackColor = true;
            btn4.Click += NumericButton_Click;
            // 
            // btn5
            // 
            btn5.Location = new Point(64, 64);
            btn5.Name = "btn5";
            btn5.Size = new Size(55, 55);
            btn5.TabIndex = 5;
            btn5.Text = "5";
            btn5.UseVisualStyleBackColor = true;
            btn5.Click += NumericButton_Click;
            // 
            // btn6
            // 
            btn6.Location = new Point(125, 64);
            btn6.Name = "btn6";
            btn6.Size = new Size(55, 55);
            btn6.TabIndex = 6;
            btn6.Text = "6";
            btn6.UseVisualStyleBackColor = true;
            btn6.Click += NumericButton_Click;
            // 
            // btn7
            // 
            btn7.Location = new Point(3, 125);
            btn7.Name = "btn7";
            btn7.Size = new Size(55, 55);
            btn7.TabIndex = 8;
            btn7.Text = "7";
            btn7.UseVisualStyleBackColor = true;
            btn7.Click += NumericButton_Click;
            // 
            // btn8
            // 
            btn8.Location = new Point(64, 125);
            btn8.Name = "btn8";
            btn8.Size = new Size(55, 55);
            btn8.TabIndex = 9;
            btn8.Text = "8";
            btn8.UseVisualStyleBackColor = true;
            btn8.Click += NumericButton_Click;
            // 
            // btn9
            // 
            btn9.Location = new Point(125, 125);
            btn9.Name = "btn9";
            btn9.Size = new Size(55, 55);
            btn9.TabIndex = 10;
            btn9.Text = "9";
            btn9.UseVisualStyleBackColor = true;
            btn9.Click += NumericButton_Click;
            // 
            // button12
            // 
            button12.Location = new Point(3, 186);
            button12.Name = "button12";
            button12.Size = new Size(55, 55);
            button12.TabIndex = 11;
            button12.Text = ".";
            button12.UseVisualStyleBackColor = true;
            button12.Click += NumericButton_Click;
            // 
            // btn0
            // 
            btn0.Location = new Point(64, 186);
            btn0.Name = "btn0";
            btn0.Size = new Size(55, 55);
            btn0.TabIndex = 13;
            btn0.Text = "0";
            btn0.UseVisualStyleBackColor = true;
            btn0.Click += NumericButton_Click;
            // 
            // btnZero
            // 
            btnZero.Location = new Point(125, 186);
            btnZero.Name = "btnZero";
            btnZero.Size = new Size(55, 55);
            btnZero.TabIndex = 7;
            btnZero.Text = "00";
            btnZero.UseVisualStyleBackColor = true;
            btnZero.Click += NumericButton_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(89, 138);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(83, 37);
            btnClear.TabIndex = 3;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // txtTotalPrice
            // 
            txtTotalPrice.Location = new Point(12, 98);
            txtTotalPrice.Multiline = true;
            txtTotalPrice.Name = "txtTotalPrice";
            txtTotalPrice.Size = new Size(160, 34);
            txtTotalPrice.TabIndex = 6;
            txtTotalPrice.TextChanged += textBox1_TextChanged;
            // 
            // txtPaid
            // 
            txtPaid.Location = new Point(226, 98);
            txtPaid.Multiline = true;
            txtPaid.Name = "txtPaid";
            txtPaid.Size = new Size(183, 34);
            txtPaid.TabIndex = 7;
            txtPaid.TextChanged += textBox2_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 75);
            label1.Name = "label1";
            label1.Size = new Size(116, 20);
            label1.TabIndex = 8;
            label1.Text = "Amount to pay";
            // 
            // txtChange
            // 
            txtChange.Location = new Point(458, 98);
            txtChange.Multiline = true;
            txtChange.Name = "txtChange";
            txtChange.Size = new Size(183, 34);
            txtChange.TabIndex = 9;
            txtChange.TextChanged += txtChange_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(226, 75);
            label2.Name = "label2";
            label2.Size = new Size(102, 20);
            label2.TabIndex = 10;
            label2.Text = "Amount paid";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(458, 75);
            label3.Name = "label3";
            label3.Size = new Size(66, 20);
            label3.TabIndex = 11;
            label3.Text = "Change";
            // 
            // btnConfirm
            // 
            btnConfirm.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirm.Location = new Point(558, 138);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(83, 37);
            btnConfirm.TabIndex = 12;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // button1
            // 
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.Location = new Point(412, 181);
            button1.Name = "button1";
            button1.Size = new Size(54, 55);
            button1.TabIndex = 13;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Payment
            // 
            AutoScaleDimensions = new SizeF(11F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(653, 437);
            Controls.Add(button1);
            Controls.Add(btnConfirm);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtChange);
            Controls.Add(label1);
            Controls.Add(txtPaid);
            Controls.Add(txtTotalPrice);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(btnPrint);
            Controls.Add(btnBack);
            Controls.Add(btnClear);
            Controls.Add(lbl1);
            Controls.Add(btnCard);
            Controls.Add(btnCash);
            Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            Name = "Payment";
            Text = "Payment";
            Load += Payment_Load;
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCash;
        private Button btnCard;
        private Label lbl1;
        private Button btnBack;
        private Button btnPrint;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btn1;
        private Button btn2;
        private Button btn3;
        private Button btnClear;
        private Button btn4;
        private Button btn5;
        private Button btn6;
        private Button btnZero;
        private Button btn7;
        private Button btn8;
        private Button btn9;
        private Button button12;
        private Button btn0;
        private TextBox txtTotalPrice;
        private TextBox txtPaid;
        private Label label1;
        private TextBox txtChange;
        private Label label2;
        private Label label3;
        private Button btnConfirm;
        private Button button1;
    }
}