using Ailos.Common.DTO.Request;
using Ailos.Common.DTO.Response;
using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Ailos.Common.Data
{
    public interface ICooperadoDataService
    {
        [Get("/ailos/pix/api/v1/cadastro/conta/{request.codigoCooperativa}/{request.numeroConta}/{request.codigoCanal}/{request.ipAcionamento}")]
        Task<CooperadoResponse> GetDataAsync(CooperadoRequest request, int idDispositivo, CancellationToken cancellationToken);
    }
}
