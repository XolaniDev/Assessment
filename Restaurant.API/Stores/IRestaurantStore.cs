using Restaurant.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.API.Stores
{
    public interface IRestaurantStore
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
       public Task<Restaurants> GetRestaurantByName(string name);
    }
}
