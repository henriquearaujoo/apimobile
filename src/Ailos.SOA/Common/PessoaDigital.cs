namespace Ailos.SOA.Common
{
    public class PessoaDigital : BaseModel
    {
        public PessoaDigital(BaseModelSOARest baseModel) : base(baseModel)
        {
        }

        public string CpfUsuarioContaJuridica
        {
            get { return _baseModel.CPFUsuarioContaJuridica; }
        }

        public string LetrasSeguranca { get; set; }

        public string Senha { get; set; }
    }
}