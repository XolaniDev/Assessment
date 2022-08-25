using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant.API.Data;
using Restaurant.API.Data.Models;

namespace Restaurant.API.Stores
{
    public class ReservationStore: IReservationStore
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly RestaurantDbContext _DbContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="restaurantDbContext"></param>
        public ReservationStore(RestaurantDbContext restaurantDbContext)
        {
            _DbContext = restaurantDbContext;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        public async Task<bool> CreateReservation(Reservation reservation)
        {
            bool exist = _DbContext.Reservations
                .Where(x => x.Id == reservation.Id)
                .ToList().Count > 0;

            if (exist)
            {
                return false;
            }

            _DbContext.Add(reservation);
            var result = await _DbContext.SaveChangesAsync();
            return result > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Reservation>> GetReservations()
        {
            return await _DbContext.Reservations
                .Include(x => x.Orders)
                .ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="updateReservation"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Reservation> UpdateReservation(Reservation updateReservation, int id)
        {
            var existingReservation = await _DbContext.Reservations.FirstOrDefaultAsync(x => x.Id == id);

            existingReservation.Description = updateReservation.Description;
            existingReservation.ReservationStatusId = updateReservation.ReservationStatusId;
            existingReservation.StartDateTime = updateReservation.StartDateTime;
            existingReservation.Orders = updateReservation.Orders;

            await _DbContext.SaveChangesAsync();

            return existingReservation;
        }
    }
}
