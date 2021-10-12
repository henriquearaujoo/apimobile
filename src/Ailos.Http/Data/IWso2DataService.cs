using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ailos.Http.Data
{
    public interface IWso2DataService
    {
        [Post("/token?grant_type=client_credentials")]
        Task<TokenDTO> Authorize([Header("Authorization")] string key);
    }
}
