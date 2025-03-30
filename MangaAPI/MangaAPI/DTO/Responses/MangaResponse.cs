namespace MangaAPI.DTO.Responses
{
    public class MangaResponse
    {
        public ulong MangaId { get; set; }
        public string Title { get; set; }
        public string? AlternateTitle { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; }
        public string? CoverImage { get; set; }
        public string? ReleaseDate { get; set; }
    }
}
