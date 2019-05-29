using MongoDB.Driver;
using RevisorAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MongoDB.Bson;


namespace RevisorAPI.Repository.Registration
{
    public class RegistrationRepository : IRegistration
    {
        IMongoDatabase _db = null;

        public RegistrationRepository(string connection = "mongodb://localhost:27017")
        {
            var _client = new MongoClient(connection);
            _db = _client.GetDatabase("RevisorMovie");
        }

        public async Task<bool> User_Registration(string email, string password)
        {
            try
            {


                var collec = _db.GetCollection<BsonDocument>("Registration");


                var document = new BsonDocument
                {
                    {"Email",email },
                    {"Password",password }
                };

              
                await collec.InsertOneAsync(document);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<IEnumerable<Register>> CheckUserExistance(string email, string password)
        {
            try
            {
                IMongoCollection<Register> _GetUser = _db.GetCollection<Register>("Registration");
                var filter = new BsonDocument {  { "Email", email }, { "Password", password } };
                return await _GetUser
                                .Find(filter)
                                .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<IEnumerable<Register>> CheckUserExistance(string email)
        {
            try
            {
                IMongoCollection<Register> _GetUser = _db.GetCollection<Register>("Registration");
                var filter = new BsonDocument { { "Email", email } };
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