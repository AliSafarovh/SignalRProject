﻿
namespace WebUI.DTOs.BookingDtos
{
    public class CreateBookingDto 
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string PersonCount { get; set; }
        public DateTime Date { get; set; }
    }
}
