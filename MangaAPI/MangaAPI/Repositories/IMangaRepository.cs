using MangaAPI.DTO.Requests;
using MangaAPI.DTO.Responses;

namespace MangaAPI.Repositories
{
    public interface IMangaRepository
    {
        Task<IEnumerable<MangaResponse>> GetAllMangasAsync();
        Task<MangaResponse> GetMangaAsync(ulong MangaId);
        Task<MangaResponse> CreateAsync(MangaRequest request);
        Task<bool> UpdateAsync(ulong MangaId, MangaRequest request);
        Task<bool> DeleteAsync(ulong MangaId);
    }
}
