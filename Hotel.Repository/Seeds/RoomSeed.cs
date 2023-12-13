using Hotel.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Repository.Seeds
{
    internal class RoomSeed : IEntityTypeConfiguration<Room>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Room> builder)
        {
            builder.HasData(
                new Room() { Id = 1, FloorId = 1, Price = 2400, RoomNo = 101, IsAvailable = true, CustomerId = 1 },
                new Room() { Id = 2, FloorId = 1, Price = 2400, RoomNo = 102, IsAvailable = false, CustomerId = 2 }
                );
        }
    }
}