using Hotel.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Repository.Seeds
{
    internal class PaymentSeed : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasData(
                new Payment()
                {
                    Id = 1,
                    Amount = 1000,
                    IsPayed = true,
                    CustomerId = 1,
                },
                new Payment()
                {
                    Id = 2,
                    Amount = 2000,
                    IsPayed = true,
                    CustomerId = 2,
                },
                new Payment()
                {
                    Id = 3,
                    Amount = 3000,
                    IsPayed = false,
                    CustomerId = 3,
                }

                );
        }
    }
}