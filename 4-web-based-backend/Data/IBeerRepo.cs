using System.Collections.Generic;
using _4_web_based_backend.Models;

namespace _4_web_based_backend.Data
{
    public interface IBeerRepo
    {
        bool SaveChanges();

        //include the beer class from Model
        IEnumerable<Beer> GetAllBeers();
        IEnumerable<Beer> Search(string name);
        Beer GetBeerById(int id);
        void CreateBeer(Beer beer);
    }
}
