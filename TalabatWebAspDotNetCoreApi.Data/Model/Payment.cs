using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalabatWebAspDotNetCoreApi.Data.Model
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        public string PaymentMethod { get; set; } = string.Empty;

        public string PaymentStatus { get; set; } = string.Empty;

        // Foregin key properties
        public int OrderId { get; set; }
    }

    
}
