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

        public IActionRes