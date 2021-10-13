using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ailos.Http
{
    public class SOAClient : IClient
    {
        private readonly IHttp _http;

        public SOAClient()
        {
            _http = new RestClientAdapter();
        }

        public async Task<T> Delete<T>(string url, object body = null, Dictionary<string, object> queryParams = null, Dictionary<string, object> pathParams = null, Dictionary<string, object> headerParams = null) where T : new()
        {
            throw new System.NotImplementedException();
        }

        public async Task<T> Get<T>(string url, Dictionary<string, object> queryParams = null, Dictionary<string, object> pathParams = null, Dictionary<string, object> headerParams = null) where T : new()
        {
            throw new System.NotImplementedException();
        }

        public async Task<T> Post<T>(string url, object body = null, Dictionary<string, object> queryParams = null, Dictionary<string, object> pathParams = null, Dictionary<string, object> headerParams = null) where T : new()
        {
            throw new System.NotImplementedException();
        }

        public async Task<T> Put<T>(string url, object body = null, Dictionary<string, object> queryParams = null, Dictionary<string, object> pathParams = null, Dictionary<string, object> headerParams = null) where T : new()
        {
            throw new System.NotImplementedException();
        }
    }
}