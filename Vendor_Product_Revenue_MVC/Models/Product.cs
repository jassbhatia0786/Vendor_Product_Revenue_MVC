using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vendor_Product_Revenue_MVC.Models
{
    //Product details
    public class Product
    {
        //Product id
        public int Id { get; set; }

        //Vendor  related id 
        public int VendorId { get; set; }

        //Vendor link
        public Vendor Vendor { get; set; }

        //Product unit price
        public decimal UnitPrice { get; set; }

        //product name 
        public string Name { get; set; }

    }
}