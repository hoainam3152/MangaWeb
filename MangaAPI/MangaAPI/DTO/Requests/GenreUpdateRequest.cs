using System.ComponentModel.DataAnnotations;

namespace MangaAPI.DTO.Requests
{
    public class GenreUpdateRequest
    {
        [Required]
        public string GenreName { get; set; }
    }
}
