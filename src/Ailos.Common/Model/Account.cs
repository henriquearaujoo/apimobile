using System;

namespace Ailos.Common.Model
{
    public class Account
    {
        public string Banco { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public string BancoIntegracao { get; set; }
        public string AgenciaIntegracao { get; set; }
        public string ContaIntegracao { get; set; }
        public string IdPessoa { get; set; }
        public string TipoPessoa { get; set; }
        public DateTime DataNascimento { get; set; }
        public string NomeTitular { get; set; }
        public string CpfCnpjCpfPre { get; set; }
        public string CpfCnpj { get; set; }
        public bool ContaMonitorada { get; set; }
        public int TitularId { get; set; }
        public int CooperativaId { get; set; }
        public short AgenciaId { get; set; }
        public int NumeroConta { get; set; }
        public short ContaLembrada { get; set; }
    }
}
