using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalabatWebAspDotNetCoreApi.Data.ModelViews
{
    public class DtoPayment
    {
        [Required]
        public DateTime PaymentDate { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        // Foregin key properties
        public int OrderId { get; set; }
    }

    public enum PaymentMethod
    {
        CreditCard,
        Cash,
        Online
    }

    public enum PaymentStatus
    {
        Pending,
        Completed,
        Failed
    }
}
