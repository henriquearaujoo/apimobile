namespace Ailos.SOA.Common
{
    public class Cooperativa : BaseModel
    {
        public Cooperativa(BaseModelSOARest baseModel) : base(baseModel)
        {
        }

        public string Codigo
        {
            get { return _baseModel.CooperativaCodigo; }
        }
    }
}