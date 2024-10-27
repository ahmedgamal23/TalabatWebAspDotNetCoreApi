using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalabatWebAspDotNetCoreApi.Data.Model
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        public string Role { get; set; } = string.Empty;
    }
}
