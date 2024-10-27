using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatWebAspDotNetCoreApi.Data.ModelViews;

namespace TalabatWebAspDotNetCoreApi.Data.Repositories.Account
{
    public interface IServiceAccount<T>
    {
        public Task<ModelError> Add(T model);
    }
}
