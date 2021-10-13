using Ailos.SOA.Loan.Application;
using Ailos.SOA.Loan.DTO.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ailos.ApiMobile.Controllers.Api.SOA.Loan
{
    public class LoanController
    {
        private readonly ILoanService _loanService;

        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpGet]
        [Route("api/Emprestimo/Solicitacao/MotivosCancelamento")]
        public async Task<MotivosCancelamentoSolicitacaoResponse> GetSolicitCancellationReason()
        {
            return await _loanService.GetSolicitCancellationReason();
        }
    }
}