﻿using Beverage.Models;

namespace Beverage.Data
{
    public interface IBeverageRepo
    {
        bool SaveChanges();

        // get all beers
        IEnumerable<Beer> GetAllBeers();
        // get a beer by Id
        Beer GetBeerById(int id);
        // get a beer by Name
        IEnumerable<Beer> SearchBeerByName(string search);
        // get rating by beerId
        IEnumerable<Rating> GetRatingsByBeer(int beerId);
        // add a beer
        void CreateBeer(Beer cmd);
        // add a rating
        void CreateBeerRating(Rating cmd);
    }
}
