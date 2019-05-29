using MongoDB.Bson;
using MongoDB.Driver;
using RevisorAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RevisorAPI.Repository.ReviewRepository
{
    public class ReviewRepository: IReview
    {
        IMongoDatabase _db = null;


        public ReviewRepository(string connection = "mongodb://localhost:27017")
        {
            var _client = new MongoClient(connection);
            _db = _client.GetDatabase("RevisorMovie");
        }


        public async Task<bool> AddReview(string email, string MovieID, string MovieTitle, string MovieYear, string Reviews)
        {
            try
            {


                var collec = _db.GetCollection<BsonDocument>("Review");


                var document = new BsonDocument
                {
                    {"Email",email },
                    {"MovieID",MovieID },
                    {"MovieTitle",MovieTitle },
                    {"MovieYear",MovieYear },
                      {"Reviews",Reviews }
                };


                await collec.InsertOneAsync(document);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<bool> RemoveReview(string email, string MovieID, string MovieTitle, string MovieYear, string Reviews)
        {
            try
            {


                var collec = _db.GetCollection<BsonDocument>("Review");


                var document = new BsonDocument
                {
                    {"Email",email },
                    {"MovieID",MovieID },
                    {"MovieTitle",MovieTitle },
                    {"MovieYear",MovieYear },
                      {"Reviews",Reviews }
                };



                collec.DeleteMany(document);
                return true;



            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public async Task<IEnumerable<Review>> GetReview(string email, string MovieID, string MovieTitle, string MovieYear, string Reviews)
        {
            try
            {
                //MovieID = MongoDB.Bson.ObjectId.GenerateNewId().ToString();

                IMongoCollection<Review> _GetReview = _db.GetCollection<Review>("Review");
                var filter = new BsonDocument {    {"Email",email },
                    {"MovieID",MovieID },
                    {"MovieTitle",MovieTitle },
                    {"MovieYear",MovieYear },
                {"Reviews",Reviews } };

                return await _GetReview
                                .Find(filter)
                                .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}