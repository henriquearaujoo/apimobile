using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ailos.Http
{
    public interface IClient
    {
        Task<T> Get<T>(string url, Dictionary<string, object> queryParams = null, Dictionary<string, object> pathParams = null, Dictionary<string, object> headerParams = null) where T : new();

        Task<T> Post<T>(string url, object body = null, Dictionary<string, object> queryParams = null, Dictionary<string, object> pathParams = null, Dictionary<string, object> headerParams = null) where T : new();

        Task<T> Put<T>(string url, object body = null, Dictionary<string, object> queryParams = null, Dictionary<string, object> pathParams = null, Dictionary<string, object> headerParams = null) where T : new();

        Task<T> Delete<T>(string url, object body = null, Dictionary<string, object> queryParams = null, Dictionary<string, object> pathParams = null, Dictionary<string, object> headerParams = null) where T : new();
    }
}