namespace Ailos.Pix.DTO.Key
{
    public record NewKeyRequest
    {
        public int CodeType { get; init; }
        
        public string Description { get; init; }
        
        public bool Favorite { get; init; }

        public string SessionID { get; init; }
    }
}
