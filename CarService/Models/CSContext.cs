using CarService.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace CarService.Models
{
    public class CSContext : DbContext
    {
        public DbSet<Brand>? Brands { get; set; }
        public DbSet<Model>? Models { get; set; }
        public DbSet<Owner>? Owners { get; set; }
        public DbSet<Service>? Services { get; set; }
        public DbSet<Vehicle>? Vehicles { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var documentsFolderLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Car Service LITE";
            optionsBuilder.UseSqlite($"DataSource={documentsFolderLocation}\\CarService.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Brand>().GenerateData();
            modelBuilder.Entity<Model>().GenerateData();
            modelBuilder.Entity<Owner>().GenerateData();
            modelBuilder.Entity<Service>().GenerateData();
            modelBuilder.Entity<Vehicle>().GenerateData();
        }
    }
}