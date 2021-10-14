using Ailos.Pix.Cadastro.DTO.Request;
using Ailos.Pix.Cadastro.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ailos.Pix.Cadastro.Application
{
    public interface IRegistrationService
    {
        Task<ParametersResponse> ParametersListAsync(ParametersRequest parametersRequest);
    }
}
