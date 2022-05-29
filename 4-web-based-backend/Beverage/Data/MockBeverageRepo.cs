using Beverage.Models;

namespace Beverage.Data
{
    // class implements from the interface IBerverageRepo
    // Mock data used for testing
    public class MockBeverageRepo : IBeverageRepo
    {
        // creates a new entry - again it's mocked data, so it won't do much
        public void CreateBeer(Beer cmd)
        {
            throw new NotImplementedException();
        }
        // Fetch a list of all the beers
        public IEnumerable<Beer> GetAllBeers()
        {
            var beers = new List<Beer>
            {
                new Beer{ Id=1, Name="Bud Light" },
                new Beer{ Id=2, Name="Castle Light" },
                new Beer{ Id=3, Name="2M" }
            };
            return beers;
        }
        // fetch a beer by Id
        public Beer GetBeerById(int id)
        {
            return new Beer{ Id=1, Name="Bud Light" };
        }
        // search for a beer by name
        public IEnumerable<Beer> SearchBeerByName(string searchString)
        {
            var beers = new List<Beer>
            {
                new Beer{ Id=1, Name="Bud Light" },
                new Beer{ Id=3, Name="2M" }
            };
            return beers;
        }
        public IEnumerable<Rating> GetRatingsByBeer(int beerId)
        {
            throw new NotImplementedException();
        }
        // creates a new entry - again it's mocked data, so it won't do much
        public void CreateBeerRating(Rating cmd)
        {
            throw new NotImplementedException();
        }
        // saves the data however this is kinda useless because it's fixed data
        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
