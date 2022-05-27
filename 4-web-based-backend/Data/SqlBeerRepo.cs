using System;
using _4_web_based_backend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace _4_web_based_backend.Data
{
    public class SqlBeerRepo : IBeerRepo
    {
        private readonly BeerContext _context;

        public SqlBeerRepo(BeerContext context)
        {
            _context = context;
        }

        public void CreateBeer(Beer beer)
        {
            if(beer == null)
            {
                throw new ArgumentNullExeption(nameof(beer));
            }
            _context.Beers.Add(beer);

        }

        // get all beers
        public IEnumerable<Beer> GetAllBeers()
        {
            return _context.Beers.ToList();
        }
        // get berr by Id
        public Beer GetBeerById(int id)
        {
            return _context.Beers.FirstOrDefault(p => p.Id == id);
        }
        // search for beer by name
        public async Task<IEnumerable<Beer>> Search(string name)
        {
            IQueryable<Beer> query = _context.Beers;
            return await query.Where(e => e.Name.Contains(name)).ToListAsync();
        }
        // when a change is made this saves the database
        public bool SaveChanges() 
        {
            return (_context.SaveChanges() >= 0);
        }

        //IEnumerable<Beer> IBeerRepo.Search(string Name)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
