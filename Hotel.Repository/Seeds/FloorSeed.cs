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
    internal class FloorSeed : IEntityTypeConfiguration<Floor>
    {
        public void Configure(EntityTypeBuilder<Floor> builder)
        {
            builder.HasData(
                new Floor() { Id = 1, HotelId = 1, Name = "1. Kat" },
                new Floor() { Id = 2, HotelId = 1, Name = "2. Kat" }
                );
        }
    }
}