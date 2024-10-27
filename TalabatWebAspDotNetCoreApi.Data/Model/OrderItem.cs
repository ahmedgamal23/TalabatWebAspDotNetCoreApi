using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalabatWebAspDotNetCoreApi.Data.Model
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public int Quantity { get; set; }
        public double price { get; set; }

        // Foreign key properties
        public int OrderId { get; set; }
        public int MenuItemId { get; set; }
    }
}
