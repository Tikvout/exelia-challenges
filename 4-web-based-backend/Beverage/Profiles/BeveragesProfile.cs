using AutoMapper;
using Beverage.Dtos;
using Beverage.Models;

namespace Beverage.Profiles
{
    // Inherit from the base Class from auto mapper
    public class BeveragesProfile : Profile
    {
        // create a constructor
        public BeveragesProfile()
        {
            // use the CreateMap command to map between source object and destination object (Source -> Target)
            CreateMap<Beer, BeerReadDto>();
            CreateMap<BeerCreateDto, Beer>();
            CreateMap<Rating, RatingReadDto>();
            CreateMap<RatingCreateDto, Rating>();
        }
    }
}
