using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using RevisorAPI.Models;

namespace RevisorAPI.Repository.MovieReviewRepository
{
    public class MovieReviewRepository : IMovieReviewRepository
    {
        IMongoDatabase _db = null;
        public MovieReviewRepository(string connection = "mongodb://localhost:27017")
        {
            var _client = new MongoClient(connection);
            _db = _client.GetDatabase("RevisorMovie");
        }

        public async Task<IEnumerable<MovieReview>> GetIMDBMovieReviewsByObjectID(string id, string title)
        {
            try
            {
                IMongoCollection<MovieReview> _moviesReview = _db.GetCollection<MovieReview>("Movies_Reviews_" + title[0].ToString().ToUpper());
                return await _moviesReview
                                .Find(movieReview => movieReview.MovieObjectID == ObjectId.Parse(id) && movieReview.ReviewSource == "IMDB")
                                .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<MovieReview>> GetMTCMovieReviewsByObjectID(string id, string title)
        {
            try
            {
                IMongoCollection<MovieReview> _moviesReview = _db.GetCollection<MovieReview>("Movies_Reviews_" + title[0].ToString().ToUpper());
                return await _moviesReview
                                .Find(movieReview => movieReview.MovieObjectID == ObjectId.Parse(id) && movieReview.ReviewSource == "MTC")
                                .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<MovieReview>> GetROTTMovieReviewsByObjectID(string id, string title)
        {
            try
            {
                IMongoCollection<MovieReview> _moviesReview = _db.GetCollection<MovieReview>("Movies_Reviews_" + title[0].ToString().ToUpper());
                return await _moviesReview
                                .Find(movieReview => movieReview.MovieObjectID == ObjectId.Parse(id) && movieReview.ReviewSource == "ROTT")
                                .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}