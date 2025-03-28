using AutoMapper;
using MangaAPI.DTO.Requests;
using MangaAPI.DTO.Responses;
using MangaAPI.Models;
using MangaAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MangaAPI.Services
{
    public class AuthorService : IAuthorRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AuthorService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<AuthorResponse> CreateAsync(AuthorRequest request)
        {
            try
            {
                var authorCreate = mapper.Map<Author>(request);
                authorCreate.AuthorId = GetAuthorId();
                context.Authors.Add(authorCreate);
                await context.SaveChangesAsync();
                return mapper.Map<AuthorResponse>(authorCreate);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteAsync(ulong authorId)
        {
            try
            {
                var author = await context.Authors.FirstOrDefaultAsync(g => g.AuthorId == authorId);
                if (author != null)
                {
                    context.Authors.Remove(author);
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

        public async Task<AuthorResponse> GetAuthorAsync(ulong AuthorId)
        {
            var author = await context.Authors.FirstOrDefaultAsync(g => g.AuthorId == AuthorId);
            return mapper.Map<AuthorResponse>(author);
        }

        public async Task<IEnumerable<AuthorResponse>> GetAllAuthorsAsync()
        {
            var authors = await context.Authors.ToListAsync();
            return mapper.Map<IEnumerable<AuthorResponse>>(authors);
        }

        public async Task<bool> UpdateAsync(ulong authorId, AuthorRequest request)
        {
            try
            {
                var author = await context.Authors.FirstOrDefaultAsync(g => g.AuthorId == authorId);
                if (author != null)
                {
                    author.AuthorName = request.AuthorName;
                    author.Biography = request.Biography;
                    author.BirthDate = request.BirthDate;
                    author.AuthorImage = request.AuthorImage;
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

        private ulong GetAuthorId()
        {
            string dateNow = DateTime.Now.ToString("yyyyMMdd");
            var lastAuthor = context.Authors
                .Where(element => element.AuthorId.ToString().StartsWith(dateNow))
                .OrderBy(au => au.AuthorId).LastOrDefault();
            if (lastAuthor != null)
                return lastAuthor.AuthorId + 1;
            else 
                return ulong.Parse(dateNow + "00");
        }
    }
}
