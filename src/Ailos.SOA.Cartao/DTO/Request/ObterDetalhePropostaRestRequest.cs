using Ailos.SOA.Common;

namespace Ailos.SOA.Card.DTO.Request
{
    public class ObterDetalhePropostaRestRequest : BaseModel
    {
        public ObterDetalhePropostaRestRequest(BaseModelSOARest baseModel) : base(baseModel)
        {
            CanalRelacionamento = new CanalRelacionamento();
            PostoAtendimento = new PostoAtendimento();
            UsuarioDominioCecred = new UsuarioDominioCecred();
            NrIP = _baseModel.NumeroIP;
        }

        public PropostaCartaoDetalhesRequest PropostaCartao { get; set; }

        public CanalRelacionamento CanalRelacionamento { private set; get; }

        public PostoAtendimento PostoAtendimento { private set; get; }

        public UsuarioDominioCecred UsuarioDominioCecred { private set; get; }

        public string NrIP { private set; get; }
    }

    public class PropostaCartaoDetalhesRequest : BaseModel
    {
        public PropostaCartaoDetalhesRequest(BaseModelSOARest baseModel) : base(baseModel)
        {
            Emitente = new EmitenteRequest(baseModel);
        }

        public EmitenteRequest Emitente { get; private set; }
        public string IdentificadorProposta { get; set; }
    }
}