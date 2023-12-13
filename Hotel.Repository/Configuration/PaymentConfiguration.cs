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
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        //configurasyon için tablo ismi falan da değişebilirsin
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(x => x.Id);

            //birebir ilişki tanımı. payment alt sınıf gibi
            builder.HasOne(x => x.Customer).WithOne(x => x.Payment).HasForeignKey<Payment>(x => x.CustomerId);

            builder.Property(x => x.Amount).IsRequired().HasColumnType("decimal(18,2)"); //para değeri toplamda 18 karakter virgülden sonra da 2 karakter olabilir.
        }
    }
}