using _4_web_based_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace _4_web_based_backend.Data
{
    // inherit from the base class DbContext
    public class BeerContext : DbContext
    {
        public BeerContext(DbContextOptions<BeerContext> opt) : base(opt) {

        }

        public DbSet<Beer> Beers { get; set; }
    }
}
