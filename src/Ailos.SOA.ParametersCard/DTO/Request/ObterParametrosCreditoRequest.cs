using Ailos.SOA.Common;

namespace Ailos.SOA.ParametersCard.DTO.Request
{
    public partial class ObterParametrosCreditoRequest : BaseModel
    {
        public ObterParametrosCreditoRequest(BaseModelSOARest baseModel)
            : base(baseModel)
        {
            PropostaContratoCredito = new PropostaContratoCreditoParametrosCreditoRequest(baseModel);
            CanalRelacionamento = new CanalRelacionamento();
        }

        public PropostaContratoCreditoParametrosCreditoRequest PropostaContratoCredito { get; private set; }

        public CanalRelacionamento CanalRelacionamento { get; private set; }
    }

    public partial class PropostaContratoCreditoParametrosCreditoRequest : BaseModel
    {
        public PropostaContratoCreditoParametrosCreditoRequest(BaseModelSOARest baseModel)
            : base(baseModel)
        {
            Emitente = new EmitenteParametrosCredito(baseModel);
        }

        public EmitenteParametrosCredito Emitente { get; private set; }
    }

    public partial class EmitenteParametrosCredito : BaseModel
    {
        public EmitenteParametrosCredito(BaseModelSOARest baseModel)
            : base(baseModel)
        {
            ContaCorrente = new ContaCorrente(baseModel);
        }

        public ContaCorrente ContaCorrente { get; private set; }
    }
}