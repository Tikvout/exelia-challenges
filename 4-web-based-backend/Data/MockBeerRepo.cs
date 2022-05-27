using _4_web_based_backend.Models;
using System.Collections.Generic;

namespace _4_web_based_backend.Data
{
    public class MockBeerRepo : IBeerRepo
    {
        public void CreateBeer(Beer beer)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Beer> GetAllBeers()
        {
            var beers = new List<Beer>
            {
                new Beer { Id=1, Name="Test" },
                new Beer { Id=2, Name="Beer 1" },
                new Beer { Id=3, Name="Castle" },
            };
            return beers;
        }

        public Beer GetBeerById(int id)
        {
            return new Beer { Id=1, Name="Test" };
        }

        // get beer by Id
        public IEnumerable<Beer> Search(string name)
        {
            var beers = new List<Beer>
            {
                new Beer { Id=1, Name="Test" },
                new Beer { Id=2, Name="Beer 1" },
                new Beer { Id=3, Name="Castle" },
            };
            return beers;
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        Beer IBeerRepo.Search(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}
