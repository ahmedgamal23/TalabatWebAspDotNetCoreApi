using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatWebAspDotNetCoreApi.Data.Model;

namespace TalabatWebAspDotNetCoreApi.Data.ModelViews
{
    public class DtoOrder
    {
        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public double TotalAmount { get; set; }

        [Required]
        public OrderStatus OrderStatus { get; set; }

        // Foreign key properties
        public int OrderItemId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int RestaurantId { get; set; }
    }

    public enum OrderStatus
    {
        Pending,
        Confirmed,
        Delivered
    }
}
