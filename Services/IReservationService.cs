using MongoDB.Bson;
// Removed reference to missing Models namespace

namespace RestReservation.Services
{
    public interface IReservationService
    {
        IEnumerable<Reservation> GetAllReservations();
        Reservation? GetReservationById(ObjectId id);
        void AddReservation(Reservation newReservation);
        void EditReservation(Reservation updatedReservation);
        void DeleteReservation(Reservation reservationToDelete);
    }

    public class Reservation
    {
        public MongoDB.Bson.ObjectId Id { get; set; }
        public string? CustomerName { get; set; }
        public DateTime ReservationDate { get; set; }
        public int NumberOfGuests { get; set; }
    }
}
