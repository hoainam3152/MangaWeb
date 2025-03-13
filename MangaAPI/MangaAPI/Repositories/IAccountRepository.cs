using MangaAPI.DTO;
using Microsoft.AspNetCore.Identity;

namespace MangaAPI.Repositories
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> RegisterAsync(RegisterDTO dto);
        public Task<string> LogInAsync(LogInDTO dto);
    }
}
