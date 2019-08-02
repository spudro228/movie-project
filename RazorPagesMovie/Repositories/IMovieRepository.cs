using System.Collections.Generic;
using System.Threading.Tasks;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Repositories
{
    interface IMovieRepository
    {
        Task<IEnumerable<Movie>> ToListAsync();

        Task<Movie> FindAsync(params object[] keyValues);

    }
}