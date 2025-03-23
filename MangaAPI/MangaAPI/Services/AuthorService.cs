using AutoMapper;
using MangaAPI.DTO.Requests;
using MangaAPI.DTO.Responses;
using MangaAPI.Helpers;
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

        public async Task CreateAsync(AuthorCreateRequest request)
        {
            try
            {
                var author = await context.Authors.FirstOrDefaultAsync(element => element.AuthorId == request.AuthorId);
                if (author != null)  //Author already exists
                    throw new DbUpdateException(ResponseMessage.DUPLICATE_KEY);

                var authorCreate = mapper.Map<Author>(request);
                context.Authors.Add(authorCreate);
                await context.SaveChangesAsync();
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

        public async Task<bool> UpdateAsync(ulong authorId, AuthorUpdateRequest request)
        {
            try
            {
                var Author = await context.Authors.FirstOrDefaultAsync(g => g.AuthorId == authorId);
                if (Author != null)
                {
                    Author.AuthorName = request.AuthorName;
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

        private ulong GetId()
        {
            ulong i = 0;
            var lastAuthorId = context.Authors.LastAsync().ToString();

            return i;
        }
    }
}
