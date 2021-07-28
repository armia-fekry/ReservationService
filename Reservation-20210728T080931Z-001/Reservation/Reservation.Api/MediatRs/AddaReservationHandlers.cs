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
    public class AddRerservationHandler: IRequestHandler<AddReservationQuery, 
        ServiceResponse<ReservationDto>>
    {
        private readonly IReservationReposatory _reservationReposatory;

        public AddRerservationHandler(IReservationReposatory reposatory)
        {
            this._reservationReposatory = reposatory;
        }

        public async Task<ServiceResponse<ReservationDto>> Handle(AddReservationQuery addReservation,
            CancellationToken cancellationToken)
        {
            return await _reservationReposatory.Add(addReservation.reservationDto);
        }
    }
}
