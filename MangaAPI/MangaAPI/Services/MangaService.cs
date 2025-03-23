using AutoMapper;
using MangaAPI.DTO.Requests;
using MangaAPI.DTO.Responses;
using MangaAPI.Enums;
using MangaAPI.Models;
using MangaAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MangaAPI.Services
{
    public class MangaService : IMangaRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public MangaService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<MangaResponse> CreateAsync(MangaRequest request)
        {
            try
            {
                var mangaCreate = mapper.Map<Manga>(request);
                mangaCreate.MangaId = GetMangaId();
                mangaCreate.Status = ((int)EStatus.UPDATING);
                context.Mangas.Add(mangaCreate);
                await context.SaveChangesAsync();
                return mapper.Map<MangaResponse>(mangaCreate);
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        public async Task<bool> DeleteAsync(ulong mangaId)
        {
            try
            {
                var manga = await context.Mangas.FirstOrDefaultAsync(g => g.MangaId == mangaId);
                if (manga != null)
                {
                    context.Mangas.Remove(manga);
                    await context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<MangaResponse> GetMangaAsync(ulong mangaId)
        {
            var manga = await context.Mangas.FirstOrDefaultAsync(g => g.MangaId == mangaId);
            return mapper.Map<MangaResponse>(manga);
        }

        public async Task<IEnumerable<MangaResponse>> GetAllMangasAsync()
        {
            var mangas = await context.Mangas.ToListAsync();
            return mapper.Map<IEnumerable<MangaResponse>>(mangas);
        }

        public async Task<bool> UpdateAsync(ulong MangaId, MangaRequest request)
        {
            try
            {
                var manga = await context.Mangas.FirstOrDefaultAsync(g => g.MangaId == MangaId);
                if (manga != null)
                {
                    manga.Title = request.Title;
                    manga.AuthorId = request.AuthorId;
                    manga.Description = request.Description;
                    manga.CoverImage = request.CoverImage;
                    manga.ReleaseDate = request.ReleaseDate;
                    await context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        private ulong GetMangaId()
        {
            string dateNow = DateTime.Now.ToString("yyyyMMdd");
            var lastManga = context.Mangas
                .Where(element => element.MangaId.ToString().StartsWith(dateNow))
                .OrderBy(au => au.MangaId).LastOrDefault();
            if (lastManga != null)
                return lastManga.MangaId + 1;
            else
                return ulong.Parse(dateNow + "00");
        }
    }
}
