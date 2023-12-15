using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.DTOs
{
    public class CustomerUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        //public DateTime CheckInDate { get; set; } check in gelmesin değiştirilmesin.
        public DateTime CheckOutDate { get; set; }

        public decimal Payment { get; set; }
        public bool IsPayed { get; set; }
        public int RoomId { get; set; }
    }
}