using Ailos.SOA.Common;

namespace Ailos.SOA.Card.DTO.Request
{
    public class ObterTermoAdesaoRequest : BaseModel
    {
        public ObterTermoAdesaoRequest(BaseModelSOARest baseModel) : base(baseModel)
        {
            PessoaDigital = new PessoaDigital(_baseModel);
            CanalRelacionamento = new CanalRelacionamento();
            PostoAtendimento = new PostoAtendimento();
            UsuarioDominioCecred = new UsuarioDominioCecred();
            NrIP = _baseModel.NumeroIP;
        }

        public PessoaDigital PessoaDigital { private set; get; }

        public CanalRelacionamento CanalRelacionamento { private set; get; }

        public PostoAtendimento PostoAtendimento { private set; get; }

        public UsuarioDominioCecred UsuarioDominioCecred { private set; get; }

        public string NrIP { private set; get; }
    }
}