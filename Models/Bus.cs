using System.ComponentModel.DataAnnotations;

namespace PakBus.Models
{
    public class Bus
    {
        public int BusId { get; set; }

        [Required]
        public string BusNumber { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        public DateTime ArrivalTime { get; set; }

        [Required]
        public string DepartureCity { get; set; }

        [Required]
        public string ArrivalCity { get; set; }

        [Required]
        public decimal Fare { get; set; }

        [Required]
        public int SeatsAvailable { get; set; }
    }
}