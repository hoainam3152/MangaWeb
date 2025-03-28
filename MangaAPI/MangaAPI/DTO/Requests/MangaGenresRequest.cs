using System.ComponentModel.DataAnnotations;

namespace MangaAPI.DTO.Requests
{
    public class MangaGenresRequest
    {
        [Required]
        public ulong MangaId { get; set; }
        [Required]
        public int GenreId { get; set; }
    }
}
