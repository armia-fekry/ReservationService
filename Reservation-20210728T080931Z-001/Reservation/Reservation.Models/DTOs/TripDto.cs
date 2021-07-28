using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Reservation.Models.DTOs
{
   public class TripDto
    {
        
        [Required(ErrorMessage = "please enter name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "please enter city name")]
        public string CityName { get; set; }

        public double Price { get; set; }
        [Required(ErrorMessage = "please provide images ")]
        public string ImageUrl { get; set; }
        [AllowHtml]
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
