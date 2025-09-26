using MongoDB.Bson;
using Alyza_Glang__Final.Models;

namespace Alyza_Glang__Final.Services
{
    public interface IReservationService
    {
        IEnumerable<Reservation> GetAllReservations();
        Reservation GetReservationById(ObjectId id);
        void AddReservation(Reservation newReservation);
        void EditReservation(Reservation updatedReservation);
        void DeleteReservation(Reservation reservationToDelete);
    }
}