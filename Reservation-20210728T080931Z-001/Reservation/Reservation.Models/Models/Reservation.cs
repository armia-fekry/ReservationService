
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reservation.Models.Models
{
    public class ReservationModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResevationId { get; set; }

        [Required]
        public int TripId { get; set; }
        
        [ForeignKey("TripId")]
        public Trip Trip { get; set; }

        public User User { get; set; }
        [ForeignKey("User")]
        public int ReservedBy { get; set; }
        public string CustomerName { get; set; }
        [Required]
        public DateTime ReservationDate { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        public string Notes { get; set; }


    }
}