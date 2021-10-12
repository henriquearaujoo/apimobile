namespace Ailos.Pix.Chave.DTO.Response
{
    public record NewKeyResponse
    {
        public int Id { get; init; }
        public int CooperativeCode { get; init; }
        public int Account { get; init; }
        public int CodeHolder { get; init; }
        public string Description { get; init; }
        public string Status { get; init; }
        public int CodeType { get; init; }
        public string SourceId { get; init; }
        public string CreationDate { get; init; }
        public bool OutDate { get; init; }
        public bool Portability { get; init; }
    }
}
