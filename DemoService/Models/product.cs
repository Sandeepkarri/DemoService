//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoService.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class product
    {
        public int product_id { get; set; }
        public string product_name { get; set; }
        public int Freshness_id { get; set; }
        public int category_id { get; set; }
        public int Files_id { get; set; }
        public string Additional_Des { get; set; }
        public string Comments { get; set; }
        public decimal Price { get; set; }

        [JsonIgnore]
        public virtual Category Category { get; set; }
        [JsonIgnore]
        public virtual File File { get; set; }
        [JsonIgnore]
        public virtual Freshness Freshness { get; set; }
    }
}
