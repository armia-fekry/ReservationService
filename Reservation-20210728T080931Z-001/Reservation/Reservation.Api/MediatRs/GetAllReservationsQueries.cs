using MediatR;
using Reservation.DataAccess;
using Reservation.Models.DTOs;
using System.Collections.Generic;

namespace Reservation.Api.MediatRs
{
    public class GetAllReservationsQueries:IRequest<ServiceResponse<IEnumerable<ReservationDto>>>
    {
    }
}
