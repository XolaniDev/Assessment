using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant.API.Data;
using Restaurant.API.Data.Models;

namespace Restaurant.API.Stores
{
    public class RestaurantStore : IRestaurantStore
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly RestaurantDbContext _dbContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="restaurantDbContext"></param>
        public RestaurantStore(RestaurantDbContext restaurantDbContext)
        {
            _dbContext = restaurantDbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Restaurants> GetRestaurantByName(string name)
        {
            return await _dbContext.Restaurants
                .Include(x => x.Reservations)
                .ThenInclude(x => x.Orders)
                .Where(x => x.Name == name)
                .FirstOrDefaultAsync();
        }
    }
}
