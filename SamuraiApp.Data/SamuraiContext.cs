using System;
using System.Text;
using SamuraiApp.Domain;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SamuraiApp.Data
{
    public class SamuraiContext : DbContext
    {
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Clan> Clans { get; set; }
        public DbSet<Battle> Battles { get; set; }

        // We did not create a DbSet<Horse> becasue we don't want to allow
        // interacting directly with Horse if someone working with Api

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = SamuraiAppData");
        }

        // This method is called at run-time internally when Ef is figuring what the data look like.
        // Below method is required to register the many to many relationship
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SamuraiBattle>().HasKey(s => new { s.SamuraiId, s.BattleId });

            // ef will createa table for the horses despite that we did not
            // specifiy the next line is to change the name of the created
            // table from the entity name Horse to Horses

            modelBuilder.Entity<Horse>().ToTable("Horses");
        }
    }
}
