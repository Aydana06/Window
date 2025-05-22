using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Printing;
using PosLibrary.Model;


namespace PosLibrary
{
    internal class PrintOrder
    {
        private List<OrderItem> ordersToPrint;
        Sales sale;

        public PrintOrder(List<OrderItem> ordersToPrint, decimal amountPaid, decimal totalPrice)
        {
            this.ordersToPrint = ordersToPrint;
            this.sale = new Sales();
            this.sale.AmountPaid = amountPaid;
            this.sale.TotalAmount = totalPrice;
        }

        public void printReceipt()
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += printDocument_PrintPage;

            using (PrintDialog printDialog = new PrintDialog())
            {
                printDialog.Document = printDocument;
                if(printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.PrinterSettings = printDialog.PrinterSettings;
                    printDocument.Print();
                }
            }
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font font = new Font("Arial", 12);
            Font boldFont = new Font("Arial", 12, FontStyle.Bold);

            float lineHeight = font.GetHeight();
            float x = 50;
            float y = 50;

            try
            {
                Image logo = Image.FromFile("logo.png");
                graphics.DrawImage(logo, 20, y, 200, 150);
                y += 110;
            }
            catch
            {
                graphics.DrawString("Logo not found", font, Brushes.Red, x, y);
                y += lineHeight;
            }

            y += lineHeight * 2;

            // Header
            graphics.DrawString("№", boldFont, Brushes.Black, x, y);
            graphics.DrawString("Product", boldFont, Brushes.Black, x + 40, y);
            graphics.DrawString("Qty", boldFont, Brushes.Black, x + 240, y);
            graphics.DrawString("Price", boldFont, Brushes.Black, x + 320, y);
            graphics.DrawString("Total", boldFont, Brushes.Black, x + 420, y);
            y += lineHeight + 5;

            graphics.DrawLine(Pens.Black, x, y, x + 500, y);
            y += 5;

            int index = 1;

            foreach (var order in ordersToPrint)
            {
                graphics.DrawString(index.ToString() + ".", font, Brushes.Black, x, y);
                graphics.DrawString(order.ProductName, font, Brushes.Black, x + 40, y);
                graphics.DrawString(order.Quantity.ToString(), font, Brushes.Black, x + 240, y);
                graphics.DrawString(order.Price.ToString("N0"), font, Brushes.Black, x + 320, y);
                graphics.DrawString(order.Total.ToString("N0"), font, Brushes.Black, x + 420, y);
                y += lineHeight;
                index++;
            }

            y += 10;
            graphics.DrawLine(Pens.Black, x, y, x + 500, y);
            y += lineHeight;

            graphics.DrawString("Amount to pay:", boldFont, Brushes.Black, x, y);
            graphics.DrawString(sale.TotalAmount.ToString("N0"), font, Brushes.Black, x + 320, y);
            y += lineHeight;

            graphics.DrawString("Amount paid:", boldFont, Brushes.Black, x + 40, y);
            graphics.DrawString(sale.AmountPaid.ToString("N0"), font, Brushes.Black, x + 320, y);
            y += lineHeight;

            graphics.DrawString("Change:", boldFont, Brushes.Black, x, y);
            graphics.DrawString(sale.Change.ToString("N0"), font, Brushes.Black, x + 320, y);
        }
    }
}
