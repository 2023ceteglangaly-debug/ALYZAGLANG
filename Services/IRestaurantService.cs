using MongoDB.Bson;
using Alyza_Glang__Final.Models;

namespace Alyza_Glang__Final.Services
{
    public interface IRestaurantService
    {
        IEnumerable<Restaurant>GetAllRestaurants();
        Restaurant? GetRestaurantById(ObjectId id);

        void AddRestaurant(Restaurant newRestaurant);
        void EditRestaurant(Restaurant updatedRestaurant);
        void DeleteRestaurant(Restaurant restaurantToDelete);
        // ...
    }

}