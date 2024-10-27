using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalabatWebAspDotNetCoreApi.Data.ModelViews
{
    public class DtoRegister
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string Email {  get; set; } = string.Empty ;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string Address {  get; set; } = string.Empty;

        [Required]
        public UserRole Role { get; set; }
    }

    public enum UserRole
    {
        Customer,
        Admin, 
        DeliveryPerson
    }
}
