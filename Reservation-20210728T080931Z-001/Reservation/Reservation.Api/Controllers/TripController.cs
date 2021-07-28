using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservation.DataAccess.Reposatories;
using Reservation.Models.DTOs;
using Reservation.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly ITripReposatory _TripReposatory;
        public TripController(ITripReposatory reposatory)
        {
            _TripReposatory = reposatory;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var trips = await _TripReposatory.GetAll();
            if (trips.Data.Any())
            {
            return Ok(trips);

            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TripDto trip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(trip);
            }

            return Ok(await _TripReposatory.Add(trip));
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TripDto trip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(trip);
            }

            return Ok(await _TripReposatory.Update(trip));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int ? id)
        {
            if (id==null)
            {
                return BadRequest("incorrect id");
            }

            return Ok(await _TripReposatory.Delete(id));
        }



    }
}
