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
    public class GetAllReservationsHandler : IRequestHandler<GetAllReservationsQueries, 
             ServiceResponse<IEnumerable<ReservationDto>>>
    {
        private readonly IReservationReposatory _ReservationReposatory;

        public GetAllReservationsHandler(IReservationReposatory reposatory)
        {
            this._ReservationReposatory = reposatory;
        }
       

        public async Task<ServiceResponse<IEnumerable<ReservationDto>>> Handle(GetAllReservationsQueries request, CancellationToken cancellationToken)
        {
            return await _ReservationReposatory.GetAll();
        }
    }
}
