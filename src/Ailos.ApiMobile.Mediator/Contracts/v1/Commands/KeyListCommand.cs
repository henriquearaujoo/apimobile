using Ailos.Pix.Chave.DTO.Request;
using MediatR;
using System.Collections.Generic;

namespace Ailos.ApiMobile.Mediator.Contracts.v1.Commands
{
    public record KeyListCommand : IRequest<KeyListResponse>
    {
        public int IdChave { get; init; }
        public string DescricaoChave { get; init; }
        public int CodigoEnviado { get; init; }
        public int IdTransferePosse { get; init; }
        public int CodigoTipoChave { get; init; }
        public IEnumerable<int> SituacaoChave { get; init; }
    }
}
