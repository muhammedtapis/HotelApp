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
    public class BedConfiguration : IEntityTypeConfiguration<Bed>
    {
        public void Configure(EntityTypeBuilder<Bed> builder)
        {
            builder.Property(x => x.BedPrice).IsRequired().HasColumnType("decimal(18,2)"); //para değeri toplamda 18 karakter virgülden sonra da 2 karakter olabilir.
                                                                                           //productın bir kategorisi olabilir kategorinin ise birden fazla product olabilir.foreign key de bu şekilde verilebilir
            builder.HasOne(x => x.Room).WithMany(x => x.Beds).HasForeignKey(x => x.RoomId);
        }
    }
}