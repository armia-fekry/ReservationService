using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Models.DTOs
{
   public class ReservationDto
    {
        public int TripId { get; set; }
        [Required]
        public int ReservedBy { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public DateTime ReservationDate { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        public string Notes { get; set; }

    }
}
