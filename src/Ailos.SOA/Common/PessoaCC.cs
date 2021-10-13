namespace Ailos.SOA.Common
{
    public class PessoaCC : BaseModel
    {
        public PessoaCC(BaseModelSOARest baseModel) : base(baseModel)
        {
            ContaCorrente = new ContaCorrente(baseModel);
            IdentificadorReceitaFederal = baseModel.CpfCnpj;
            NumeroTitularidade = baseModel.ContaCorrenteNumeroTitularidade;
            IdentificadorCadastro = baseModel.IdPessoa;
        }

        public ContaCorrente ContaCorrente { get; private set; }

        public string IdentificadorReceitaFederal { get; set; }

        public string NumeroTitularidade { get; set; }

        public string IdentificadorCadastro { get; set; }

        public int quantidadeMinimaAssinatura { get; set; }
    }
}