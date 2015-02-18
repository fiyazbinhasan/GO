using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GOBD.MODEL
{
    public class Coordinate
    {
        [BsonRepresentation(BsonType.Double)]
        public double Latitude { get; set; }

        [BsonRepresentation(BsonType.Double)]
        public double Longitude { get; set; }
    }
}
