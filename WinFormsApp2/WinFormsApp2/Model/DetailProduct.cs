using System;
using System.Collections.Generic;

#nullable disable

namespace WinFormsApp2.Model
{
    public partial class DetailProduct
    {
        public int? ProductId { get; set; }
        public int? CategoryId { get; set; }
        public string Detail { get; set; }

        public virtual Category Category { get; set; }
        public virtual Product Product { get; set; }
    }
}
