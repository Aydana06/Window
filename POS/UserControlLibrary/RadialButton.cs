using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace UserControlLibrary
{
    public partial class RadialButton : UserControl
    {
        public delegate void MyRadialClick(object sender, RadialClickEventArgs e);
        public event MyRadialClick RadialClick;

        private bool isClicked = false;
        private bool isHover = false;
        private System.Timers.Timer timer;
        private Pen blackPen, redPen, myPen;

        public bool isPlus = true;
        //{ get; set; }
        public RadialButton()
        {
            InitializeComponent();
            blackPen = new Pen(Color.Black, 3);
            redPen = new Pen(Color.Red, 3);
            myPen = blackPen;

            timer = new System.Timers.Timer(100);
            timer.Elapsed += Timer_Elapsed;

            // Events
            this.MouseClick += RadialButton_MouseClick;
            this.Paint += RadialButton_Paint;
            this.MouseEnter += RadialButton_MouseEnter;
            this.MouseLeave += RadialButton_MouseLeave;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            isClicked = false;
            timer.Stop();
            this.Invalidate();
        }

        private void RadialButton_MouseClick(object sender, MouseEventArgs e)
        {
            float centerX = this.Width / 2;
            float centerY = this.Height / 2;
            float radius = this.Width / 2;

            float distance = (float)Math.Sqrt(Math.Pow(e.X - centerX, 2) + Math.Pow(e.Y - centerY, 2));

            if (distance <= radius)
            {
                isClicked = true;
                timer.Start();
                this.Invalidate();
                RadialClick?.Invoke(this, new RadialClickEventArgs(isPlus));
            }
        }

        private void RadialButton_MouseEnter(object sender, EventArgs e)
        {
            isHover = true;
            this.Invalidate();
        }

        private void RadialButton_MouseLeave(object sender, EventArgs e)
        {
            isHover = false;
            this.Invalidate();
        }

        private void RadialButton_Paint(object sender, PaintEventArgs e)
        {
            var gr = e.Graphics;
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Pen color logic
            if (isClicked)
                myPen = redPen;
            else if (isHover)
                myPen = new Pen(Color.Blue, 3); // Hover өнгө
            else
                myPen = blackPen;

            int margin = 3;

            // Shadow
            using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(50, Color.Black)))
            {
                gr.FillEllipse(shadowBrush, margin + 2, margin + 2, this.Width - margin * 2, this.Height - margin * 2);
            }

            // Circle background
            using (SolidBrush fillBrush = new SolidBrush(Color.White))
            {
                gr.FillEllipse(fillBrush, margin, margin, this.Width - margin * 2, this.Height - margin * 2);
            }

            // Circle outline
            gr.DrawEllipse(myPen, margin, margin, this.Width - margin * 2, this.Height - margin * 2);

            // Symbols
            int w = this.Width;
            int h = this.Height;

            // Minus sign
            gr.DrawLine(myPen, w / 4, h / 2, w * 3 / 4, h / 2);

            // Plus vertical if needed
            if (isPlus)
            {
                gr.DrawLine(myPen, w / 2, h / 4, w / 2, h * 3 / 4);
            }
        }

        private void RadialButton_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
