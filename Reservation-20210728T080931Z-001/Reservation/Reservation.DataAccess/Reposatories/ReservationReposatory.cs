using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Reservation.Models.DTOs;
using Reservation.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.DataAccess.Reposatories
{
    public class ReservationReposatory : IReservationReposatory
    {
        private readonly ReservationContext _reservationContext;
        private readonly IMapper _mapper;

        public ReservationReposatory(ReservationContext context,IMapper mapper)
        {
            this._reservationContext = context;
            this._mapper = mapper;
        }
        public async Task<ServiceResponse<ReservationDto>> Add(ReservationDto resrvationDto)
        {
            ServiceResponse<ReservationDto> ReservationResponse = new ServiceResponse<ReservationDto>();
            try
            {
                await _reservationContext.Reservations.AddAsync
                            (_mapper.Map<ReservationModel>(resrvationDto));
                ReservationResponse.Data = resrvationDto;
                await _reservationContext.SaveChangesAsync();
            }
            catch (Exception Ex)
            {
                ReservationResponse.succeed = false;
                ReservationResponse.message = $"error in adding Reservation  {Ex.Message}";
            }

            return ReservationResponse;
        }

        public async Task<ServiceResponse<IEnumerable<ReservationDto>>> Delete(int? id)
        {

            ServiceResponse<IEnumerable<ReservationDto>> ReservationRespoanse =
                  new ServiceResponse<IEnumerable<ReservationDto>>();
            try
            {
                var reservation = await _reservationContext.Reservations.SingleOrDefaultAsync
                                      (T => T.ResevationId == id);
                _reservationContext.Reservations.Remove(reservation);
                ReservationRespoanse.Data = _reservationContext.Users
                       .Select(T => _mapper.Map<ReservationDto>(T));
                await _reservationContext.SaveChangesAsync();
            }
            catch (Exception Ex)
            {
                ReservationRespoanse.succeed = false;
                ReservationRespoanse.message = $"error in delete Reservation  {id} Error {Ex.Message}";
            }
            return ReservationRespoanse;
        }

        public async Task<ServiceResponse<IEnumerable<ReservationDto>>> GetAll()
        {
            ServiceResponse<IEnumerable<ReservationDto>> ReservationResponse = 
                new ServiceResponse<IEnumerable<ReservationDto>>();
            try
            {
                ReservationResponse.Data = await _reservationContext.Reservations.Include(
                    e=>e.User).
                    Include(e=>e.Trip).Select
                                (T => _mapper.Map<ReservationDto>(T)).ToListAsync();
            }
            catch (Exception Ex)
            {
                ReservationResponse.succeed = false;
                ReservationResponse.message = $"error in adding Reservations error {Ex.Message}";
            }
            return ReservationResponse;

        }

        public async Task<ServiceResponse<ReservationDto>> GetById(int? id)
        {
            ServiceResponse<ReservationDto> ReservationResponse = new ServiceResponse<ReservationDto>();

            try
            {
                ReservationResponse.Data = _mapper.Map<ReservationDto>(
               await _reservationContext.Reservations.SingleOrDefaultAsync(T => T.ResevationId
                        == id));
            }
            catch (Exception Ex)
            {
                ReservationResponse.succeed = false;
                ReservationResponse.message = $"error in update Reservation  {id}";
            }
            return ReservationResponse;
        }

        public async Task<ServiceResponse<ReservationUpdateDto>> Update(ReservationUpdateDto reservation)
        {
            ServiceResponse<ReservationUpdateDto> ReservationResponse = new ServiceResponse<ReservationUpdateDto>();
            try
            {
                ReservationModel oldReservation = await _reservationContext.Reservations.
                     SingleOrDefaultAsync(T => T.ResevationId == reservation.reservationId);
                oldReservation.TripId = reservation.TripId;
                oldReservation.CreationDate = reservation.CreationDate;
                oldReservation.ReservationDate = reservation.ReservationDate;
                oldReservation.ReservedBy = reservation.ReservedBy;
                oldReservation.Notes = reservation.Notes;
                oldReservation.CustomerName = reservation.CustomerName;


                ReservationResponse.Data = _mapper.Map<ReservationUpdateDto>(oldReservation);
                _reservationContext.Reservations.Update(oldReservation);
                await _reservationContext.SaveChangesAsync();
            }
            catch (Exception Ex)
            {
                ReservationResponse.succeed = false;
                ReservationResponse.message = $"error in update reservation {reservation.reservationId} error {Ex.Message}";
            }
            return ReservationResponse;

        }
    }
}
