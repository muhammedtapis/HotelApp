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
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.RoomNo).IsRequired().HasMaxLength(200);

            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)"); //para değeri toplamda 18 karakter virgülden sonra da 2 karakter olabilir.
            builder.ToTable("Rooms");

            //roomın bir kategorisi olabilir floorun ise birden fazla room olabilir.foreign key de bu şekilde verilebilir
            builder.HasOne(x => x.Floor).WithMany(x => x.Rooms).HasForeignKey(x => x.FloorId);
        }
    }
}