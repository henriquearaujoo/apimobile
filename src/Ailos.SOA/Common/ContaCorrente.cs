namespace Ailos.SOA.Common
{
    public class ContaCorrente : BaseModel
    {
        public ContaCorrente(BaseModelSOARest baseModel) : base(baseModel)
        {
            Cooperativa = new Cooperativa(_baseModel);
        }

        public string CodigoConta
        {
            get { return _baseModel.ContaCorrenteCodigo; }
        }

        public Cooperativa Cooperativa { get; private set; }
    }
}