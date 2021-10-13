using Ailos.Http;
using Ailos.SOA.Loan.DTO.Response;
using Ailos.SOA.ParametersCard.Application;
using Ailos.SOA.ParametersCard.DTO.Request;
using System.Linq;
using System.Threading.Tasks;

namespace Ailos.SOA.Loan.Application
{
    public class LoanService : ILoanService
    {
        private readonly IClient _SOAClient;
        private readonly IClient _WebSpeedClient;
        private readonly IParametersCardService _parametersCardService;

        public LoanService(IClient SOAClient, IClient WebSpeedClient, IParametersCardService parametersCardService)
        {
            _SOAClient = new SOAClient();
            _WebSpeedClient = new WebSpeedClient();
            _parametersCardService = parametersCardService;
        }

        public async Task<MotivosCancelamentoSolicitacaoResponse> GetSolicitCancellationReason()
        {
            var request = new ObterParametrosCreditoRequest(GetBaseModelSOARest());

            var result = await _parametersCardService.GetCreditParameters(request);

            return new MotivosCancelamentoSolicitacaoResponse
            {
                Motivos = result.ListaMotivosAnulacaoProposta.PropostaContratoCredito.Select(x => new MotivoCancelamentoSolicitacao
                {
                    Codigo = x.MotivoAnulacao.Codigo,
                    Descricao = x.MotivoAnulacao.Descricao
                }).ToList()
            };
        }
    }
}