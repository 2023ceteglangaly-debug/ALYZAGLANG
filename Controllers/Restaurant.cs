using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using RestReservation.Models;
using RestReservation.Services;
using RestReservation.ViewModels;

namespace RestReservation.Controllers
{
    public class RestaurantController(IRestaurantService restaurantService) : Controller
    {
        private readonly IRestaurantService _restaurantService = restaurantService;

        public IActionResult Index()
        {
            RestaurantListViewModel viewModel = new()
            {
                Restaurants = _restaurantService.GetAllRestaurants(),
            };
            return View(viewModel);
        }
    }
}