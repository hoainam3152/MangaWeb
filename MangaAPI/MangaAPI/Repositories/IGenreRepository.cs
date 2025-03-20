using MangaAPI.DTO.Requests;
using MangaAPI.DTO.Responses;

namespace MangaAPI.Repositories
{
    public interface IGenreRepository
    {
        Task<IEnumerable<GenreResponse>> GetAllGenresAsync();
        Task<GenreResponse> GetGenreAsync(int genreId);
        Task<GenreResponse> CreateAsync(GenreCreateRequest request);
        Task<bool> UpdateAsync(int genreId, GenreUpdateRequest request);
        Task<bool> DeleteAsync(int genreId);
    }
}
