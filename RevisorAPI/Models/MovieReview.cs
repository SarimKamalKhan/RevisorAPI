using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RevisorAPI.Models
{
    public class MovieReview
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId MovieObjectID { get; set; }
        public string ReviewTitle { get; set; }
        public string Review { get; set; }
        public string UserName { get; set; }
        public string UserNameLink { get; set; }
        public string ReviewDateAdded { get; set; }
        public string Rating { get; set; }
        public string FullReviewLink { get; set; }
        public string ReviewSource { get; set; }
    }
}