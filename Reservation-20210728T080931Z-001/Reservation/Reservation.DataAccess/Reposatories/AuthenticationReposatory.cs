using Reservation.Models;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Reservation.Models.DTOs;
using AutoMapper;

namespace Reservation.DataAccess
{
   public class AuthenticationReposatory : IAuthenticationReposatory
    {
        private readonly ReservationContext _context;
        private readonly IMapper mapper;

        public AuthenticationReposatory(ReservationContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<string>> Login(string Email, string password)
        {
            return new ServiceResponse<string>();
            
        }

        public async Task<ServiceResponse<UserDto>> Register(UserDto userDto)
        {
            var tuple =EncryptPassword(userDto.password);
            ServiceResponse<UserDto> serviceResponse = new ServiceResponse<UserDto>();
            if (await UserExsist(userDto.Email))
            {
                serviceResponse.succeed = false;
                serviceResponse.message = "user allready exsist try another E-mail";
                return serviceResponse;
            }
            User newUsr = mapper.Map<User>(userDto);
            newUsr.PasswordSalt = tuple.Item1;
            newUsr.PasswordHash = tuple.Item2;
            
            await _context.Users.AddAsync(newUsr);
            await _context.SaveChangesAsync();
            serviceResponse.Data =userDto ;
            return serviceResponse;

        }

        public async Task<bool> UserExsist(string email)
        {
            if (await _context.Users.AnyAsync(user=>user.Email.ToLower()==email.ToLower()))
            {
                return true;
            }
            return false;
        }

        private Tuple<byte[],byte[]> EncryptPassword(string password)
        {           
            using (var HMACSHA = new System.Security.Cryptography.HMACSHA512())
            {
               return Tuple.Create<byte[], byte[]>(HMACSHA.Key,
                    HMACSHA.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)));              
            }
        }
    }
}
