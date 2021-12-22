using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooStudio.Models;

namespace TattooStudio.Data
{
    public class TattooStudioDbContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Work> Works { get; set; }
        public virtual DbSet<Tattoo> Tattoos { get; set; }



        public TattooStudioDbContext()
        {
            this.Database.EnsureCreated();
        }
        public TattooStudioDbContext(DbContextOptions<TattooStudioDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TattooStudio_DataBase.mdf;Integrated Security=True");
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

            Customer c1 = new Customer() { CustomerID = 1, Name = "Kiss Béla", BornDate = new DateTime(1995, 11, 23), Email = "kissb@gmail.com" };
            Customer c2 = new Customer() { CustomerID = 2, Name = "Nagy Ákos", BornDate = new DateTime(1999, 1, 14), Email = "nagya@gmail.com" };
            Customer c3 = new Customer() { CustomerID = 3, Name = "Kovács Levente", BornDate = new DateTime(2001, 3, 3), Email = "kovl@gmail.com" };

            Work w1 = new Work() { WorkID = 1, Date = new DateTime(2010, 9, 6), CustomerID = c1.CustomerID };
            Work w2 = new Work() { WorkID = 2, Date = new DateTime(2015, 7, 7), CustomerID = c2.CustomerID };
            Work w3 = new Work() { WorkID = 3, Date = new DateTime(2019, 3, 3), CustomerID = c3.CustomerID };

            Tattoo t1 = new Tattoo() { TattooID = 1,Sample = Samples.Animal, Price = 21000 };
            Tattoo t2 = new Tattoo() { TattooID = 2,Sample = Samples.Animal, Price = 14000 };
            Tattoo t3 = new Tattoo() { TattooID = 3, Sample = Samples.Abstract, Price = 7000 };
            Tattoo t4 = new Tattoo() { TattooID = 4, Sample = Samples.Name, Price = 5000 };
            Tattoo t5 = new Tattoo() { TattooID = 5, Sample = Samples.Person, Price = 31000 };
            Tattoo t6 = new Tattoo() { TattooID = 6, Sample = Samples.Name, Price = 3400 };

            w1.Tattoos.Add(t1);
            w1.Tattoos.Add(t2);
            w1.Tattoos.Add(t3);

            w2.Tattoos.Add(t4);
            w2.Tattoos.Add(t5);

            w3.Tattoos.Add(t6);

            modelBuilder.Entity<Work>().HasData(w1, w2, w3);
            modelBuilder.Entity<Customer>().HasData(c1, c2, c3);
            modelBuilder.Entity<Tattoo>().HasData(t1, t2, t3, t4, t5, t6);


        }

    }
}
