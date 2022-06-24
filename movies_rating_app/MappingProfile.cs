using AutoMapper;
using Entities.Models;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.EpisodeDtos;
using Entities.DataTransferObjects.GenreDtos;
using Entities.DataTransferObjects.MovieGenreDtos;
using Entities.DataTransferObjects.MoviePersonDtos;
using Entities.DataTransferObjects.MovieDtos;
using Entities.DataTransferObjects.PersonDtos;
using Entities.DataTransferObjects.RoleDtos;
using Entities.DataTransferObjects.SeasonDtos;
using Entities.DataTransferObjects.SeriesDtos;

namespace MoviesRatingApp.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Episode, EpisodeDto>();
            CreateMap<EpisodeForCreationDto, Episode>();

            CreateMap<Genre, GenreDto>();
            CreateMap<GenreForCreationDto, Genre>();

            CreateMap<Movie, MovieDto>();
            CreateMap<MovieForCreationDto, Movie>();

            CreateMap<MovieGenre, MovieGenreDto>();
            CreateMap<MovieGenreForCreationDto, MovieGenre>();

            CreateMap<MoviePerson, MoviePersonDto>();
            CreateMap<MoviePersonForCreationDto, MoviePerson>();

            CreateMap<Person, PersonDto>();
            CreateMap<PersonForCreationDto, Person>();

            CreateMap<Role, RoleDto>();
            CreateMap<RoleForCreationDto, Role>();

            CreateMap<Season, SeasonDto>();
            CreateMap<SeasonForCreationDto, Season>();

            CreateMap<Series, SeriesDto>();
            CreateMap<SeriesForCreationDto, Series>();
        }
    }
}
