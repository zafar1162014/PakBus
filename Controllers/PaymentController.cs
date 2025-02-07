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
                // Update booking status to paid
                booking.IsPaid = true;
                _paymentService.UpdateBooking(booking);

                return RedirectToAction("PaymentSuccess", new { bookingId });
            }
            else
            {
                // Handle payment failure
                ModelState.AddModelError("", "Payment failed. Please try again.");
                return View("Index");
            }
        }

        // GET: Payment/PaymentSuccess
        public IActionResult PaymentSuccess(int bookingId)
        {
            var booking = _paymentService.GetBookingById(bookingId);
            if (booking == null)
            {
                return NotFound();
            }

            ViewBag.Booking = booking;
            return View();
        }

        // Other actions for payment history, refunds, etc.
        public IActionResult PaymentHistory(int userId)
        {
            var payments = _paymentService.GetPaymentsByUserId(userId);
            return View(payments);
        }

        public IActionResult RefundPayment(int paymentId)
        {
            // Implement refund logic here
            // This could involve reversing the payment or issuing a refund
            _paymentService.RefundPayment(paymentId);

            return RedirectToAction("PaymentHistory");
        }
    }
}