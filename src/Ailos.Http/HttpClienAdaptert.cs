﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ailos.Http
{
    internal class HttpClienAdaptert : IHttp
    {
        public Task<T> On<T>(HttpMethods method, string url, object body, Dictionary<string, object> queryParams, Dictionary<string, object> pathParams, Dictionary<string, object> headerParams) where T : new()
        {
            throw new NotImplementedException();
        }
    }
}
