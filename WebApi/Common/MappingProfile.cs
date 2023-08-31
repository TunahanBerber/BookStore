using AutoMapper;
using WebApi.BookOperations.CreateBookCs;
using WebApi.BookOperations.GetBooksDetail;
using static WebApi.BookOperations.CreateBookCs.CreateBookCommand;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book,BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
        }
    }
}