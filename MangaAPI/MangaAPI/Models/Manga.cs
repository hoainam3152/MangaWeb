using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaAPI.Models
{
    [Table("Manga")]
    public class Manga
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public ulong MangaId { get; set; }
        [StringLength(255)]
        public string Title { get; set; }
        [StringLength(255)]
        public string? AlternateTitle { get; set; }
        public ulong? AuthorId { get; set; }
        public string? Description { get; set; }
        public int Status { get; set; }
        [StringLength(255)]
        public string? CoverImage { get; set; }
        [StringLength(20)]
        public string? ReleaseDate { get; set; }

        [ForeignKey("AuthorId")]
        public Author? Author { get; set; }

        public ICollection<MangaGenres>? MangaGenres { get; set; }
    }
}
