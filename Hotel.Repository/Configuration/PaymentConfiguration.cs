using Hotel.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Repository.Configuration
{
    internal class PaymentConfiguration
    {
        //configurasyon için tablo ismi falan da değişebilirsin
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(x => x.Id);

            //birebir ilişki tanımı.
            builder.HasOne(x => x.Customer).WithOne(x => x.Payment).HasForeignKey<Payment>(x => x.CustomerId);
        }
    }
}