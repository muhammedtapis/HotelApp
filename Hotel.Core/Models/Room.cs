using Hotel.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Models
{
    public class Room : BaseEntity
    {
        public int RoomNo { get; set; }
        public bool IsAvailable { get; set; }

        public decimal Price { get; set; } //tek yataklı odaların  fiyatı var ama çok yataklı odaların direkt fiyatı yok onları yatak uzeründen hesaplıcan.

        //navigation prop.

        //bire çok ilişki katlar ile ama burada alt sınıf room
        public int FloorId { get; set; }

        public Floor Floor { get; set; }

        //bire çok iliişki bed ile burada alt sınıf bed
        public ICollection<Bed> Beds { get; set; }

        //bire çok ilişki alt sınıf customer

        public ICollection<Customer> Customers { get; set; }
    }
}