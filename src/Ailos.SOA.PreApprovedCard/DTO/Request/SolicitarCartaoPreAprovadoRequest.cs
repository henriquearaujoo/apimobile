using Ailos.SOA.Common;
using System;

namespace Ailos.SOA.PreApprovedCard.DTO.Request
{
    public partial class SolicitarCartaoPreAprovadoRequest : BaseModel
    {
        public SolicitarCartaoPreAprovadoRequest(BaseModelSOARest baseModel)
            : base(baseModel)
        {
            CanalRelacionamento = new CanalRelacionamento();
            PostoAtendimento = new PostoAtendimento();
            UsuarioDominioCecred = new UsuarioDominioCecred();
            InteracaoGrafica = new InteracaoGrafica();
            NrIP = baseModel.NumeroIP;
        }

        public PropostaCartaoSolicitacaoRequest PropostaCartao { get; set; }

        public CartaoSolicitacaoRequest Cartao { get; set; }

        public PessoaDocumentoSolicitacaoRequest PessoaDocumento { get; set; }

        public PessoaDigital PessoaDigital { get; set; }

        public CanalRelacionamento CanalRelacionamento { get; private set; }

        public PostoAtendimento PostoAtendimento { get; private set; }

        public UsuarioDominioCecred UsuarioDominioCecred { get; private set; }

        public EnderecoCooperadoSolicitacaoRequest EnderecoCooperado { get; set; }

        public InteracaoGrafica InteracaoGrafica { get; private set; }

        public ParametrosPropostaCartaoRequest ParametrosPropostaCartao { get; set; }

        public string NrIP { get; private set; }
    }

    public partial class PropostaCartaoSolicitacaoRequest
    {
        public TipoRequest TipoLiquidacao { get; set; }

        public EmitenteSolicitacaoRequest Emitente { get; set; }
    }

    public partial class EmitenteSolicitacaoRequest : BaseModel
    {
        public EmitenteSolicitacaoRequest(BaseModelSOARest baseModel)
            : base(baseModel)
        {
            ContaCorrente = new ContaCorrente(baseModel);
            Tipo = new TipoPessoaSolicitacaoRequest(baseModel);
            NumeroTitularidade = baseModel.ContaCorrenteNumeroTitularidade;
            RazaoSocialOuNome = baseModel.NomeTitular;
        }

        public ContaCorrente ContaCorrente { get; private set; }
        public TipoPessoaSolicitacaoRequest Tipo { get; private set; }
        public DateTime DataNascOuConstituicao { get; set; }
        public string IdentificadorReceitaFederal { get; set; }
        public string NumeroTitularidade { get; private set; }
        public string RazaoSocialOuNome { get; private set; }
    }

    public partial class CartaoSolicitacaoRequest
    {
        public CartaoSolicitacaoRequest()
        {
            Tipo = new TipoRequest
            {
                Codigo = 2
            };
        }

        public string Descricao { get; set; }

        public int DiaVencimento { get; set; }

        public string NomeImpresso { get; set; }

        public EmbossadoraSolicitacaoRequest Embossadora { get; set; }

        public TipoRequest Tipo { get; private set; }

        public TipoDescricaoRequest TipoModalidade { get; set; }

        public double ValorLimiteCredito { get; set; }

        public double ValorLimiteDebito { get; set; }
    }

    public partial class EmbossadoraSolicitacaoRequest
    {
        public string RazaoSocialOuNome { get; set; }
    }

    public partial class TipoPessoaSolicitacaoRequest : BaseModel
    {
        public TipoPessoaSolicitacaoRequest(BaseModelSOARest baseModel)
            : base(baseModel)
        {
            Codigo = baseModel.TipoPessoa;
        }

        public string Codigo { get; set; }
    }

    public partial class EnderecoCooperadoSolicitacaoRequest
    {
        public int TipoEnvio { get; set; }

        public PessoaContatoEnderecoSolicitacaoRequest PessoaContatoEndereco { get; set; }

        public TipoRequest PostoAtendimento { get; set; }
    }

    public partial class PessoaContatoEnderecoSolicitacaoRequest
    {
        public TipoRequest TipoEndereco { get; set; }
    }

    public partial class ParametrosPropostaCartaoRequest
    {
        public string IdLimitePreAprovado { get; set; }

        public string TipoConfiguracaoLimite { get; set; }

        public bool IndImprimePromissoria { get; set; }
    }

    public partial class PessoaDocumentoSolicitacaoRequest
    {
        public string Identificador { get; set; }
        public TipoSigla Tipo { get; set; }
    }

    public partial class TipoSigla
    {
        public string Sigla { get; set; }
    }
}