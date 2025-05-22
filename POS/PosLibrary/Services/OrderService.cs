using Microsoft.Data.Sqlite;
using PosLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosLibrary.Services
{
    public class OrderService
    {
        private readonly string _connString = DatabaseConfig.ConnectionString;
        public OrderService(string connString) {
            _connString = connString;
        }
        public decimal CalculateOrderTotal(IEnumerable<OrderItem> items)
        {
            decimal sum = 0;
            foreach (var item in items) { 
                sum += item.Total;
            }
            return sum;
        }

        public void ReduceQuantity(string productName, int amount)
        {
            using var conn = new SqliteConnection(_connString);
            conn.Open();


            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Quantity FROM Products WHERE Name=@Name";
            cmd.Parameters.AddWithValue("@Name", productName);
            var currentQuantity = Convert.ToInt32(cmd.ExecuteScalar());

            if (currentQuantity >= amount)
            {
                using var updateCmd = conn.CreateCommand();
                updateCmd.CommandText = "UPDATE Products SET Quantity = Quantity - @Amount WHERE Name = @Name";
                updateCmd.Parameters.AddWithValue("@Amount", amount);
                updateCmd.Parameters.AddWithValue("@Name", productName);
                updateCmd.ExecuteNonQuery();
            }

            cmd.ExecuteNonQuery();
        }

        public decimal CalculateChange(decimal totalAmount, decimal amountPaid)
        {
            return amountPaid - totalAmount;
        }
    }
}
