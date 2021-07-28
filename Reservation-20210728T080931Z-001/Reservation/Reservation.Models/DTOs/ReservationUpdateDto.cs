using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Models.DTOs
{
   public class ReservationUpdateDto:ReservationDto
    {
        public int reservationId { get; set; }
    }
}
