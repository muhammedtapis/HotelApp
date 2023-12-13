using Hotel.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Hostel> Hostels { get; set; }
        public DbSet<Payment> Payments { get; set; }

        //entity configuration override ettik model oluşurken çalışcak.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //configuration sınıflarında implemente ettiğimiz interface sayesinde hepsini buluyor.
            //modelBuilder.ApplyConfiguration(new ProductConfiguration()); //böyle tek tek vermek yerine yukarıdaki metodla hepsini veriyoruz

            base.OnModelCreating(modelBuilder);
        }
    }
}