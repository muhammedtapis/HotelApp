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
    public class CustomerSeed : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new Customer() { Id = 1, Name = "Muhammed Ali Tapış", PassportNo = "17947122542", Address = "adana", RoomId = 1, Payment = 1457, IsPayed = false },
                new Customer() { Id = 2, Name = "Diyara Mamysheva", PassportNo = "20214040097", Address = "almaty", RoomId = 1, Payment = 1457, IsPayed = false },
                new Customer() { Id = 3, Name = "Karam", PassportNo = "17947122542", Address = "istanbul", RoomId = 2, Payment = 1457, IsPayed = true }
                );
        }
    }
}