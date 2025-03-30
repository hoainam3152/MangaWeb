using AutoMapper;
using MangaAPI.DTO.Requests;
using MangaAPI.DTO.Responses;
using MangaAPI.Enums;
using MangaAPI.Models;

namespace MangaAPI.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Genre, GenreResponse>().ReverseMap();
            CreateMap<Genre, GenreCreateRequest>().ReverseMap();

            CreateMap<Author, AuthorResponse>().ReverseMap();
            CreateMap<Author, AuthorRequest>().ReverseMap();

            CreateMap<Manga, MangaResponse>().ForMember(
                    dest => dest.Status,
                    opt => opt.ConvertUsing(new IntDescriptionConverter(), src => src.Status)
                ).ForMember(
                    dest => dest.Author,
                    opt => opt.MapFrom(src => src.Author != null ? src.Author.AuthorName : "Đang Cập Nhật")

                ).ReverseMap();
            CreateMap<Manga, MangaRequest>().ReverseMap();

            CreateMap<MangaGenres, MangaGenresResponse>().ReverseMap();
            CreateMap<MangaGenres, MangaGenresRequest>().ReverseMap();
        }
    }
}
