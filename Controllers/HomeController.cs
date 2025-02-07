using Microsoft.AspNetCore.Mvc;
using PakBus.Models;
using PakBus.Services;

namespace PakBus.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBusService _busService;

        public HomeController(ILogger<HomeController> logger, IBusService busService)
        {
            _logger = logger;
            _busService = busService;
        }

        public IActionResult Index()
        {
            var buses = _busService.GetAllBuses();
            return View(buses);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        // Additional actions for PakBus functionality

        public IActionResult BookBus(int busId)
        {
            // Logic to book a bus, e.g., redirect to booking form or process booking directly
            return RedirectToAction("BookingConfirmation", new { busId = busId });
        }

        public IActionResult BookingConfirmation(int busId)
        {
            // Display confirmation message or details of the booking
            return View();
        }

        public IActionResult CancelBooking(int bookingId)
        {
            // Logic to cancel a booking
            return RedirectToAction("Index");
        }

        public IActionResult ViewBookings()
        {
            // Logic to retrieve user's booking history
            var bookings = _busService.GetBookingsForUser(userId); // Replace userId with actual user ID
            return View(bookings);
        }
    }
}