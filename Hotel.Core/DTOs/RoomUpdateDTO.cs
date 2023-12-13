using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.DTOs
{
    //update ve create dtolarda baseDTO dan kalıtım almıyosun burada id kendisi oluşacak ya da zaten bize gelecek.
    //diğer dtolarda listeleme yaptığın için baseDTO dan alabilirsin.
    public class RoomUpdateDTO
    {
        public int Id { get; set; }
        public int RoomNo { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }
        public int FloorId { get; set; }
    }
}