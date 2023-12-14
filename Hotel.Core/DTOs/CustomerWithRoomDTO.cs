using Hotel.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.DTOs
{
    public class CustomerWithRoomDTO : CustomerDTO
    {
        //aşağıda Room yerine başka bir isim verirsen ef core anlayamaz onu bulamıyor null geliyor Sınıfın adı neyse onu ver.
        //eğer özel isim vermek istiyosan MapProfile sayfasında ForMember() metoduyla belirt !!!!!!
        public RoomDTO Room { get; set; }
    }
}