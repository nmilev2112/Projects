using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace WebAppProject.Data.DTO
{
    public class Drink
    {
        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public string drink_name { get; set; }
        public Steps steps { get; set; }
    }
    public class Steps
    {
        public string step1 { get; set; }
        public string step2 { get; set; } = "";
        public string step3 { get; set; } = "";
        public string step4 { get; set; } = "";
    }
}
