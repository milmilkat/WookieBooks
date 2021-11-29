using AutoMapper;
using WookieBooks.Models.Dbs;
using WookieBooks.Models.Dtos;

namespace WookieBooks.Models.MapProfiles
{
    public class AuthorMapProfile : Profile
    {
        public AuthorMapProfile()
        {
            CreateMap<Author, AuthorDto>();
            CreateMap<AuthorDto, Author>();
        }
    }
}
