using System;
using System.Collections.Generic;

#nullable disable

namespace WinFormsApp2.Model
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public int ShowId { get; set; }
        public string Name { get; set; }
        public string SeatStatus { get; set; }
        public decimal? Amount { get; set; }
    }
}
