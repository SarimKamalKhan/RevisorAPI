using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RevisorAPI.Models
{
    public class Movie
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public string Certificate { get; set; }
        public string[] Genre { get; set; }
        public _Link Link { get; set; }
        public _Rating Rating { get; set; }
        public string RunTime { get; set; }
        public object Year { get; set; }
        public string[] Actors { get; set; }
        public string[] Directors { get; set; }
        public string[] Files { get; set; }

        [NotMapped]
        public class _Link
        {
            public string ROTT { get; set; }
            public string IMDB { get; set; }
        }

        [NotMapped]
        public class _Rating
        {
            public _ROTT ROTT { get; set; }
            public double? IMDB { get; set; }

            public class _ROTT
            {
                public int tomatoScore { get; set; }
                public int popcornScore { get; set; }
            }
        }
    }

    

    

}