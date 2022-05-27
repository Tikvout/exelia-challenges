using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _4_web_based_backend.Data;
using _4_web_based_backend.Dtos;
using _4_web_based_backend.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace _4_web_based_backend.Controllers
{
       // api/beers
    [Route("api/[controller]")]
    public class BeersController : Controller
    {
        private readonly IBeerRepo _repository;
        private readonly IMapper _mapper;

        // create a constructor for the dependancy to be injected
        public BeersController(IBeerRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/<controller>
        [HttpGet]
        public ActionResult <IEnumerable<Beer>> GetAllBeers()
        {
            var beerItems = _repository.GetAllBeers();
            return Ok(_mapper.Map<IEnumerable<BeerReadDto>>(beerItems));
        }

        // GET api/<controller>
        [HttpGet("{id:int}")]
        public ActionResult <BeerReadDto> GetBeerById(int id)
        {
            var beerItem = _repository.GetBeerById(id);
            if (beerItem != null)
            {
                // return the mapped object instead
                return Ok(_mapper.Map<BeerReadDto>(beerItem));
            }
            return NotFound();
        }

        // GET api/<controller>
        [HttpGet("{search}")]
        public ActionResult<IEnumerable<BeerReadDto>> Search(string name)
        {
            return Ok(name);
            //if (result.Any())
            //{
            //    return Ok(result);
            //} else
            //{
            //    return NotFound();
            //}
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult <BeerReadDto> CreateBeer(BeerCreateDto beerCreateDto)
        {
            // map to Beer from beerCreateDto
            var beerModel = _mapper.Map<Beer>(beerCreateDto);
            _repository.CreateBeer(beerModel);
            _repository.SaveChanges(); // saves the data

            var beerReadDto = _mapper.Map<BeerReadDto>(beerModel); // create placeholder
            // created route app link
            // we're going to be using the get recourse for this
            return CreatedAtRoute(nameof(GetBeerById), new {Id = beerReadDto.Id}, beerReadDto); // returns 201 instead
        }
    }
}
