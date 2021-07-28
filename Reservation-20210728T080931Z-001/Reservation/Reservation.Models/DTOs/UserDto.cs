using System.ComponentModel.DataAnnotations;

namespace Reservation.Models.DTOs
{
    public class UserDto
    {
        [Required(ErrorMessage = "please enter Email")]

        public string Email { get; set; }
        [Required(ErrorMessage = "please enter Password")]

        public string password { get; set; }
    }
}
