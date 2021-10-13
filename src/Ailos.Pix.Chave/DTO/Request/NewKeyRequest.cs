using System.Text.Json.Serialization;

namespace Ailos.Pix.Chave.DTO.Request
{
    public record NewKeyRequest
    {
        public int CodeType { get; init; }

        public string Description { get; init; }

        public bool Favorite { get; init; }

        public string SessionID { get; init; }
    }
}
