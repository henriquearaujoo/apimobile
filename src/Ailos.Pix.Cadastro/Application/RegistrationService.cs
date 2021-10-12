using Ailos.Pix.Cadastro.Data;
using Ailos.Pix.Cadastro.DTO.Request;
using Ailos.Pix.Cadastro.DTO.Response;
using System;
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
        public async Task<ParametersResponse> ParametersList(ParametersRequest parametersRequest)
        {
            return await _registrationDataService.ParametersList(parametersRequest);
        }
    }
}
