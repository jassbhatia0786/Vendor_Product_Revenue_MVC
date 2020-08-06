using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vendor_Product_Revenue_MVC.Models
{//Store front information
    public class StoreFront
    {
        //Store front Id
        public int Id { get; set; }

        //Name of the online store
        public string StoreFrontName { get; set; }

        //Online store url
        public string StoreFrontUrl { get; set; }

    }
}
