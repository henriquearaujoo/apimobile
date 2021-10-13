using Ailos.SOA.Common;

namespace Ailos.SOA.ParametersCard.DTO.Request
{
    public class ObterParamPreAprovadoCartaoRequest : BaseModel
    {
        public ObterParamPreAprovadoCartaoRequest(BaseModelSOARest baseModel) : base(baseModel)
        {
            PessoaCC = new PessoaCC(_baseModel);
            PessoaDigital = new PessoaDigital(_baseModel);
            CanalRelacionamento = new CanalRelacionamento();
            PostoAtendimento = new PostoAtendimento();
            UsuarioDominioCecred = new UsuarioDominioCecred();
            NrIP = _baseModel.NumeroIP;
        }

        public PessoaCC PessoaCC { get; private set; }

        public PessoaDigital PessoaDigital { get; private set; }

        public CanalRelacionamento CanalRelacionamento { private set; get; }

        public PostoAtendimento PostoAtendimento { private set; get; }

        public UsuarioDominioCecred UsuarioDominioCecred { private set; get; }

        public string NrIP { private set; get; }
    }
}