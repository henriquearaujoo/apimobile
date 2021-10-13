using Ailos.SOA.Common;

namespace Ailos.SOA.ParametersCard.DTO.Request
{
    public class ObterParametrosNovaSolicRequest : BaseModel
    {
        public ObterParametrosNovaSolicRequest(BaseModelSOARest baseModel) : base(baseModel)
        {
            PessoaCC = new PessoaCC(_baseModel);
            PessoaDigital = new PessoaDigital(_baseModel);
            CanalRelacionamento = new CanalRelacionamento();
            PostoAtendimento = new PostoAtendimento();
            UsuarioDominioCecred = new UsuarioDominioCecred();
            ConfiguracaoCartao = new ConfiguracaoCartao();
            NrIP = _baseModel.NumeroIP;
        }

        public PessoaCC PessoaCC { get; private set; }

        public PessoaDigital PessoaDigital { get; private set; }

        public CanalRelacionamento CanalRelacionamento { get; private set; }

        public PostoAtendimento PostoAtendimento { get; private set; }

        public UsuarioDominioCecred UsuarioDominioCecred { get; private set; }

        public ConfiguracaoCartao ConfiguracaoCartao { get; set; }

        public string NrIP { get; private set; }
    }

    public partial class ConfiguracaoCartao
    {
        public ConfiguracaoCartao()
        {
            TipoLimite = new TipoLimite();
        }

        public TipoLimite TipoLimite { get; private set; }
    }

    public partial class TipoLimite
    {
        public long Codigo
        {
            get { return Constants.ConfiguracaoCartao.TipoLimite.PreAprovado; }
        }
    }
}