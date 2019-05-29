using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RevisorAPI.Models
{
    public class Review
    {
        [BsonId]
        public ObjectId _id { get; set; }

        [BsonElement("Email")]
        public string email { get; set; }

        //[BsonRepresentation(BsonType.ObjectId)]
        public string MovieID { get; set; }
        public string MovieTitle { get; set; }

        public string MovieYear { get; set; }

        public string Reviews { get; set; }
    }
}