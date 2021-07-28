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
    public class DeleteReservationHandler : IRequestHandler<DeleteReservationQueries,
        ServiceResponse<IEnumerable<ReservationDto>>>
    {
        private readonly IReservationReposatory _reservationReposatory;

        public DeleteReservationHandler(IReservationReposatory reposatory)
        {
            this._reservationReposatory = reposatory;
        }

        public async Task<ServiceResponse<IEnumerable<ReservationDto>>> Handle(DeleteReservationQueries deleteReservation, CancellationToken cancellationToken)
        {
            return await _reservationReposatory.Delete(deleteReservation._id);
        }
    }
}
