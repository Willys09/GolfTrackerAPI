using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GolfTrackerAPI.Models
{
    public class Course
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CourseId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Par { get; set; }
        public ICollection<Tee> Tees { get; set; }
    }
}
