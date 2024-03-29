﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Models
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string PassportNo { get; set; }
        public string Address { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public decimal Payment { get; set; }
        public bool IsPayed { get; set; }

        //navigation prop. payment ile bire bir ilişki payment alt sınıf.
        //public Payment Payment { get; set; }

        public Room Room { get; set; } //room ile bire çok ilişki room üst sınıf.
        public int RoomId { get; set; }
    }
}