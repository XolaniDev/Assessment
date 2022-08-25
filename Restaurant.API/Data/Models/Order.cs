using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Restaurant.API.Data.Models
{
    public class Order
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
        [ForeignKey("reservationId")]
        [DataMember(Name = "reservationId")]
        public int ReservationId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "description")]
        public string Description { get; set; }

    }
}
