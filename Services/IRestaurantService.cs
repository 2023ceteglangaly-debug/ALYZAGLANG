using MongoDB.Bson;
using RestReservation;

namespace RestReservation.Services
{
    public interface IRestaurantService
    {
        IEnumerable<RestaurantModel> GetAllRestaurants();

        RestaurantModel? GetRestaurantById(ObjectId id);

        void AddRestaurant(RestaurantModel newRestaurant);

        void EditRestaurant(RestaurantModel updatedRestaurant);
        
        void DeleteRestaurant(RestaurantModel restaurantToDelete);
    }

    public class ObjectId
    {
    }

    public class RestaurantModel
    {
    }
}