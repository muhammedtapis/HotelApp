using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Models
{
    public class Bed : BaseEntity
    {
        public int BedNumber { get; set; }

        public decimal BedPrice { get; set; } //fiyatlar yatak bazlı olcak

        //navigation prop
        public int RoomId { get; set; }

        public Room Room { get; set; }
    }
}