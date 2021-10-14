using System;

namespace Ailos.Http.Data
{
    public class TokenDTO
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string scope { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
