using Hotel.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.DTOs
{
    public class CustomerWithPaymentDTO : CustomerDTO
    {
        //aşağıda Payment yerine başka bir isim verirsen ef core anlayamaz onu bulamıyor null geliyor
        //biz PaymentDto ismini verdikten sonra MapProfile sayfasında özel olarak bu propertyleri belirttik IMapper için
        public PaymentDTO PaymentDto { get; set; }
    }
}