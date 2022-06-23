﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IGenreRepository : IRepositoryBase<Genre>
    {
        IEnumerable<Genre> GetAllGenres();
        Genre GetGenreById(int genreID);
        void CreateGenre(Genre genre);
        void UpdateGenre(Genre genre);
        void DeleteGenre(Genre genre);
    }
}
