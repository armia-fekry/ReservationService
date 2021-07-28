using AutoMapper;
using Reservation.Models;
using Reservation.Models.DTOs;
using Reservation.Models.Models;

namespace Reservation.DataAccess
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Trip, TripDto>();
            CreateMap<TripDto, Trip>();
            CreateMap<ReservationModel, ReservationDto>();
            CreateMap<ReservationDto, ReservationModel>();
            CreateMap<ReservationModel, ReservationUpdateDto>();
            CreateMap<ReservationUpdateDto,ReservationModel>();

        }
    }
}
