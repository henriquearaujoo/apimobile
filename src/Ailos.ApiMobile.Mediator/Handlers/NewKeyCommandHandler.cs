using Ailos.ApiMobile.Mediator.Contracts.v1.Commands;
using Ailos.Pix.Chave.Data;
using Ailos.Pix.Chave.DTO.Request;
using Ailos.Pix.Chave.DTO.Response;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ailos.ApiMobile.Mediator.Handlers
{
    public class NewKeyCommandHandler : IRequestHandler<NewKeyCommand, NewKeyResponse>
    {
        private readonly IKeyDataService _dataService;

        public NewKeyCommandHandler(IKeyDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<NewKeyResponse> Handle(NewKeyCommand request, CancellationToken cancellationToken)
        {
            var newRequest = new NewKeyRequest
            {
                CodeType = request.CodeType,
                Description = request.Description,
                Favorite = request.Favorite,
                SessionID = request.SessionID
            };

            return await _dataService.AddAsync(newRequest, cancellationToken);
        }
    }
}
