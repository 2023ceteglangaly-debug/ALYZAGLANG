using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using ALYZAGLANG.Models;
using ALYZAGLANG;

namespace RestRes.Services
{
    public class ReservationService : IReservationService
    {
        private readonly RestaurantReservationDbContext _restaurantDbContext;

        public ReservationService(RestaurantReservationDbContext restaurantDbContext)
        {
            _restaurantDbContext = restaurantDbContext;
        }

        public void AddReservation(Reservation newReservation)
        {
            var bookedRestaurant = _restaurantDbContext.Restaurants
                .FirstOrDefault(c => c.Id == newReservation.RestaurantId);

            if (bookedRestaurant == null)
            {
                throw new ArgumentException("The restaurant to be reserved cannot be found.");
            }

            newReservation.RestaurantName = bookedRestaurant.name;
            _restaurantDbContext.Reservations.Add(newReservation);
            _restaurantDbContext.ChangeTracker.DetectChanges();
            Console.WriteLine(_restaurantDbContext.ChangeTracker.DebugView.LongView);
            _restaurantDbContext.SaveChanges();
        }

        public void DeleteReservation(Reservation reservation)
        {
            var reservationToDelete = _restaurantDbContext.Reservations
                .FirstOrDefault(b => b.Id == reservation.Id);

            if (reservationToDelete != null)
            {
                _restaurantDbContext.Reservations.Remove(reservationToDelete);
                _restaurantDbContext.ChangeTracker.DetectChanges();
                Console.WriteLine(_restaurantDbContext.ChangeTracker.DebugView.LongView);
                _restaurantDbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("The reservation to delete cannot be found.");
            }
        }

        public void EditReservation(Reservation updatedReservation)
        {
            // Method body was empty in the provided code
        }
    }

    public class RestaurantReservationDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }

    public class Restaurant
    {
        internal ObjectId Id;
        internal string? name;
        internal object? cuisine;
        internal object? borough;
    }
}