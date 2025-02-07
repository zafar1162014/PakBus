using Microsoft.EntityFrameworkCore;
using PakBus.Models;

namespace PakBus.Data
{
    public class PakBusContext : DbContext
    {
        public PakBusContext(DbContextOptions<PakBusContext> options)
            : base(options)
        {
        }

        public DbSet<Bus> Buses { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships and other model-specific settings here
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Bus)
                .WithMany(b => b.Bookings)
                .HasForeignKey(b => b.BusId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Booking)
                .WithMany(b => b.Payments)
                .HasForeignKey(p => p.BookingId);
        }
    }
}