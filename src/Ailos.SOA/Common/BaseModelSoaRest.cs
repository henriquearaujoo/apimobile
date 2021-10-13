using System;
using System.Text.Json.Serialization;

namespace Ailos.SOA.Common
{
    public class BaseModelSOARest
    {
        public BaseModelSOARest()
        {
            TipoUsuarioContaJuridica = "1";
            NumeroIP = "10.1.1.1";
        }

        [JsonIgnore]
        public string CooperativaCodigo { get; set; }

        [JsonIgnore]
        public string ContaCorrenteCodigo { get; set; }

        [JsonIgnore]
        public string ContaCorrenteNumeroTitularidade { get; set; }

        [JsonIgnore]
        public string CanalRelacionamentoCodigo { get; set; }

        [JsonIgnore]
        public string NumeroIP { get; set; }

        [JsonIgnore]
        public string TipoUsuarioContaJuridica { get; set; }

        [JsonIgnore]
        public string CPFUsuarioContaJuridica { get; set; }

        [JsonIgnore]
        public string IdPessoa { get; set; }

        [JsonIgnore]
        public string TipoPessoa { get; set; }

        [JsonIgnore]
        public string CpfCnpj { get; set; }

        [JsonIgnore]
        public string NomeTitular { get; set; }

        [JsonIgnore]
        public DateTime DataNascimento { get; set; }
    }
}