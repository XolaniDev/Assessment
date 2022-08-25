using Restaurant.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.API.Stores
{
    public interface IReservationStore
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        public Task<bool> CreateReservation(Reservation reservation);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<List<Reservation>> GetReservations();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="updateReservation"></param>
        /// <param name="id"></param>
        /// <returns></returns>
       public Task<Reservation> UpdateReservation(Reservation updateReservation, int id);
    }
}
