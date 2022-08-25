using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurant.API.Data.Models;
using Restaurant.API.Stores;

namespace Restaurant.API.Services
{
    public class ReservationService: IReservationService
    {
        private readonly IReservationStore _reservationStore;

        public ReservationService(IReservationStore reservationStore)
        {
            _reservationStore = reservationStore;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        public Task<bool> CreateReservation(Reservation reservation)
        {
            return _reservationStore.CreateReservation(reservation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Reservation>> GetReservations()
        {
            return await _reservationStore.GetReservations();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="updateReservation"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Reservation> UpdateReservation(Reservation updateReservation, int id)
        {
            return await _reservationStore.UpdateReservation(updateReservation, id);
        }
    }
}
