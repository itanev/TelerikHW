using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Linq;

namespace _01.Mongo
{
    public class Word
    {
        [BsonId]
        public MongoDB.Bson.ObjectId _id { get; set; }
        public string TheWord { get; set; }
        public string Translation { get; set; }
    }
}
