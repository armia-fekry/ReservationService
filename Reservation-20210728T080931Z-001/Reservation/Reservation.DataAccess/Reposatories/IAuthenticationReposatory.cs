using Reservation.Models;
using Reservation.Models.DTOs;
using System.Threading.Tasks;

namespace Reservation.DataAccess
{
    public interface IAuthenticationReposatory
    {
        Task<ServiceResponse<string>> Login(string Email, string password);
        Task<ServiceResponse<UserDto>> Register(UserDto userDTO);
        Task<bool> UserExsist(string email);
    }
}
