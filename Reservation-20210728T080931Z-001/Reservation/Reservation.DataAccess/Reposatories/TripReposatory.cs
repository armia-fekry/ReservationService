using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Reservation.Models.DTOs;
using Reservation.Models.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace Reservation.DataAccess.Reposatories
{
    public class TripReposatory : ITripReposatory
    {
        private readonly ReservationContext _reservationContext;
        private readonly IMapper _mapper;
        public TripReposatory(ReservationContext reservation, IMapper mapper)
        {
            _mapper = mapper;
            _reservationContext = reservation;
        }

        public async Task<ServiceResponse<TripDto>> Add(TripDto trip)
        {
            ServiceResponse<TripDto> TripResponse = new ServiceResponse<TripDto>();
            try
            {
                await _reservationContext.Trips.AddAsync(_mapper.Map<Trip>(trip));
                TripResponse.Data = trip;
                await _reservationContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                TripResponse.succeed = false;
                TripResponse.message = $"error in adding Trip  {trip.Name}";
            }
            
            return TripResponse;
        }

        public async Task<ServiceResponse<IEnumerable<TripDto>>> Delete(int? id)
        {
            ServiceResponse<IEnumerable<TripDto>> TripResponse = 
                  new ServiceResponse<IEnumerable<TripDto>>();
            try
            {
              var trip = await _reservationContext.Trips.SingleOrDefaultAsync
                                    (T => T.TripId == id);
                if (trip is null)
                {
                    TripResponse.message = "not found";
                    TripResponse.succeed = false;
                    
                }
                else
                {
                    _reservationContext.Trips.Remove(trip);
                    TripResponse.Data = _reservationContext.Users
                           .Select(T => _mapper.Map<TripDto>(T));
                    await _reservationContext.SaveChangesAsync();

                }
                
            }
            catch (Exception)
            {
                TripResponse.succeed = false;
                TripResponse.message = $"error in delete Trip  {id}";
            }
            return TripResponse;
        }
        public async Task<ServiceResponse<IEnumerable<TripDto>>> GetAll()
        {
            ServiceResponse<IEnumerable<TripDto>> TripResponse = new ServiceResponse<IEnumerable<TripDto>>();
            TripResponse.Data = await _reservationContext.Trips.Select(T => _mapper.Map<TripDto>(T)).ToListAsync();
            return TripResponse;
        }

        public async Task<ServiceResponse<TripDto>> GetByName(string name)
        {
            ServiceResponse<TripDto> TripResponse = new ServiceResponse<TripDto>();

            try
            {
                TripResponse.Data = _mapper.Map<TripDto>(
               await _reservationContext.Trips.SingleOrDefaultAsync(T => T.Name.ToLower() == name.ToLower()));
            }
            catch (Exception)
            {
                TripResponse.succeed = false;
                TripResponse.message = $"error in update Trip  {name}";
            }           
            return TripResponse;
        }

        public async Task<ServiceResponse<TripDto>> Update(TripDto trip)
        {
            ServiceResponse<TripDto> TripResponse = new ServiceResponse<TripDto>();
            try
            {
                Trip oldtrip = await _reservationContext.Trips.
                     SingleOrDefaultAsync(T => T.Name.ToLower() == trip.Name.ToLower());
                oldtrip.CityName = trip.CityName;
                oldtrip.Content = trip.Content;
                oldtrip.CreationDate = trip.CreationDate;
                oldtrip.ImageUrl = trip.ImageUrl;
                oldtrip.Price = trip.Price;
                TripResponse.Data = _mapper.Map<TripDto>(oldtrip);
                _reservationContext.Trips.Update(oldtrip);
                await _reservationContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                TripResponse.succeed = false;
                TripResponse.message = $"error in update Trip {trip.Name}";
            }
            return TripResponse;

        }

    }
}
