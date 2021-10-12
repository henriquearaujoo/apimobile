using Ailos.ApiMobile.Mediator.Contracts.v1.Commands;
using Ailos.Pix.Chave.Data;
using Ailos.Pix.Chave.DTO.Request;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ailos.ApiMobile.Mediator.Handlers
{
    public class KeyListCommandHandler : IRequestHandler<KeyListCommand, KeyListResponse>
    {
        private readonly IKeyDataService _dataService;

        public KeyListCommandHandler(IKeyDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<KeyListResponse> Handle(KeyListCommand request, CancellationToken cancellationToken)
        {
            var listRequest = new KeyListRequest
            {
                IdChave = request.IdChave,
                DescricaoChave = request.DescricaoChave,
                CodigoEnviado = request.CodigoEnviado,
                IdTransferePosse = request.IdTransferePosse,
                CodigoTipoChave = request.CodigoTipoChave,
                SituacaoChave = request.SituacaoChave
            };

            return await _dataService.ListAsync(listRequest, cancellationToken);
        }
    }
}
