using Restaurant.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.API.Services
{
    public interface IOrderService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
      public  Task<bool> PlaceOrder(Order orders);
    }
}
