using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatWebAspDotNetCoreApi.Data.ModelViews;

namespace TalabatWebAspDotNetCoreApi.Data.Repositories
{
    public interface IServiceData<T>
    {
        public Task<ModelError> GetElement(int id);
        public Task<ModelError> Add(T model);
        public Task<ModelError> Update(int id, T model);
        public Task<ModelError> Delete(int id);
    }
}
