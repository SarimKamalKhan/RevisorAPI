using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RevisorAPI.Models;

namespace RevisorAPI.Repository.MovieReviewRepository
{
    interface IMovieReviewRepository
    {
        Task<IEnumerable<MovieReview>> GetIMDBMovieReviewsByObjectID(string id, string title);

        Task<IEnumerable<MovieReview>> GetROTTMovieReviewsByObjectID(string id, string title);

        Task<IEnumerable<MovieReview>> GetMTCMovieReviewsByObjectID(string id, string title);
    }
}
