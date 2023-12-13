using Hotel.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Repository.Configuration
{
    public class HostelConfiguration : IEntityTypeConfiguration<Hostel>
    {
        public void Configure(EntityTypeBuilder<Hostel> builder)
        {
            builder.HasKey(x => x.Id); //istersek böyle tanımlayabiliriz
            builder.Property(x => x.Id).UseIdentityColumn(); //identity sütunu yaptık.
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50); //isim alanı zorunlu ve max 50 karakter.
        }
    }
}