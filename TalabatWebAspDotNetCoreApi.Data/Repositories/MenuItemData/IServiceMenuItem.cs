using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatWebAspDotNetCoreApi.Data.ModelViews;

namespace TalabatWebAspDotNetCoreApi.Data.Repositories.MenuItemData
{
    public interface IServiceMenuItem:IServiceData<DtoMenuItem>
    {
        public Task<ModelError> GetAll();
    }
}
