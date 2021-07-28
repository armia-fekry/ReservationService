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
    public class UpdateReservationHandler : IRequestHandler<UpdateReservationQueries, 
        ServiceResponse<ReservationUpdateDto>>
    {
        private readonly IReservationReposatory _reservationReposatory;

        public UpdateReservationHandler(IReservationReposatory reposatory)
        {
            this._reservationReposatory = reposatory;
        }

        public async Task<ServiceResponse<ReservationUpdateDto>> Handle(UpdateReservationQueries UpdateResrtvation, CancellationToken cancellationToken)
        {
            return await _reservationReposatory.Update(UpdateResrtvation.reservation);
        }
    }
}
