using Microsoft.EntityFrameworkCore;
using Voyago_Backend.Models;

namespace Voyago_Backend.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Driver> Drivers { get; set; } = null!;
        public DbSet<Owner> Owners { get; set; } = null!;
        public DbSet<Admin> Admins { get; set; } = null!;
        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<Trip> Trips { get; set; } = null!;
        public DbSet<Ticket> Tickets { get; set; } = null!;
        public DbSet<Company> Companies { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Owner>()
                .HasMany(owner => owner.Companies)
                .WithOne(company => company.Owner)
                .HasForeignKey(company => company.OwnerId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Tickets)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<Driver>()
                .HasOne(driver => driver.Company)
                .WithMany(company => company.Drivers)
                .HasForeignKey(driver => driver.CompanyId);

            modelBuilder.Entity<User>()
                .HasMany(user => user.UserTrips)
                .WithMany(trip => trip.UserTrips);
                
            modelBuilder.Entity<User>(entity =>
    {

        entity.Property<string>("HashedPassword")
              .HasColumnName("HashedPassword")
              .IsRequired();

    });
        }


    }
}