using Hotel.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
        public DbSet<Bed> Beds { get; set; }

        //entity configuration override ettik model oluşurken çalışcak.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //configuration sınıflarında implemente ettiğimiz interface sayesinde hepsini buluyor.
            //modelBuilder.ApplyConfiguration(new ProductConfiguration()); //böyle tek tek vermek yerine yukarıdaki metodla hepsini veriyoruz

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateChangeTrackerCreateUpdateDate();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            UpdateChangeTrackerCreateUpdateDate();
            return base.SaveChanges();
        }

        //bu metod save changes metodundan önce çalıştırmak için var burada created ve updated dateleri ekleme güncelleme yapıyoruz.
        public void UpdateChangeTrackerCreateUpdateDate()
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity baseEntity)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                Entry(baseEntity).Property(x => x.UpdatedDate).IsModified = false; //nolur nolmaz ekleme yaparken updated date atamasın diye
                                baseEntity.CreatedDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                //update ederken createdDate alanını güncellemesin diye modified false yapman gerek!!!
                                //yoksa her update edildiğinde buraya bi güncelleme yapar değeri değişir.
                                Entry(baseEntity).Property(x => x.CreatedDate).IsModified = false;
                                baseEntity.UpdatedDate = DateTime.Now;
                                break;
                            }
                    }
                }
            }
        }
    }
}