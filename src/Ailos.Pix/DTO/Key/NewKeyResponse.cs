namespace Ailos.Pix.DTO.Key
{
    public class NewKeyResponse
    {
        public int Id { get; set; }
        public int CooperativeCode { get; set; }
        public int Account { get; set; }
        public int CodeHolder { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int CodeType { get; set; }
        public string SourceId { get; set; }
        public string CreationDate { get; set; }
        public bool OutDate { get; set; }
        public bool Portability { get; set; }
        public bool Claim { get; set; }
    }
}