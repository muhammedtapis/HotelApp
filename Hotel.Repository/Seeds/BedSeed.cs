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
    internal class BedSeed : IEntityTypeConfiguration<Bed>
    {
        public void Configure(EntityTypeBuilder<Bed> builder)
        {
            builder.HasData(
                new Bed() { Id = 1, BedNumber = 1, RoomId = 1 },
                new Bed() { Id = 2, BedNumber = 2, RoomId = 1 },
                new Bed() { Id = 3, BedNumber = 1, RoomId = 2 }
                );
        }
    }
}