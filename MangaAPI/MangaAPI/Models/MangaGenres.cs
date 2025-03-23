using System.ComponentModel.DataAnnotations.Schema;

namespace MangaAPI.Models
{
    [Table("MangaGenres")]
    public class MangaGenres
    {
        public ulong MangaId { get; set; }
        public int GenreId { get; set; }

        [ForeignKey("MangaId")]
        public Manga? Manga { get; set; }
        [ForeignKey("GenreId")]
        public Genre? Genre { get; set; }
    }
}
