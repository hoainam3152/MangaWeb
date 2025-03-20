using System.ComponentModel.DataAnnotations;

namespace MangaAPI.DTO.Requests
{
    public class GenreCreateRequest
    {
        [Required]
        public int GenreId { get; set; }
        [Required]
        public string GenreName { get; set; }
    }
}
