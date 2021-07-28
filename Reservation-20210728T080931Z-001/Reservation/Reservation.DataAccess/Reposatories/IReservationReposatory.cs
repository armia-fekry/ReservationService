using System.Collections.Generic;
using System.Threading.Tasks;
using Reservation.Models.DTOs;
namespace Reservation.DataAccess.Reposatories
{
    public interface IReservationReposatory
    {
        Task<ServiceResponse<IEnumerable<ReservationDto>>> GetAll();
        Task<ServiceResponse<ReservationDto>> GetById(int? id);
        Task<ServiceResponse<ReservationDto>> Add(ReservationDto reservation);
        Task<ServiceResponse<ReservationUpdateDto>> Update(ReservationUpdateDto reservation);
        Task<ServiceResponse<IEnumerable<ReservationDto>>> Delete(int? id);
    }
}
