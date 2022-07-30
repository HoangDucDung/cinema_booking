using System;
using System.Collections.Generic;

#nullable disable

namespace WinFormsApp2.Model
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public string Image { get; set; }
        public int? Rate { get; set; }
    }
}
