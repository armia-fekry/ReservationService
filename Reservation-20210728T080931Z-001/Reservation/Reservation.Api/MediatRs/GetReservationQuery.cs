using MediatR;
using Reservation.DataAccess;
using Reservation.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation.Api.MediatRs
{
    public class GetReservationQuery : IRequest<ServiceResponse<ReservationDto>>
    {
        public int? id { get; set; }
    }   
}
