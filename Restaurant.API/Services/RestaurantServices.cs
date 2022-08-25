using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurant.API.Data.Models;
using Restaurant.API.Stores;

namespace Restaurant.API.Services
{
    public class RestaurantServices : IRestaurantService
    {

        private readonly IRestaurantStore _restaurantStore;


        public RestaurantServices(IRestaurantStore restaurantStore)
        {
            _restaurantStore = restaurantStore;
        }

        public async Task<Restaurants> GetRestaurantByName(string name)
        {
           return await _restaurantStore.GetRestaurantByName(name);
        }
    }
}
