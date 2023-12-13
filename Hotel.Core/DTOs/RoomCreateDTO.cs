using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.DTOs
{
    public class RoomCreateDTO
    {
        public int RoomNo { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }
        public int FloorId { get; set; }
    }
}