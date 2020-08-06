using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vendor_Product_Revenue_MVC.Models;

namespace Vendor_Product_Revenue_MVC.Data
{
    public class Vendor_Product_Revenue_DBContext : DbContext
    {
        public Vendor_Product_Revenue_DBContext (DbContextOptions<Vendor_Product_Revenue_DBContext> options)
            : base(options)
        {
        }

        public DbSet<Vendor_Product_Revenue_MVC.Models.Product> Product { get; set; }

        public DbSet<Vendor_Product_Revenue_MVC.Models.Revenue> Revenue { get; set; }

        public DbSet<Vendor_Product_Revenue_MVC.Models.StoreFront> StoreFront { get; set; }

        public DbSet<Vendor_Product_Revenue_MVC.Models.Vendor> Vendor { get; set; }
    }
}
