using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatWebAspDotNetCoreApi.Data.ModelViews;

namespace TalabatWebAspDotNetCoreApi.Data.Repositories.ReviewData
{
    public interface IServiceReview:IServiceData<DtoReview>
    {
        public Task<ModelError> GetAll();
    }
}
