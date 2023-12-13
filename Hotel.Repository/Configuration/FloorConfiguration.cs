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
    public class FloorConfiguration : IEntityTypeConfiguration<Floor>
    {
        public void Configure(EntityTypeBuilder<Floor> builder)
        {
            //productın bir kategorisi olabilir kategorinin ise birden fazla product olabilir.foreign key de bu şekilde verilebilir
            builder.HasOne(x => x.Hostel).WithMany(x => x.Floors).HasForeignKey(x => x.HostelId);
        }
    }
}