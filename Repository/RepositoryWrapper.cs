using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DataContext _dataContext;
        private IEpisodeRepository _episode;
        private IGenreRepository _genre;
        private IMovieGenreRepository _movieGenre;
        private IMoviePersonRepository _moviePerson;
        private IMovieRepository _movie;
        private IPersonRepository _person;
        private IRoleRepository _role;
        private ISeasonRepository _season;
        private ISeriesRepository _series;

        public IEpisodeRepository Episode
        {
            get
            {
                if(_episode == null)
                {
                    _episode = new EpisodeRepository(_dataContext);
                }
                return _episode;
            }
        }

        public IGenreRepository Genre
        {
            get
            {
                if (_genre == null)
                {
                    _genre = new GenreRepository(_dataContext);
                }
                return _genre;
            }
        }

        public IMovieGenreRepository MovieGenre
        {
            get
            {
                if (_movieGenre == null)
                {
                    _movieGenre = new MovieGenreRepository(_dataContext);
                }
                return _movieGenre;
            }
        }

        public IMoviePersonRepository MoviePerson
        {
            get
            {
                if (_moviePerson == null)
                {
                    _moviePerson = new MoviePersonRepository(_dataContext);
                }
                return _moviePerson;
            }
        }

        public IMovieRepository Movie
        {
            get
            {
                if (_movie == null)
                {
                    _movie = new MovieRepository(_dataContext);
                }
                return _movie;
            }
        }

        public IPersonRepository Person
        {
            get
            {
                if (_person == null)
                {
                    _person = new PersonRepository(_dataContext);
                }
                return _person;
            }
        }

        public IRoleRepository Role
        {
            get
            {
                if (_role == null)
                {
                    _role = new RoleRepository(_dataContext);
                }
                return _role;
            }
        }

        public ISeasonRepository Season
        {
            get
            {
                if (_season == null)
                {
                    _season = new SeasonRepository(_dataContext);
                }
                return _season;
            }
        }

        public ISeriesRepository Series
        {
            get
            {
                if (_series == null)
                {
                    _series = new SeriesRepository(_dataContext);
                }
                return _series;
            }
        }
        public RepositoryWrapper(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Save()
        {
            _dataContext.SaveChanges();
        }
    }
}
