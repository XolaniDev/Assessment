using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurant.API.Controllers;
using Restaurant.API.Data.Models;
using Restaurant.API.Stores;

namespace Restaurant.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderStore _orderStore;

        public OrderService(IOrderStore orderStore)
        {
            _orderStore = orderStore;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        public async Task<bool> PlaceOrder(Order orders)
        {
            return await _orderStore.PlaceOrder(orders);
        }
    }
}
