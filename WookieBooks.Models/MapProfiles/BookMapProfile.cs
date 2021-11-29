using AutoMapper;
using WookieBooks.Models.Dbs;
using WookieBooks.Models.Dtos;

namespace WookieBooks.Models.MapProfiles
{
    public class BookMapProfile : Profile
    {
        public BookMapProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember(source => source.Author, opt => opt.Ignore());
            CreateMap<BookDto, Book>()
                .ForMember(source => source.Author, opt => opt.Ignore());
        }
    }
}
