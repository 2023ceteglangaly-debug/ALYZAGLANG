using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using ALYZAGLANG.ViewModels; // Assumes ReservationListViewModel is in this namespace
using ALYZAGLANG.Services;

namespace ALYZAGLANG.Controllers
{
    // FIX 1: Corrected class name casing from "Reservationcontroller"
    public class ReservationController : Controller
    {
        // FIX 2: Declared fields first
        private readonly IReservationService _reservationService;
        private readonly IRestaurantService _restaurantService;

        // FIX 3: Implemented a standard constructor to initialize the services
        public ReservationController(IReservationService reservationService, IRestaurantService restaurantService)
        {
            _reservationService = reservationService;
            _restaurantService = restaurantService;
        }

        public IActionResult Index()
        {
            var viewModel = new ReservationListViewModel
            {
                Reservations = _reservationService.GetAllReservations()
            };
            return View(viewModel);
        }

        // Other actions like Add, Edit, Delete would follow...
    }
}

// NOTE: The "ReservationListViewModel" class should be moved to its own file
// inside the "ViewModels" folder. It should not be in the controller file.