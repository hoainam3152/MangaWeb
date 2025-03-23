using System.ComponentModel.DataAnnotations;

namespace MangaAPI.DTO.Requests
{
    public class AuthorUpdateRequest
    {
        [Required]
        public string AuthorName { get; set; }
        public string? Biography { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? AuthorImage { get; set; }
    }
}
