using Microsoft.AspNetCore.Mvc;
using PakBus.Models;
using PakBus.Services;

namespace PakBus.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        // GET: Payment
        public IActionResult Index(int bookingId)
        {
            var booking = _paymentService.GetBookingById(bookingId);
            if (booking == null)
            {
                return NotFound();
            }

            ViewBag.Booking = booking;
            return View();
        }

        // POST: Payment/ProcessPayment
        [HttpPost]
        public IActionResult ProcessPayment(int bookingId, Payment payment)
        {
            var booking = _paymentService.GetBookingById(bookingId);
            if (booking == null)
            {
                return NotFound();
            }

            // **Simulate successful payment for demonstration purposes**
            // Replace with actual payment gateway integration
            bool paymentSuccess = true; // Replace with actual payment verification

            if (paymentSuccess)
            {
