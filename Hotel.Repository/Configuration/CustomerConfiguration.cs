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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            //productın bir kategorisi olabilir kategorinin ise birden fazla product olabilir.foreign key de bu şekilde verilebilir
            builder.HasOne(x => x.Room).WithMany(x => x.Customers).HasForeignKey(x => x.RoomId);
            builder.Property(x => x.Payment).IsRequired().HasColumnType("decimal(18,2)"); //para değeri toplamda 18 karakter virgülden sonra da 2 karakter olabilir.
        }
    }
}