using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaAPI.Models
{
    [Table("Author")]
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        [StringLength(100)]
        public string AuthorName { get; set; }
        public string? Biography { get; set; }
        public DateTime? BirthDate { get; set; }
        [StringLength(255)]
        public string? AuthorImage { get; set; }

        public ICollection<Manga>? Mangas { get; set; }
    }
}
