using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatWebAspDotNetCoreApi.Data.ModelViews;

namespace TalabatWebAspDotNetCoreApi.Data.Repositories.DeliveryData
{
    public interface IServiceDelivery:IServiceData<DtoDelivery>
    {
        public Task<ModelError> GetAll();
    }
}
