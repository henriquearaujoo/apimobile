namespace Ailos.SOA.Common
{
    public class Pessoa : BaseModel
    {
        public Pessoa(BaseModelSOARest baseModel)
            : base(baseModel)
        {
            Tipo = new TipoRequest
            {
                Codigo = long.Parse(baseModel.TipoPessoa)
            };
        }

        public TipoRequest Tipo { get; private set; }
    }
}