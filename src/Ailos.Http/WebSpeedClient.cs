using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ailos.Http
{
    public class WebSpeedClient : IClient
    {
        public Task<T> Delete<T>(string url, object body, Dictionary<string, object> queryParams, Dictionary<string, object> pathParams, Dictionary<string, object> headerParams) where T : new()
        {
            throw new System.NotImplementedException();
        }

        public Task<T> Get<T>(string url, Dictionary<string, object> queryParams, Dictionary<string, object> pathParams, Dictionary<string, object> headerParams) where T : new()
        {
            throw new System.NotImplementedException();
        }

        public Task<T> Post<T>(string url, object body, Dictionary<string, object> queryParams, Dictionary<string, object> pathParams, Dictionary<string, object> headerParams) where T : new()
        {
            throw new System.NotImplementedException();
        }

        public Task<T> Put<T>(string url, object body, Dictionary<string, object> queryParams, Dictionary<string, object> pathParams, Dictionary<string, object> headerParams) where T : new()
        {
            throw new System.NotImplementedException();
        }
    }
}
