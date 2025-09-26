using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using Alyza_Glang__Final.Models;

namespace Alyza_Glang__Final.Services
{
    public class ReservationService : IReservationService
    {
        private readonly RestaurantReservationDbContext _restaurantDbContext;

        public ReservationService(RestaurantReservationDbContext restaurantDbContext)
        {
            _restaurantDbContext = restaurantDbContext;
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            // Replaced NotImplementedException with the actual database query
            return _restaurantDbContext.Reservations.OrderByDescending(r => r.date).ToList();
        }

        public Reservation GetReservationById(ObjectId id)
        {
            // Replaced NotImplementedException with the actual database query
            var reservation = _restaurantDbContext.Reservations.FirstOrDefault(r => r.Id == id);
            return reservation ?? throw new ArgumentException("Reservation not found.");
        }

        public void AddReservation(Reservation newReservation)
        {
            var bookedRestaurant = _restaurantDbContext.Restaurants.FirstOrDefault(c => c.Id == newReservation.RestaurantId);
            if (bookedRestaurant == null)
            {
                throw new ArgumentException("The restaurant to be reserved cannot be found.");
            }
            newReservation.RestaurantName = bookedRestaurant.name;
            _restaurantDbContext.Reservations.Add(newReservation);
            _restaurantDbContext.SaveChanges();
        }

        public void EditReservation(Reservation updatedReservation)
        {
            var reservationToUpdate = _restaurantDbContext.Reservations.FirstOrDefault(r => r.Id == updatedReservation.Id);
            if (reservationToUpdate != null)
            {
                reservationToUpdate.date = updatedReservation.date;
                reservationToUpdate.Name = updatedReservation.Name;
                reservationToUpdate.Mobile = updatedReservation.Mobile;
                reservationToUpdate.RestaurantId = updatedReservation.RestaurantId;
                // Always set RestaurantName from RestaurantId
                var bookedRestaurant = _restaurantDbContext.Restaurants.FirstOrDefault(c => c.Id == updatedReservation.RestaurantId);
                reservationToUpdate.RestaurantName = bookedRestaurant != null ? bookedRestaurant.name : null;
                _restaurantDbContext.Reservations.Update(reservationToUpdate);
                _restaurantDbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("The reservation to update cannot be found.");
            }
        }
        
        public void DeleteReservation(Reservation reservation)
        {
            var reservationToDelete = _restaurantDbContext.Reservations.FirstOrDefault(b => b.Id == reservation.Id);
            if (reservationToDelete != null)
            {
                _restaurantDbContext.Reservations.Remove(reservationToDelete);
                _restaurantDbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("The reservation to delete cannot be found.");
            }
        }
    }
}