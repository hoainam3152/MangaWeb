using System.Security.Claims;
using MangaAPI.DTO;
using MangaAPI.DTO.Responses;
using MangaAPI.Helpers;
using Microsoft.AspNetCore.Identity;

namespace MangaAPI.Repositories
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> RegisterAsync(RegisterDTO dto);
        public Task<string> LogInAsync(LogInDTO dto);
        public Task<IEnumerable<AccountResponse>> GetAllAccountsAsync();
        public Task<AccountResponse> GetAccountAsync(string accountId, ClaimsPrincipal user);
    }
}
