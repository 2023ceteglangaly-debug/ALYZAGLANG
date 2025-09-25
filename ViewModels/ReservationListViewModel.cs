using RestReservation.ViewModels;

namespace RestReservation.ViewModels
{
    public class ReservationListViewModel
    {
        public IEnumerable<Reservation>? Reservations { get; set; }
    }

    public class Reservation
    {
    }
}