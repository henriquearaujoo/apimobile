using System;

namespace Ailos.Ailos.SOA.Loan.DTO.Common
{
    /// <summary>
    /// Objeto que representa uma aplicação
    /// </summary>
    public class Emprestimo
    {
        private int? _Contrato;
        private decimal? _ValorEmprestimo;
        private decimal? _SaldoDevedor;
        private DateTime? _DataLiberacao;
        private decimal? _ValorParcela;
        private int? _DiaVencimento;
        private string _DescricaoProduto;
        private int? _QuantidadeParcelas;
        private int? _ParcelasRestantes;
        private int? _NumeroRenegociacao;
        private string _LinhaCredito;
        private string _Finalidade;
        private string _Indexador;

        public int? Contrato
        {
            get { return _Contrato; }
            set { _Contrato = value; }
        }

        public decimal? ValorEmprestimo
        {
            get { return _ValorEmprestimo; }
            set { _ValorEmprestimo = value; }
        }

        public decimal? SaldoDevedor
        {
            get { return _SaldoDevedor; }
            set { _SaldoDevedor = value; }
        }

        public DateTime? DataLiberacao
        {
            get { return _DataLiberacao; }
            set { _DataLiberacao = value; }
        }

        public decimal? ValorParcela
        {
            get { return _ValorParcela; }
            set { _ValorParcela = value; }
        }

        public int? DiaVencimento
        {
            get { return _DiaVencimento; }
            set { _DiaVencimento = value; }
        }

        public string DescricaoProduto
        {
            get { return _DescricaoProduto; }
            set { _DescricaoProduto = value; }
        }

        public int? QuantidadeParcelas
        {
            get { return _QuantidadeParcelas; }
            set { _QuantidadeParcelas = value; }
        }

        public int? ParcelasRestantes
        {
            get { return _ParcelasRestantes; }
            set { _ParcelasRestantes = value; }
        }

        public string LinhaCredito
        {
            get { return _LinhaCredito; }
            set { _LinhaCredito = value; }
        }

        public string Finalidade
        {
            get { return _Finalidade; }
            set { _Finalidade = value; }
        }

        public string Indexador
        {
            get { return _Indexador; }
            set { _Indexador = value; }
        }

        public int? NumeroRenegociacao
        {
            get { return _NumeroRenegociacao; }
            set { _NumeroRenegociacao = value; }
        }
    }//end Emprestimo
}//end namespace Ailos.MobileBank.Models