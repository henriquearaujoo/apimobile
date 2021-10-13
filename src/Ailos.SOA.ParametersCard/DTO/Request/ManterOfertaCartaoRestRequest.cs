using Ailos.SOA.Common;
using Ailos.SOA.ParametersCard.DTO.Common;

namespace Ailos.SOA.ParametersCard.DTO.Request
{
    public class ManterOfertaCartaoRestRequest : BaseModel
    {
        public ManterOfertaCartaoRestRequest(BaseModelSOARest baseModel) : base(baseModel)
        {
            PessoaCC = new PessoaCC(baseModel);
            CanalRelacionamento = new CanalRelacionamento();
        }

        public PessoaCC PessoaCC { get; private set; }

        public CanalRelacionamento CanalRelacionamento { get; private set; }

        public OfertaCartao OfertaCartao { get; set; }
    }
}