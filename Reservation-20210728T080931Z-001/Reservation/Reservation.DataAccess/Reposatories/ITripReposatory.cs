using Reservation.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reservation.DataAccess.Reposatories
{
    public interface ITripReposatory
    {
        Task<ServiceResponse<IEnumerable<TripDto>>> GetAll();
        Task<ServiceResponse<TripDto>> GetByName(string name);
        Task<ServiceResponse<TripDto>> Add(TripDto trip);
        Task<ServiceResponse<TripDto>> Update(TripDto trip);
        Task<ServiceResponse<IEnumerable<TripDto>>> Delete(int? id);

    }
}
