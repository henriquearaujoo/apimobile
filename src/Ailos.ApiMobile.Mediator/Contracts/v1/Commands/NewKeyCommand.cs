using Ailos.Pix.Chave.DTO.Response;
using MediatR;

namespace Ailos.ApiMobile.Mediator.Contracts.v1.Commands
{
    public record NewKeyCommand : IRequest<NewKeyResponse>
    {
        public int CodeType { get; init; }

        public string Description { get; init; }

        public bool Favorite { get; init; }

        public string SessionID { get; init; }
    }
}
