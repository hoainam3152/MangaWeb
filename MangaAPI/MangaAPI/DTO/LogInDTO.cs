using System.ComponentModel.DataAnnotations;

namespace MangaAPI.DTO
{
    public class LogInDTO
    {
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
