using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.DTOs
{
    public class FloorDTO : BaseDTO
    {
        public string Name { get; set; }
        public int HostelId { get; set; }
    }
}