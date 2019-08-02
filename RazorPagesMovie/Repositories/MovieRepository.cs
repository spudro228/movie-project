
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;
using JetBrains.Annotations;

namespace RazorPagesMovie.Repositories
{

    public class MovieRepository : IMovieRepository
    {

        private readonly RazorPagesMovieContext _context;
        public MovieRepository(RazorPagesMovieContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> ToListAsync()
        {
            return await _context.Movie.ToListAsync();

        }

        public async Task<Movie> FindAsync(params object[] keyValues)
        {
            return await _context.Movie.FindAsync(keyValues);
        }

    }
}