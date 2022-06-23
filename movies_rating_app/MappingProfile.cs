using AutoMapper;
using Entities.Models;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.EpisodeDtos;

namespace MoviesRatingApp.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Episode, EpisodeDto>();
            CreateMap<EpisodeForCreationDto, Episode>();
        }
    }
}
