using MongoDB.Bson;
using MongoDB.Driver;
using RevisorAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RevisorAPI.Repository.FavouriteRepository
{
    public class FavouriteRepository : IFavourite
    {

        IMongoDatabase _db = null;


        public FavouriteRepository(string connection = "mongodb://localhost:27017")
        {
            var _client = new MongoClient(connection);
            _db = _client.GetDatabase("RevisorMovie");
        }


        public async Task<bool> Addfavourite(string email, string MovieID, string MovieTitle, string MovieYear)
        {
            try
            {


                var collec = _db.GetCollection<BsonDocument>("Favourite");


                var document = new BsonDocument
                {
                    {"Email",email },
                    {"MovieID",MovieID },
                    {"MovieTitle",MovieTitle },
                    {"MovieYear",MovieYear }
                };


                await collec.InsertOneAsync(document);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<bool> Removefavourite(string email, string MovieID, string MovieTitle, string MovieYear)
        {
            try
            {


                var collec = _db.GetCollection<BsonDocument>("Favourite");


                var document = new BsonDocument
                {
                    {"Email",email },
                    {"MovieID",MovieID },
                    {"MovieTitle",MovieTitle },
                    {"MovieYear",MovieYear }
                };



                collec.DeleteMany(document);
                return true;



            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public async Task<IEnumerable<Favourite>> GetFavourites(string email, string MovieID, string MovieTitle, string MovieYear)
        {
            try
            {
                //MovieID = MongoDB.Bson.ObjectId.GenerateNewId().ToString();

                IMongoCollection<Favourite> _GetUser = _db.GetCollection<Favourite>("Favourite");
                var filter = new BsonDocument {    {"Email",email },
                    {"MovieID",MovieID },
                    {"MovieTitle",MovieTitle },
                    {"MovieYear",MovieYear } };

                return await _GetUser
                                .Find(filter)
                                .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Favourite>> GetFavourites(string email)
        {
            try
            {
                //MovieID = MongoDB.Bson.ObjectId.GenerateNewId().ToString();

                IMongoCollection<Favourite> _GetUser = _db.GetCollection<Favourite>("Favourite");
                var filter = new BsonDocument {    {"Email",email }};

                return await _GetUser
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