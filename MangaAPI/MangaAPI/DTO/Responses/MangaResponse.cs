namespace MangaAPI.DTO.Responses
{
    public class MangaResponse
    {
        public ulong MangaId { get; set; }
        public string Title { get; set; }
        public ulong? AuthorId { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; }
        public string? CoverImage { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
