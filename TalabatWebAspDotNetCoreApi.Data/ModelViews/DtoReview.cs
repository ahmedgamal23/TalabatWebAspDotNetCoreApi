using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalabatWebAspDotNetCoreApi.Data.ModelViews
{
    public class DtoReview
    {
        [Range(1, 5)]
        public int Rating { get; set; }

        [Required]
        public string Comment { get; set; } = string.Empty;

        [Required]
        public DateTime ReviewDate { get; set; }

        // Foregin key properties
        public string UserId { get; set; } = string.Empty;
        public int RestaurantId { get; set; }
    }
}
