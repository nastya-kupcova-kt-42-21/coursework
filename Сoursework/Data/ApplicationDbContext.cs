using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Сoursework.Models;

namespace Сoursework.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Guest> Guests { get; set; } = default!;

        public DbSet<Room> Rooms { get; set; } = default!;

        public DbSet<Service> Services { get; set; } = default!;

        public DbSet<Reservation> Reservations { get; set; } = default!;

        public DbSet<Payment> Payments { get; set; } = default!;

        public DbSet<Review> Reviews { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Конфигурация для Guest
            modelBuilder.Entity<Guest>()
                .HasKey(g => g.GuestId);

            modelBuilder.Entity<Guest>()
                .HasMany(g => g.Reservations)
                .WithOne(r => r.Guests)
                .HasForeignKey(r => r.GuestId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Guest>()
                .HasMany(g => g.Reviews)
                .WithOne(r => r.Guests)
                .HasForeignKey(r => r.GuestId)
                .OnDelete(DeleteBehavior.Restrict);

            // Конфигурация для Room
            modelBuilder.Entity<Room>()
                .HasKey(r => r.RoomId);

            modelBuilder.Entity<Room>()
                .HasMany(r => r.Reservations)
                .WithOne(r => r.Rooms)
                .HasForeignKey(r => r.RoomId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Room>()
                .HasMany(r => r.Reviews)
                .WithOne(r => r.Rooms)
                .HasForeignKey(r => r.RoomId)
                .OnDelete(DeleteBehavior.Restrict);

            // Конфигурация для Service
            modelBuilder.Entity<Service>()
                .HasKey(s => s.ServiceId);

            modelBuilder.Entity<Service>()
                .HasMany(s => s.Reservations)
                .WithOne(r => r.Services)
                .HasForeignKey(r => r.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            // Конфигурация для Reservation
            modelBuilder.Entity<Reservation>()
                .HasKey(r => r.BookingId);

            modelBuilder.Entity<Reservation>()
                .HasMany(r => r.Payments)
                .WithOne(p => p.Reservations)
                .HasForeignKey(p => p.BookingId)
                .OnDelete(DeleteBehavior.Restrict);

            // Конфигурация для Payment
            modelBuilder.Entity<Payment>()
                .HasKey(p => p.PaymentId);

            // Конфигурация для Review
            modelBuilder.Entity<Review>()
                .HasKey(r => r.ReviewId);
        }
    }
}
