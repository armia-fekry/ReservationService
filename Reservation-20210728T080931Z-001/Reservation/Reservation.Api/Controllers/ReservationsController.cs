using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservation.Api.MediatRs;
using Reservation.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Reservation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public ReservationsController(IMediator mediatR)
        {
            this._mediatR = mediatR;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var reservations = await _mediatR.Send(new GetAllReservationsQueries());
            if (reservations.Data.Any())
            {
                return Ok(reservations);

            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("{id}", Name = "GetReservation")]
        public async Task<IActionResult> Get(int? _id)
        {
            if (_id ==null || _id<0)
            {
                return BadRequest(_id);
            }

            return Ok(await _mediatR.Send(new GetReservationQuery() { id = _id }));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ReservationDto reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(reservation);
            }

            return Ok(await _mediatR.Send(new AddReservationQuery()
            {
                reservationDto=reservation
            }));
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ReservationUpdateDto _reservation)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(await _mediatR.Send
                    (new UpdateReservationQueries() { reservation=_reservation }));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //DELETE: api/reservation/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null || id<0)
                {
                    return BadRequest("incorrect id ");
                }
                return Ok(await _mediatR.Send(new DeleteReservationQueries() { _id=id}));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
