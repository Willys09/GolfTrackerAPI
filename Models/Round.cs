using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GolfTrackerAPI.Models
{
    public class Round
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string RoundId { get; set; }
        public DateTime Date { get; set; }
        public int Score { get; set; }
        public Tee Tee { get; set; }
    }
}
