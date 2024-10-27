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
    public class DtoMenuItem
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Required]
        public double Price { get; set; }

        [Required]
        public string Category { get; set; } = string.Empty;

        public int RestaurantId { get; set; }
    }
}
