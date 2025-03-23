using AutoMapper;
using MangaAPI.DTO.Requests;
using MangaAPI.DTO.Responses;
using MangaAPI.Helpers;
using MangaAPI.Models;
using MangaAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MangaAPI.Services
{
    public class GenreService : IGenreRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GenreService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task CreateAsync(GenreCreateRequest request)
        {
            try
            {
                var genre = await context.Genres.FirstOrDefaultAsync(element => element.GenreId == request.GenreId);
                if (genre == null)
                {
                    if (await context.Genres.AnyAsync(element => element.GenreName == request.GenreName))
                        throw new DbUpdateException(ResponseMessage.NAME_EXISTS);

                    var genreCreate = mapper.Map<Genre>(request);
                    context.Genres.Add(genreCreate);
                    await context.SaveChangesAsync();
                }
                throw new DbUpdateException(ResponseMessage.DUPLICATE_KEY);
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw dbUpdateException;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteAsync(int genreId)
        {
            try
            {
                var genre = await context.Genres.FirstOrDefaultAsync(g => g.GenreId == genreId);
                if (genre != null)
                {
                    context.Genres.Remove(genre);
                    await context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<GenreResponse> GetGenreAsync(int genreId)
        {
            var genre = await context.Genres.FirstOrDefaultAsync(g => g.GenreId == genreId);
            return mapper.Map<GenreResponse>(genre);
        }

        public async Task<IEnumerable<GenreResponse>> GetAllGenresAsync()
        {
            var genres = await context.Genres.ToListAsync();
            return mapper.Map<IEnumerable<GenreResponse>>(genres);
        }

        public async Task<bool> UpdateAsync(int genreId, GenreUpdateRequest request)
        {
            try
            {
                var genre = await context.Genres.FirstOrDefaultAsync(g => g.GenreId == genreId);
                if (genre != null)
                {
                    if (await context.Genres.AnyAsync(element => element.GenreName == request.GenreName))
                        throw new DbUpdateException(ResponseMessage.NAME_EXISTS);

                    genre.GenreName = request.GenreName;
                    //context.Genres.Update(genre);
                    await context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw dbUpdateException;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
