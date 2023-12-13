using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Service.Exceptions
{
    public class ClientSideException : Exception
    {
        //constructorda burdaki exception mesajını base sınıfta exceptiona gönderiyoruz asıl işi Exception sınıfı yapıyor
        //biz burada custom sınf oluşturup oraya yönlendirme yapıyoruz
        public ClientSideException(string exceptionMessage) : base(exceptionMessage)
        {
        }
    }
}