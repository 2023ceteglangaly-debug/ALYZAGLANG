using Microsoft.EntityFrameworkCore;
using Alyza_Glang__Final.Models;

namespace Alyza_Glang__Final.Services
{
    // This is the correct class declaration. It inherits from DbContext.
    public class RestaurantReservationDbContext : DbContext
    {
        // 1. These properties belong directly inside the class.
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        // 2. This is the SINGLE, CORRECT constructor.
        public RestaurantReservationDbContext(DbContextOptions<RestaurantReservationDbContext> options) : base(options)
        {
        }

        // 3. This method also belongs directly inside the class.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Restaurant>();
            modelBuilder.Entity<Reservation>();
        }
    }
}