using Ailos.SOA.Common;

namespace Ailos.SOA.DTO.Card.Request
{
    public class ObterListaPendenciasCartaoRequest : BaseModel
    {
        public ObterListaPendenciasCartaoRequest(BaseModelSOARest baseModel) : base(baseModel)
        {
            PessoaCC = new PessoaCC(baseModel);
            PessoaDigital = new PessoaDigital(baseModel);
            CanalRelacionamento = new CanalRelacionamento();
            PostoAtendimento = new PostoAtendimento();
            UsuarioDominioCecred = new UsuarioDominioCecred();
            NrIP = baseModel.NumeroIP;
        }

        public PessoaCC PessoaCC { get; private set; }

        public PessoaDigital PessoaDigital { get; private set; }

        public CanalRelacionamento CanalRelacionamento { get; private set; }

        public PostoAtendimento PostoAtendimento { get; private set; }

        public UsuarioDominioCecred UsuarioDominioCecred { get; private set; }

        public string NrIP { get; set; }
    }
}