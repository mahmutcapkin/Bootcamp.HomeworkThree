using Application.Features.Books.Commands.DeleteBookCommand;
using Application.Features.Books.Commands.InsertBookCommand;
using Application.Features.Books.Commands.UpdateBookCommand;
using Application.Features.Books.DTOs;
using Application.Observer;
using AutoMapper;
using Domain;

namespace Application.Features.Movies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Book, DeleteBookCommand>().ReverseMap();
            CreateMap<Book, UpdateBookCommand>().ReverseMap();
            CreateMap<Book, InsertBookCommand>().ReverseMap();


            CreateMap<Book, BookDto>().ReverseMap();


            CreateMap<Book, BookCreated>().ForMember(x => x.BookId, c => c.MapFrom(x => x.Id))
                                .ForMember(x => x.BookName, c => c.MapFrom(x => x.Name));

        }
    }
}
