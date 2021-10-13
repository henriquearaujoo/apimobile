namespace Ailos.Pix.DTO.Key
{
    public class NewKeyRequest
    {
        public int CodeType { get; set; }
        public string Description { get; set; }
        public bool Favorite { get; set; }
        public string SessionID { get; set; }
    }
}