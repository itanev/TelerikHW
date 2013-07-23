using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpensesFromXML
{
    public class Sale
    {
        [BsonId]
        public MongoDB.Bson.ObjectId _id { get; set; }
        public int id { get; set; }
        public string Vendor { get; set; }
        public ICollection<Expense> Expenses { get; set; }
    }
}
