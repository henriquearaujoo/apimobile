using Ailos.Pix.Cadastro.DTO.Response;
using MediatR;

namespace Ailos.ApiMobile.Mediator.Contracts.v1.Commands
{
    public record ParametersCommand : IRequest<ParametersResponse>
    {
        public int CodigoCooperativa { get; init; }
        public int CodigoCanal { get; init; }
        public string IpAcionamento { get; init; }
        public string CodigoOperador { get; init; }
        public int IdDispositivo { get; init; }
    }
}
