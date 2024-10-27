using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatWebAspDotNetCoreApi.Data.ModelViews;

namespace TalabatWebAspDotNetCoreApi.Data.Repositories.OrderItemData
{
    public interface IServiceOrderItem:IServiceData<DtoOrderItem>
    {
        public Task<ModelError> GetAll();
    }
}
