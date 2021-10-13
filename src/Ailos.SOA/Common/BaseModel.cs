using System.Text.Json.Serialization;

namespace Ailos.SOA.Common
{
    public class BaseModel
    {
        [JsonIgnore]
        protected BaseModelSOARest _baseModel;

        public BaseModel(BaseModelSOARest baseModel)
        {
            _baseModel = baseModel;
        }
    }
}