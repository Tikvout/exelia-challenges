using Beverage.Models;
using Microsoft.EntityFrameworkCore;

namespace Beverage.Data
{
    // inherit from the DbContext base class
    public class BeverageContext : DbContext
    {
        // define a constructor
        public BeverageContext(DbContextOptions<BeverageContext> opt) : base(opt)
        {

        }

        // creates a representaion of our Beverage model in our database
        // we want to represent our Beer objects down to our database as a dbSet - called Beers & Ratings
        public DbSet<Beer> Beers { get; set; }
        public DbSet<Rating> Ratings { get; set; }

    }
}
