using MangaAPI.DTO.Requests;
using MangaAPI.DTO.Responses;

namespace MangaGenresAPI.Repositories
{
    public interface IMangaGenresRepository
    {
        Task<IEnumerable<MangaGenresResponse>> GetAllMangaGenressAsync();
        Task<MangaGenresResponse> GetMangaGenresAsync(ulong mangaId, int genreId);
        Task<MangaGenresResponse> CreateAsync(MangaGenresRequest request);
        Task<bool> DeleteAsync(ulong mangaId, int genreId);
    }
}
