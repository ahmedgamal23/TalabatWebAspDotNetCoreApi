using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatWebAspDotNetCoreApi.Data.ModelViews;

namespace TalabatWebAspDotNetCoreApi.Data.Repositories.Resturant
{
    public interface IServiceResturant:IServiceData<DtoResturant>
    {
        public Task<ModelError> GetAll();
    }
}
