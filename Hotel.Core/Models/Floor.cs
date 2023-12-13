using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Models
{
    public class Floor : BaseEntity
    {
        public string Name { get; set; }

        //navigation prop. Room ile bire çok ilişki room alt sınıf.
        public ICollection<Room> Rooms { get; set; } = new List<Room>();

        //hostel ile bire çok ilişki Hostel üst sınıf.
        public Hostel Hostel { get; set; }

        public int HostelId { get; set; }
    }
}