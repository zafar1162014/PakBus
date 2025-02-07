using System.ComponentModel.DataAnnotations;

namespace PakBus.Models
{
  public class User
  {
    public int UserId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string PhoneNumber { get; set; }

    // Navigation property to Bookings
    public ICollection<Booking> Bookings { get; set; }
  }
}
