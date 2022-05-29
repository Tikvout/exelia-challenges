using Beverage.Models;
using Microsoft.EntityFrameworkCore;

namespace Beverage.Data
{
    // class implements from the interface IBerverageRepo
    public class SqlBeverageRepo : IBeverageRepo
    {
        private readonly BeverageContext _context;
        // constructor for dependancies to be injected
        public SqlBeverageRepo(BeverageContext context)
        {
            // whatever gets injected via the dependancy injection will get assigned to _context
            _context = context;
        }
        // adds the data to be saved in to the database
        public void CreateBeer(Beer cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            // adds the changed data to be inserted to the database (still needs to be saved)
            _context.Beers.Add(cmd);
        }
        // returns a list of all the beers in the database
        public IEnumerable<Beer> GetAllBeers()
        {
            return _context.Beers.Include(p => p.Ratings).ToList();
        }
        // returns the beer matching the provided id
        public Beer GetBeerById(int id)
        {
            return _context.Beers.Include(p => p.Ratings).FirstOrDefault(p => p.Id == id);
        }
        // return a list of beers where the name contains the searched string
        public IEnumerable<Beer> SearchBeerByName(string searchString)
        {
            return _context.Beers.Where(p => p.Name.Contains(searchString) || searchString == null).ToList();
        }
        // return att beer ratings
        public IEnumerable<Rating> GetRatingsByBeer(int beerId)
        {
            return _context.Ratings.Where(p => p.BeerId == beerId);
        }
        // returns  rating by id
        public Rating GetRatingById(int id)
        {
            return _context.Ratings.FirstOrDefault(p => p.Id == id);
        }
        // adds the rating to be saved
        public void CreateBeerRating(Rating cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            // adds the changed data to be inserted to the database (still needs to be saved)
            _context.Ratings.Add(cmd);
        }
        // saves the changed data to the database
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void DeleteRating(Rating cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            // removes the data from the database (still needs to be saved)
            _context.Ratings.Remove(cmd);
        }
    }
}
