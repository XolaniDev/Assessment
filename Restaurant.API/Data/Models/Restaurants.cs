using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Restaurant.API.Data.Models
{
    public class Restaurants
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Key]
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "reservations")]
        public List<Reservation> Reservations { get; set; }
    }
}
