using AutoMapper;
using MangaAPI.DTO.Responses;
using MangaAPI.Models;

namespace MangaAPI.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Genre, GenreResponse>().ReverseMap();
        }
    }
}
