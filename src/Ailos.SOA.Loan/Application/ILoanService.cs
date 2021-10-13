using Ailos.SOA.Common;
using Ailos.SOA.Loan.DTO.Response;
using System.Threading.Tasks;

namespace Ailos.SOA.Loan.Application
{
    public interface ILoanService
    {
        Task<MotivosCancelamentoSolicitacaoResponse> GetSolicitCancellationReason();

        EmprestimosResumo Consultar();

        PagamentoTotalEmprestimoResumo ConsultarResumoPagamentoTotal(PagamentoEmprestimoReq PagamentoTotalReq);

        MensagemRetorno ConfirmarPagamentoTotal(PagamentoEmprestimoReq PagamentoTotalReq);

        PagamentoParcialEmprestimoResumo ConsultarDadosPagamentoParcela(PagamentoEmprestimoReq ConsultarDadosReq);

        CalcularPagamentoParcelaResumo CalcularPagamentoParcela(CalcularPagamentoParcelaReq CalcularReq);

        ConsultarPagamentoParcelaResumo ConsultarResumoPagamentoParcelas(CalcularPagamentoParcelaResumo ConsultarParcelasReq);

        MensagemRetorno ConfirmarPagamentoParcelas(PagamentoParcelasEmprestimoReq PagamentoParcelasReq);

        MensagemRetorno SolicitarCredito(SolicitarCreditoReq SolicitarCreditoReq);
    }
}