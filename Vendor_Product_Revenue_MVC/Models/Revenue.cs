using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vendor_Product_Revenue_MVC.Models
{ //Product Revenue 
    public class Revenue
    {

        //Product revenue id 
        public int Id { get; set; }

        //Product related id
        public int ProductId { get; set; }

        //Product link 
        public Product Product { get; set; }

        //Storefront related id
        public int StoreFrontId { get; set; }

        //Store front link
        public StoreFront StoreFront { get; set; }

        //Revenue quantity

        public int Quantity { get; set; }


        //Product total income
        public decimal TotalIncome
        {
            get
            {

                return this.Product.UnitPrice * Quantity;


            }
        }


    }
}
