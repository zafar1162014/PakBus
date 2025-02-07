using Microsoft.AspNetCore.Mvc;
using PakBus.Models;
using PakBus.Services;

namespace PakBus.Controllers
{
    public class BookingsController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IBusService _busService;

        public BookingsController(IBookingService bookingService, IBusService busService)
        {
            _bookingService = bookingService;
            _busService = busService;
        }

        // GET: Bookings
        public IActionResult Index()
        {
            var bookings = _bookingService.GetAllBookings();
            return View(bookings);
        }

        // GET: Bookings/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = _bookingService.GetBookingById(id.Value);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Bookings/Create
        public IActionResult Create(int busId)
        {
            var bus = _busService.GetBusById(busId);
            if (bus == null)
            {
                return NotFound();
            }

            ViewBag.Bus = bus;
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int busId, Booking booking)
        {
            if (ModelState.IsValid)
            {
                booking.BusId = busId;
                _bookingService.AddBooking(booking);
                return RedirectToAction("Index");
            }
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = _bookingService.GetBookingById(id.Value);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Booking booking)
        {
            if (id != booking.BookingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bookingService.UpdateBooking(booking);
                return RedirectToAction(nameof(Index));
            }
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = _bookingService.GetBookingById(id.Value);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _bookingService.DeleteBooking(id);
            return RedirectToAction(nameof(Index));
        }
    }
}