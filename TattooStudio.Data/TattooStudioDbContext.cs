using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooStudio.Data.Settings;
using TattooStudio.Models;

namespace TattooStudio.Data
{
    public class TattooStudioDbContext : DbContext
    {
        private readonly DatabaseSettings databaseSettings;
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Work> Works { get; set; }
        public virtual DbSet<ReadyTattoo> ReadyTattoos { get; set; }
        public virtual DbSet<Tattoo> Tattoos { get; set; }

        public TattooStudioDbContext(DatabaseSettings databaseSettings)
        {
            this.databaseSettings = databaseSettings;
            this.Database.EnsureCreated();
        }
        public TattooStudioDbContext(DbContextOptions<TattooStudioDbContext> options,DatabaseSettings databaseSettings) : base(options) {
            this.databaseSettings = databaseSettings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(databaseSettings.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Work>(entity =>
            {
                entity.HasOne(work => work.Customer)
                .WithMany(c => c.Works)
                .HasForeignKey(w => w.CustomerID)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ReadyTattoo>(entity =>
            {
                entity.HasOne(t => t.Work)
                .WithMany(w => w.Tattoos)
                .HasForeignKey(t => t.WorkID)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(rt => rt.TattooType)
                .WithMany(t => t.ReadyTattoos)
                .HasForeignKey(rt => rt.TattooID)
                .OnDelete(DeleteBehavior.Cascade);
            });

            Customer c1 = new Customer() { CustomerID = 1, Name = "Kiss Béla", BornDate = new DateTime(1995, 11, 23), Email = "kissb@gmail.com" };
            Customer c2 = new Customer() { CustomerID = 2, Name = "Nagy Ákos", BornDate = new DateTime(1999, 1, 14), Email = "nagya@gmail.com" };
            Customer c3 = new Customer() { CustomerID = 3, Name = "Kovács Levente", BornDate = new DateTime(2001, 3, 3), Email = "kovl@gmail.com" };

            Work w1 = new Work() { WorkID = 1, Date = new DateTime(2010, 9, 6), CustomerID = c1.CustomerID };
            Work w2 = new Work() { WorkID = 2, Date = new DateTime(2015, 7, 7), CustomerID = c2.CustomerID };
            Work w3 = new Work() { WorkID = 3, Date = new DateTime(2019, 3, 3), CustomerID = c3.CustomerID };
            Work w4 = new Work() { WorkID = 4, Date = new DateTime(2015, 9, 6), CustomerID = c1.CustomerID };

            ReadyTattoo tr1 = new ReadyTattoo() { RTattooID = 1, Price = 21000, WorkID = 1, TattooID = 1 };
            ReadyTattoo tr2 = new ReadyTattoo() { RTattooID = 2, Price = 31000, WorkID = 1, TattooID = 2 };
            ReadyTattoo tr3 = new ReadyTattoo() { RTattooID = 3, Price = 7000, WorkID = 1, TattooID = 4 };
            ReadyTattoo tr4 = new ReadyTattoo() { RTattooID = 4, Price = 5000, WorkID = 3, TattooID = 3 };
            ReadyTattoo tr5 = new ReadyTattoo() { RTattooID = 5, Price = 7200, WorkID = 2, TattooID = 2 };
            ReadyTattoo tr6 = new ReadyTattoo() { RTattooID = 6, Price = 5400, WorkID = 2, TattooID = 4 };
            ReadyTattoo tr7 = new ReadyTattoo() { RTattooID = 7, Price = 5700, WorkID = 4, TattooID = 2 };

            Tattoo t1 = new Tattoo() { TattooID = 1, Sample = Samples.Animal };
            Tattoo t2 = new Tattoo() { TattooID = 2, Sample = Samples.Person };
            Tattoo t3 = new Tattoo() { TattooID = 3, Sample = Samples.Name };
            Tattoo t4 = new Tattoo() { TattooID = 4, Sample = Samples.Abstract };


            modelBuilder.Entity<Work>().HasData(w1, w2, w3,w4);
            modelBuilder.Entity<Customer>().HasData(c1, c2, c3);
            modelBuilder.Entity<ReadyTattoo>().HasData(tr1, tr2, tr3, tr4, tr5, tr6,tr7);
            modelBuilder.Entity<Tattoo>().HasData(t1, t2, t3, t4);
        }
    }
}
