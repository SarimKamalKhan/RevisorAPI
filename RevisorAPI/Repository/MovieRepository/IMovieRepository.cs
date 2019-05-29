using RevisorAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisorAPI.Repository
{
    interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllMovie();

        Task<IEnumerable<Movie>> GetMovieByTitle(string title);

        Task<Movie> GetMovieByObjectID(string id, string title);

    }
}
