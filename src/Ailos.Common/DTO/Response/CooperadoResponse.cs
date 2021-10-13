using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ailos.Common.DTO.Response
{
    public record CooperadoResponse
    {
        public string SourceId { get; init; }
        public string Banco { get; init; }
        public string Agencia { get; init; }
        public string Conta { get; init; }
        public string BancoIntegracao { get; init; }
        public string AgenciaIntegracao { get; init; }
        public string ContaIntegracao { get; init; }
        public int IdPessoa { get; init; }
        public int TipoPessoa { get; init; }
        public DateTime DataNascimento { get; init; }
        public string NomeTitular { get; init; }
        public bool ContaMonitorada { get; init; }
        public string CpfCnpj { get; init; }
    }
}
