using Ailos.Common.DTO.Request;
using Ailos.Common.DTO.Response;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ailos.Common.Data
{
    public interface ICooperadoDataService
    {
        [Get("/ailos/pix/api/v1/cadastro/conta/{request.codigoCooperativa}/{request.numeroConta}/{request.codigoCanal}/{request.ipAcionamento}")]
        Task<CooperadoResponse> GetData(CooperadoRequest request, int idDispositivo);
    }
}
