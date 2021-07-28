using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reservation.DataAccess;
using Reservation.Models;
using Reservation.Models.DTOs;

namespace Reservation.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly string _connString;
        private readonly IAuthenticationReposatory _auth;
        public UsersController(IConfiguration config,IAuthenticationReposatory auth)
        {
            _auth = auth;
            _connString = config.GetConnectionString("Reservation");
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserDto userRequest )
        {
            var serviceResponse= await _auth.Register(new UserDto()
            {
                Email = userRequest.Email,
                password = userRequest.password

            }) ;

            if (!serviceResponse.succeed)
            {
                return BadRequest(serviceResponse);
            }
            else
            {
                return Ok(serviceResponse);
            }
        }


    }
}
