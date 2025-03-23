using MangaAPI.DTO.Requests;
using MangaAPI.DTO.Responses;

namespace MangaAPI.Repositories
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<AuthorResponse>> GetAllAuthorsAsync();
        Task<AuthorResponse> GetAuthorAsync(ulong AuthorId);
        Task<AuthorResponse> CreateAsync(AuthorRequest request);
        Task<bool> UpdateAsync(ulong AuthorId, AuthorRequest request);
        Task<bool> DeleteAsync(ulong AuthorId);
    }
}
