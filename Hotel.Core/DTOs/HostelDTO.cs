using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.DTOs
{
    public class HostelDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Location { get; set; }
    }
}