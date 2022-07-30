using System;
using System.Collections.Generic;

#nullable disable

namespace WinFormsApp2.Model
{
    public partial class Order
    {
        public Order()
        {
            Orderdetails = new HashSet<Orderdetail>();
        }

        public int OrderId { get; set; }
        public int? AccId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime Orderdate { get; set; }
        public DateTime ShippedDate { get; set; }

        public virtual Account Acc { get; set; }
        public virtual ICollection<Orderdetail> Orderdetails { get; set; }
    }
}
