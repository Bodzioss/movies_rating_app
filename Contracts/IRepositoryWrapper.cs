using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        public IEpisodeRepository Episode { get; }
        public IGenreRepository Genre { get; }
        public IMovieGenreRepository MovieGenre { get;  }
        public IMoviePersonRepository MoviePerson { get; }
        public IPersonRepository Person { get;}
        public IRoleRepository Role { get;  }
        public ISeasonRepository Season { get;  }
        public ISeriesRepository Series { get;  }
        void Save();
    }
}
