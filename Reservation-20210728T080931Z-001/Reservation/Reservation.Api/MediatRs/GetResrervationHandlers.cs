using MediatR;
using Reservation.DataAccess;
using Reservation.DataAccess.Reposatories;
using Reservation.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Reservation.Api.MediatRs
{
    public class AddRerservationHandlers : IRequestHandler<GetReservationQuery, ServiceResponse<ReservationDto>>
    {
        private readonly IReservationReposatory _reservationReposatory;

        public AddRerservationHandlers(IReservationReposatory reposatory)
        {
            this._reservationReposatory = reposatory;
        }
        public async Task<ServiceResponse<ReservationDto>> Handle(GetReservationQuery request, CancellationToken cancellationToken)
        {
            return await _reservationReposatory.GetById(request.id);
        }
    }
}
