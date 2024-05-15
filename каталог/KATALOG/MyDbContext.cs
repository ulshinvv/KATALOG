using KATALOG.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KATALOG
{
    class MyDbContext : DbContext
    {
       
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }

        public string connectionString = @"Data Source=DBSRV\VIP2022; Initial Catalog=Trade_completed; Integrated Security=True;";
        //public MyDbContext() : base(@"Data Source=IVAN\MSSQLSERVER2;Initial Catalog=озон;Integrated Security=True")
        //{
        //}
    }
}
