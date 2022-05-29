using AutoMapper;
using Beverage.Data;
using Beverage.Dtos;
using Beverage.Models;
using Microsoft.AspNetCore.Mvc;

namespace Beverage.Controllers
{
    // inherits from the base controller
    // ControllerBase is a class for an MVC project without View support

    // api/beers
    [Route("api/[controller]")] // Controller level route - how to navigate the controller classes
    [ApiController] // decorate class name with ApiController attributes
    public class BeersController : ControllerBase
    {
        private IBeverageRepo _repository;
        private readonly IMapper _mapper;

        // constructor for dependancies to be injected
        public BeersController(IBeverageRepo repository, IMapper mapper)
        {
            // whatever gets injected via the dependancy injection will get assigned to _repository and _mapper
            _repository = repository;
            _mapper = mapper;
        }

        // create an action result endpoint which will relate to getting the recources
        // GET api/beers
        [HttpGet] // indicates that the action result will respond to an http GET request
        public ActionResult<IEnumerable<BeerReadDto>> GetAllBeers()
        {
            var results = _repository.GetAllBeers();
            // returns a dto that is mapped from the fetched object
            return Ok(_mapper.Map<IEnumerable<BeerReadDto>>(results));
        }

        // returns a single resource
        // GET api/beers/{id}
        [HttpGet("{id}", Name = "GetBeerById")] // will respond to an http GET request by supplying an Id (Named because the CreateBeer returns this location as a header)
        public ActionResult<BeerReadDto> GetBeerById(int id)
        {
            var result = _repository.GetBeerById(id);
            // returns Not Found if result is NULL
            if (result != null)
            {
                // returns a dto that is mapped from the fetched object
                return Ok(_mapper.Map<BeerReadDto>(result));
            }
            return NotFound();
        }

        // returns a list of beers matching the search string
        // GET api/beers/search/{searchString}
        [HttpGet("search/{searchString}")]
        public ActionResult<IEnumerable<BeerReadDto>> SearchBeerByName(string searchString)
        {
            var results = _repository.SearchBeerByName(searchString);
            // returns a dto that is mapped from the fetched object
            return Ok(_mapper.Map<IEnumerable<BeerReadDto>>(results));
        }

        // returns a single created resource
        // POST api/beers
        [HttpPost] // will respond to an http POST request by supplying an Id
        public ActionResult<BeerReadDto> CreateBeer(BeerCreateDto beerCreateDto)
        {
            var model = _mapper.Map<Beer>(beerCreateDto);
            _repository.CreateBeer(model); // adds the changes to the database
            _repository.SaveChanges(); // saves the changes to the database

            var beerReadDto = _mapper.Map<BeerReadDto>(model);
            // returns a full location in the header on where to retrieve the created resource
            return CreatedAtRoute(nameof(GetBeerById), new { Id = beerReadDto.Id }, beerReadDto);
        }

        // returns a list of ratings for the beer
        // GET api/beers/rate/{beerId}
        [HttpGet("rating/{beerId}", Name = "GetBeerRatingByBeer")] // will respond to an http GET request by supplying a beerId
        public ActionResult<IEnumerable<RatingReadDto>> GetBeerRatingByBeer(int beerId)
        {
            var results = _repository.GetRatingsByBeer(beerId);
            // returns a dto that is mapped from the fetched object
            return Ok(_mapper.Map<IEnumerable<RatingReadDto>>(results));
        }

        // returns a single create resource
        // POST api/beers/rate/{beer}
        [HttpPost("rating")]
        public ActionResult<RatingReadDto> CreateBeerRating(RatingCreateDto ratingCreateDto)
        {
            var model = _mapper.Map<Rating>(ratingCreateDto);
            _repository.CreateBeerRating(model); // adds the changes to the database
            _repository.SaveChanges(); // saves the changes to the database

            var ratingReadDto = _mapper.Map<RatingReadDto>(model);
            // returns a full location in the header on where to retrieve the created resource
            return CreatedAtRoute(nameof(GetBeerRatingByBeer), new { BeerId = ratingReadDto.BeerId }, ratingReadDto);
        }
    }
}