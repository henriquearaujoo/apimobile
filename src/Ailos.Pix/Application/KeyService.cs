using Ailos.Http;
using Ailos.Pix.DTO.Key;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ailos.Pix.Services
{
    public class KeyService : IKeyService
    {
        private readonly IClient _client;

        public KeyService(IClient client)
        {
            _client = new WebSpeedClient();
        }

        public async Task<NewKeyResponse> AddKey(NewKeyRequest newKeyRequest)
        {
            return await _client.Post<NewKeyResponse>("/", newKeyRequest, new Dictionary<string, object>(), new Dictionary<string, object>(), new Dictionary<string, object>());
        }
    }
}
