using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurant.API.Data;
using Restaurant.API.Data.Models;

namespace Restaurant.API.Stores
{
    public class OrderStore: IOrderStore
    {

        private readonly RestaurantDbContext _dbContext;

        public OrderStore(RestaurantDbContext restaurantDbContext)
        {
            _dbContext = restaurantDbContext;
        }

        public async Task<bool> PlaceOrder(Order orders)
        {
            bool exist = _dbContext.Orders
                .Where(x => x.Id == orders.Id)
                .ToList().Count > 0;

            if (exist) return false;

            _dbContext.Add(orders);
            var results = await _dbContext.SaveChangesAsync();
            return results > 0;

        }

     
    }
}
