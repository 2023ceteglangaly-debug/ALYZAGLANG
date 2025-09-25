using RestReservation.ViewModels;

namespace RestReservation.ViewModels
{
    public class RestaurantListViewModel
    {
        public IEnumerable<RestaurantModel>? Restaurants { get; set; }

        public class RestaurantModel
        {
        }
    }
}