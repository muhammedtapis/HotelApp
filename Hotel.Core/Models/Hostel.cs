using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Models
{
    public class Hostel : BaseEntity
    {
        public string Name { get; set; }
        public string Location { get; set; }

        //navigation prop.
        public ICollection<Floor> Floors { get; set; } = new List<Floor>();
    }
}