using Ailos.Pix.Cadastro.Data;
using Ailos.Pix.Cadastro.DTO.Request;
using Ailos.Pix.Cadastro.DTO.Response;
using System.Threading;
using System.Threading.Tasks;

namespace Ailos.Pix.Cadastro.Application
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationDataService _registrationDataService;

        public RegistrationService(IRegistrationDataService registrationDataService)
        {
            _registrationDataService = registrationDataService;
        }
        public async Task<ParametersResponse> ParametersListAsync(ParametersRequest parametersRequest, CancellationToken cancellationToken)
        {
            return await _registrationDataService.ParametersListAsync(parametersRequest, cancellationToken);
        }
    }
}
