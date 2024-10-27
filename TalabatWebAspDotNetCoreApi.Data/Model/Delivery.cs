using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalabatWebAspDotNetCoreApi.Data.Model
{
    public class Delivery
    {
        [Key]
        public int Id {  get; set; }

        [Required]
        public DateTime DeliveryTime { get; set; }

        public string DeliveryStatus { get; set; } = string.Empty;

        // Forgin key properties
        public int OrderId { get; set; }
        public string DeliveryPersonId { get; set; } = string.Empty;
    }

}
