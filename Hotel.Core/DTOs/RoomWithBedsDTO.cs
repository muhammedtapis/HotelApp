using Hotel.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.DTOs
{
    public class RoomWithBedsDTO : RoomDTO
    {
        public ICollection<Bed> Beds { get; set; }
    }
}