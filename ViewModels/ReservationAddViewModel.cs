using Alyza_Glang__Final.Models;

namespace Alyza_Glang__Final.ViewModels
{
    public class ReservationAddViewModel
    {
        // --- THIS IS THE LINE THAT FIXES THE ERROR ---
        // You must add this property to the class itself.
        public string RestaurantName { get; set; }

        // This property should already be here.
        public Reservation Reservation { get; set; }
    }
}