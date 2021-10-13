using Ailos.SOA.Common;
using Ailos.SOA.Common.Card.Request;

namespace Ailos.SOA.CardAutorization.DTO.Request
{
    public class EfetivarSituacaoPropostaRequest : BaseModel
    {
        public EfetivarSituacaoPropostaRequest(BaseModelSOARest baseModel) : base(baseModel)
        {
            CanalRelacionamento = new CanalRelacionamento();
        }

        public PropostaCartaoRequest PropostaCartao { get; set; }

        public CartaoRequest Cartao { get; set; }

        public CanalRelacionamento CanalRelacionamento { get; private set; }
    }

    public class PropostaCartaoRequest : BaseModel
    {
        public PropostaCartaoRequest(BaseModelSOARest baseModel) : base(baseModel)
        {
            Emitente = new EmitenteRequest(baseModel);
        }

        public string IdentificadorProposta { get; set; }

        public string TipoInteracao { get; set; }

        public TipoRequest TipoLiquidacao { get; set; }

        public EmitenteRequest Emitente { get; private set; }

        public TipoRequest MotivoResultado { get; set; }
    }

    public class CartaoRequest
    {
        public int DiaVencimento { get; set; }
        public string NomeImpresso { get; set; }
        public EmbossadoraRequest Embossadora { get; set; }
    }

    public class EmbossadoraRequest
    {
        public string RazaoSocialOuNome { get; set; }
    }
}