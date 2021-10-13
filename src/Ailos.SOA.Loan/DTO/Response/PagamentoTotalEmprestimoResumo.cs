using System;

namespace Ailos.SOA.Loan.DTO.Response
{
    /// <summary>
    /// Objeto que representa os requisitos para consulta e confirmação de pagamento total de empréstimo
    ///
    /// </summary>
    public class PagamentoTotalEmprestimoResumo
    {
        /// <summary>
        /// Declaração das variáveis privadas
        /// </summary>
        private int _Contrato;

        private decimal? _SaldoContrato;
        private decimal? _ValorTotalDesconto;
        private decimal? _ValorTotalAtraso;
        private decimal? _ValorTotalPagamento;
        private DateTime? _DataDebito;
        private bool _IndicadorExibicaoTermo;
        private string _Termo;

        /// <summary>
        /// Inicia uma nova instância do objeto.
        /// </summary>
        public PagamentoTotalEmprestimoResumo()
        {
        }

        /// <summary>
        /// Número do contrato de empréstimo
        /// </summary>
        public int Contrato
        {
            get { return _Contrato; }
            set { _Contrato = value; }
        }

        /// <summary>
        /// SaldoContrato
        /// </summary>
        public decimal? SaldoContrato
        {
            get { return _SaldoContrato; }
            set { _SaldoContrato = value; }
        }

        /// <summary>
        /// ValorTotalDesconto
        /// </summary>
        public decimal? ValorTotalDesconto
        {
            get { return _ValorTotalDesconto; }
            set { _ValorTotalDesconto = value; }
        }

        /// <summary>
        /// ValorTotalAtraso
        /// </summary>
        public decimal? ValorTotalAtraso
        {
            get { return _ValorTotalAtraso; }
            set { _ValorTotalAtraso = value; }
        }

        /// <summary>
        /// ValorTotalPagamento
        /// </summary>
        public decimal? ValorTotalPagamento
        {
            get { return _ValorTotalPagamento; }
            set { _ValorTotalPagamento = value; }
        }

        /// <summary>
        /// DataDebito
        /// </summary>
        public DateTime? DataDebito
        {
            get { return _DataDebito; }
            set { _DataDebito = value; }
        }

        /// <summary>
        /// IndicadorExibicaoTermo
        /// </summary>
        public bool IndicadorExibicaoTermo
        {
            get { return _IndicadorExibicaoTermo; }
            set { _IndicadorExibicaoTermo = value; }
        }

        /// <summary>
        /// Termo
        /// </summary>
        public string Termo
        {
            get { return _Termo; }
            set { _Termo = value; }
        }
    }//end PagamentoTotalEmprestimoResumo
}//end namespace Models