using Ailos.ApiMobile.Mediator.Contracts.v1.Commands;
using Ailos.Pix.Cadastro.Data;
using Ailos.Pix.Cadastro.DTO.Request;
using Ailos.Pix.Cadastro.DTO.Response;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ailos.ApiMobile.Mediator.Handlers
{
    public class ParametersCommandHandler : IRequestHandler<ParametersCommand, ParametersResponse>
    {
        private readonly IRegistrationDataService _dataService;

        public ParametersCommandHandler(IRegistrationDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<ParametersResponse> Handle(ParametersCommand request, CancellationToken cancellationToken)
        {
            var paramRequest = new ParametersRequest
            {
                CodigoCanal = request.CodigoCanal,
                CodigoCooperativa = request.CodigoCooperativa,
                CodigoOperador = request.CodigoOperador,
                IdDispositivo = request.IdDispositivo,
                IpAcionamento = request.IpAcionamento
            };

            return await _dataService.ParametersListAsync(paramRequest, cancellationToken);
        }
    }
}
