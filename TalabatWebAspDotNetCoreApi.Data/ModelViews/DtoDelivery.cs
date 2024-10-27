using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalabatWebAspDotNetCoreApi.Data.ModelViews
{
    public class DtoDelivery
    {
        [Required]
        public DateTime DeliveryTime { get; set; }

        public DeliveryStatus DeliveryStatus { get; set; }

        // Forgin key properties
        public int OrderId { get; set; }
        public string DeliveryPersonId { get; set; } = string.Empty;
    }

    public enum DeliveryStatus
    {
        Assigned,
        InTransit,
        Delivered
    }
}
