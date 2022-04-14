using AutoMapper;
using Movies.API.Command;
using Movies.API.DTOs;
using Movies.API.Models;

namespace Movies.API.Services
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieRequestDto>().ReverseMap();
            CreateMap<Movie, MovieDto>().ForMember(x => x.Income, c => c.MapFrom(x => x.Income))
                                   .ForMember(x => x.Name, c => c.MapFrom(x => x.Name))
                                   .ForMember(x => x.Rating, c => c.MapFrom(x => x.Rating))
                                   .ForMember(x => x.ReleaseDate, c => c.MapFrom(x => x.ReleaseDate))
                                   .ForMember(x => x.Type, c => c.MapFrom(x => x.Type.ToString()));

            CreateMap<Movie, MovieUpdateCommand>().ReverseMap();
            CreateMap<Movie, MovieInsertCommand>().ReverseMap();

            CreateMap<MovieRequestDto, MovieUpdateCommand>().ReverseMap();
        }
    }
}
