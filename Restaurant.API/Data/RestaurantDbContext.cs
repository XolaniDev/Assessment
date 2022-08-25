using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using Restaurant.API.Data.Models;

namespace Restaurant.API.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class RestaurantDbContext: DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<Restaurants> Restaurants { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<Order> Orders { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<Reservation> Reservations { get; set; }



    }
}
