//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DistManagment
{
    using System;
    using System.Collections.Generic;
    
    public partial class products
    {
        public products()
        {
            this.isStock = true;
            this.order_product = new HashSet<order_product>();
        }
    
        public int id { get; set; }
        public string product_name { get; set; }
        public Nullable<int> stock { get; set; }
        public bool isStock { get; set; }
        public string barcode { get; set; }
        public string upc { get; set; }
        public string weight { get; set; }
        public string type { get; set; }
    
        public virtual ICollection<order_product> order_product { get; set; }
    }
}
