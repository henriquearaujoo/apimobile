using Ailos.Pix.Cadastro.DTO.Request;
using Ailos.Pix.Cadastro.DTO.Response;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ailos.Pix.Cadastro.Data
{
    public interface IRegistrationDataService
    {
        [Get("/ailos/pix/api/v1/cadastro/parametro/{request.codigoCooperativa}/{request.codigoCanal}/{request.ipAcionamento}")]
        Task<ParametersResponse> ParametersListAsync(ParametersRequest request);
    }
}
