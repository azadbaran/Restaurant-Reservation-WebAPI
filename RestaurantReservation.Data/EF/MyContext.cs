using System;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Data.EntityModels;

namespace RestaurantReservation.Data.EF
{
    public class MyContext:DbContext
    {

        public MyContext(DbContextOptions<MyContext> x):base(x)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Odjeljenje>()
            //    .HasOne(x => x.Razrednik)
            //    .WithMany()
            //    .HasForeignKey(x => x.RazrednikID)
            //    .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<AutorizacijskiToken> AutorizacijskiToken { get; set; }
        public DbSet<KorisnickiNalog> KorisnickiNalog { get; set; }
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<Restoran> Restoran { get; set; }
        public DbSet<Rezervacija> Rezervacija { get; set; }
    }
}
