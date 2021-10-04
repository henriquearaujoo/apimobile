using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ailos.Http
{
    public class SOAClient : IClient
    {
        public Task<T> Delete<T>(string method, string url, object body, Dictionary<string, object> queryParams, Dictionary<string, object> pathParams, Dictionary<string, object> headerParams) where T : new()
        {
            throw new System.NotImplementedException();
        }

        public Task<T> Get<T>(string method, string url, Dictionary<string, object> queryParams, Dictionary<string, object> pathParams, Dictionary<string, object> headerParams) where T : new()
        {
            throw new System.NotImplementedException();
        }

        public Task<T> Post<T>(string method, string url, object body, Dictionary<string, object> queryParams, Dictionary<string, object> pathParams, Dictionary<string, object> headerParams) where T : new()
        {
            throw new System.NotImplementedException();
        }

        public Task<T> Put<T>(string method, string url, object body, Dictionary<string, object> queryParams, Dictionary<string, object> pathParams, Dictionary<string, object> headerParams) where T : new()
        {
            throw new System.NotImplementedException();
        }
    }
}
