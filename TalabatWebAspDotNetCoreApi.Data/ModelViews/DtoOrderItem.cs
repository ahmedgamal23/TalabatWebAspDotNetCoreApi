using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalabatWebAspDotNetCoreApi.Data.ModelViews
{
    public class DtoOrderItem
    {
        public int Quantity { get; set; }
        public double price { get; set; }

        // Foreign key properties
        public int OrderId { get; set; }
        public int MenuItemId { get; set; }
    }
}
