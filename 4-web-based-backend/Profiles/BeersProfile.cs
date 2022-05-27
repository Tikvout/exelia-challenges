using _4_web_based_backend.Models;
using _4_web_based_backend.Dtos;
using AutoMapper;

namespace _4_web_based_backend.Profiles
{
    public class BeersProfile : Profile
    {
        public BeersProfile()
        {
            // Source -> Target
            CreateMap<Beer, BeerReadDto>();
            CreateMap<BeerCreateDto, Beer>();
        }
    }
}
