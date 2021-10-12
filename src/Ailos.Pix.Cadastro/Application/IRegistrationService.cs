using Ailos.Pix.Cadastro.DTO.Request;
using Ailos.Pix.Cadastro.DTO.Response;
using System.Threading;
using System.Threading.Tasks;

namespace Ailos.Pix.Cadastro.Application
{
    public interface IRegistrationService
    {
        Task<ParametersResponse> ParametersListAsync(ParametersRequest parametersRequest, CancellationToken cancellationToken);
    }
}
