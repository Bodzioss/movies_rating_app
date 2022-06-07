using Microsoft.EntityFrameworkCore;
using MoviesRatingApp.Models;

namespace MoviesRatingApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
    }
}
