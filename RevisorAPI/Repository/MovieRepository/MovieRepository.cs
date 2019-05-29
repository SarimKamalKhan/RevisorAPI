using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using RevisorAPI.Models;

namespace RevisorAPI.Repository.MovieRepository
{
    public class MovieRepository : IMovieRepository
    {
        IMongoDatabase _db = null;
        public MovieRepository(string connection = "mongodb://localhost:27017") {
            var _client = new MongoClient(connection);
            _db = _client.GetDatabase("RevisorMovie");
        }

        public async Task<IEnumerable<Movie>> GetAllMovie()
        {
            try
            {
                IMongoCollection<Movie> _movies = _db.GetCollection<Movie>("Movies");
                return await _movies.Find(f => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Movie>> GetMovieByTitle(string title)
        {
            try
            {
                IMongoCollection<Movie> _movies = _db.GetCollection<Movie>("Movies_" + title[0].ToString().ToUpper());
                var filter = new BsonDocument { { "Title", new BsonDocument { { "$regex", title }, { "$options", "i" } } } };
                return await _movies
                                .Find(filter)
                                .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Movie> GetMovieByObjectID(string id, string title)
        {
            try
            {
                IMongoCollection<Movie> _movies = _db.GetCollection<Movie>("Movies_" + title[0].ToString().ToUpper());
                return await _movies
                                .Find(movie => movie._id == ObjectId.Parse(id))
                                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}