using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalabatWebAspDotNetCoreApi.Data.ModelViews
{
    public class ModelError
    {
        public bool IsError { get; set; }
        public string? Message { get; set; }
        public IEnumerable<IdentityError>? identityErrors { get; set; }
        public Object? tokenObject { get; set; }
        public Object? Data { get; set; }
    }
}
