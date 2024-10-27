using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatWebAspDotNetCoreApi.Data.Model;

namespace TalabatWebAspDotNetCoreApi.Data.ModelViews
{
    public class DtoResturant
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Required]
        public string Location { get; set; } = string.Empty;

        [Required]
        public TimeOnly OpeningHours { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }
    }
}
