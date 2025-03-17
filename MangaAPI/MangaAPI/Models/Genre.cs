using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MangaAPI.Models
{
    [Table("Genre")]
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        [StringLength(100)]
        public string GenreName { get; set; }

        public ICollection<MangaGenres>? MangaGenres { get; set; }
    }
}
