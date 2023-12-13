using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Models
{
    public class AppUser : IdentityUser
    {
        //kullanıcı ilk üye olduğunda bu bilgileri istemiycez iye olduktan sonra userEdit sayfasından güncelleyebilcek.
        public string PassportNo { get; set; }

        public string City { get; set; }
        public string Picture { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }  //genderi oluşturduğumuz gender enum tipine verdik.
    }
}