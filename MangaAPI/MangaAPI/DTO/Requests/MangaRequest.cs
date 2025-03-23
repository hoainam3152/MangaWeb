using System.ComponentModel.DataAnnotations;

namespace MangaAPI.DTO.Requests
{
    public class MangaRequest
    {
        [Required]
        public string Title { get; set; }
        public ulong? AuthorId { get; set; }
        public string? Description { get; set; }
        public string? CoverImage { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
