using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaAPI.Models
{
    [Tags("Manga")]
    public class Manga
    {
        [Key]
        public int MangaId { get; set; }
        [StringLength(255)]
        public string Title { get; set; }
        public int? AuthorId { get; set; }
        public string? Description { get; set; }
        public int Status { get; set; }
        [StringLength(255)]
        public string? CoverImage { get; set; }
        public DateTime? ReleaseDate { get; set; }

        [ForeignKey("AuthorId")]
        public Author? Author { get; set; }

        public ICollection<MangaGenres>? MangaGenres { get; set; }
    }
}
