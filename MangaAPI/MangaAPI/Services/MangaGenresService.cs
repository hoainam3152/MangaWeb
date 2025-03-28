using AutoMapper;
using MangaAPI.DTO.Requests;
using MangaAPI.DTO.Responses;
using MangaAPI.Helpers;
using MangaAPI.Models;
using MangaGenresAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MangaAPI.Services
{
    public class MangaGenresService : IMangaGenresRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public MangaGenresService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<MangaGenresResponse> CreateAsync(MangaGenresRequest request)
        {
            var mangaGenres = await context.MangaGenres.FirstOrDefaultAsync(g =>
                g.MangaId == request.MangaId &&
                g.GenreId == request.GenreId);

            if (mangaGenres != null)
                throw new DbUpdateException(ResponseMessage.DUPLICATE_KEY);

            var mangaGenresCreate = mapper.Map<MangaGenres>(request);
            context.MangaGenres.Add(mangaGenresCreate);
            await context.SaveChangesAsync();
            return mapper.Map<MangaGenresResponse>(mangaGenresCreate);
        }

        public async Task<bool> DeleteAsync(ulong mangaId, int genreId)
        {
            var mangaGenres = await context.MangaGenres.FirstOrDefaultAsync(g =>
                g.MangaId == mangaId &&
                g.GenreId == genreId);
            if (mangaGenres != null)
            {
                context.MangaGenres.Remove(mangaGenres);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<MangaGenresResponse> GetMangaGenresAsync(ulong mangaId, int genreId)
        {
            var MangaGenres = await context.MangaGenres.FirstOrDefaultAsync(g => 
                g.MangaId == mangaId &&
                g.GenreId == genreId);
            return mapper.Map<MangaGenresResponse>(MangaGenres);
        }

        public async Task<IEnumerable<MangaGenresResponse>> GetAllMangaGenressAsync()
        {
            var MangaGenress = await context.MangaGenres.ToListAsync();
            return mapper.Map<IEnumerable<MangaGenresResponse>>(MangaGenress);
        }
    }
}
