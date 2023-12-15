using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.DTOs
{
    //create ederken id giriş alanı gelmemesi gerekiyo kullanıcıya  bu sebeple BaseDTO dan kalıtım almadık.
    public class CustomerCreateDTO
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string PassportNo { get; set; }
        public string Address { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        //public decimal Payment { get; set; }
        public bool IsPayed { get; set; } = false;

        public int RoomId { get; set; }
    }
}