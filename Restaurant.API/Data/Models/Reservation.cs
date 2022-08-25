using Restaurant.API.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Restaurant.API.Data.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Reservation
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Key]
        [DataMember(Name = "reservationId")]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "tartDateTime")]
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "reservationStatusId")]
        public ReservationStatus ReservationStatusId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "orders")]
        public List<Order> Orders { get; set; }



    }
}
