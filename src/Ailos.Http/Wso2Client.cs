using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ailos.Http
{
    public class Wso2Client : IClient
    {
        private readonly IHttp _http;

        public Wso2Client()
        {
            _http = new RestClientAdapter();
        }

        public async Task<T> Delete<T>(string url, object body, Dictionary<string, object> queryParams, Dictionary<string, object> pathParams, Dictionary<string, object> headerParams) where T : new()
        {
            return await _http.On<T>(HttpMethods.DELETE, url, body, queryParams, pathParams, headerParams);
        }

        public async Task<T> Get<T>(string url, Dictionary<string, object> queryParams, Dictionary<string, object> pathParams, Dictionary<string, object> headerParams) where T : new()
        {
            return await _http.On<T>(HttpMethods.GET, url, null, queryParams, pathParams, headerParams);
        }

        public async Task<T> Post<T>(string url, object body, Dictionary<string, object> queryParams, Dictionary<string, object> pathParams, Dictionary<string, object> headerParams) where T : new()
        {
            return await _http.On<T>(HttpMethods.POST, url, body, queryParams, pathParams, headerParams);
        }

        public async Task<T> Put<T>(string url, object body, Dictionary<string, object> queryParams, Dictionary<string, object> pathParams, Dictionary<string, object> headerParams) where T : new()
        {
            return await _http.On<T>(HttpMethods.PUT, url, body, queryParams, pathParams, headerParams);
        }
    }
}
