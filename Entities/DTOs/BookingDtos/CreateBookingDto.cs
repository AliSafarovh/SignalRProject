using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.BookingDtos
{
    public class CreateBookingDto : IDto
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string PersonCount { get; set; }
        public DateTime Date { get; set; }
    }
}
