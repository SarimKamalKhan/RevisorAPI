using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RevisorAPI.Models
{
    public class Register
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id { get; set; }
      

        [BsonElement("Email")]
        public string email { get; set; }

        [BsonElement("Password")]
        public string password { get; set; }
    }
}