using System;
using System.Collections.Generic;

#nullable disable

namespace WinFormsApp2.Model
{
    public partial class Account
    {
        public Account()
        {
            Orders = new HashSet<Order>();
        }

        public int AccId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool Admin { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
