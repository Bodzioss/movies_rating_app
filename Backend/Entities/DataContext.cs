using Microsoft.EntityFrameworkCore;
using Entities.Models;

namespace Entities
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Movie>? Movies { get; set; }
        public DbSet<Episode>? Episodes { get; set; }
        public DbSet<Genre>? Genres { get; set; }
        public DbSet<MovieGenre>? MovieGenres { get; set; }
        public DbSet<MoviePerson>? MoviePeople { get; set; }
        public DbSet<Person>? People { get; set; }
        public DbSet<Role>? Roles { get; set; }
        public DbSet<Season>? Seasons { get; set; }
        public DbSet<Series>? TVSeries { get; set; }
    }
}
