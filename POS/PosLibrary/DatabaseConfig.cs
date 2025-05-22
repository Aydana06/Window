using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosLibrary
{
    public static class DatabaseConfig
    {
        public static string DatabaseFilePath = @"C:\Users\Lenovo\Documents\3th_COURSE\04_Windows\PosLibrary\Database.db";
        public static string ConnectionString => $"Data Source={DatabaseFilePath}";
    }
}
