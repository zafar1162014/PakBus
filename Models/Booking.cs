using System.ComponentModel.DataAnnotations;

namespace PakBus.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        [Required]
        public int BusId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        [Required]
        public decimal TotalFare { get; set; }

        public bool IsPaid { get; set; } = false;

        // Navigation property to Bus
        public Bus Bus { get; set; }

        // Navigation property to User
        public User User { get; set; }
    }
}