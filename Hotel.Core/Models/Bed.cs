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

        //navigation prop
        public int RoomId { get; set; }

        public Room Room { get; set; }
    }
}