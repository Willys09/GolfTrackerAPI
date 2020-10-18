using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GolfTrackerAPI.Models
{
    public class Tee
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TeeId { get; set; }

        public string Color { get; set; }
        public long Yardage { get; set; }
        public long Slope { get; set; }
        public long Rating { get; set; }
        public Course Course { get; set; }

        public ICollection<Round> Round { get; set; }

    }
}
