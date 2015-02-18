using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using GOBD.DATA;
using GOBD.MODEL;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GeoJsonObjectModel;
using MongoDB.Driver.Linq;

namespace GOBD.Controllers
{
    public class LocationController : ApiController
    {
        public GOBDContext GobdContext = new GOBDContext();
        // GET: api/Location
        public string Get()
        {
            var locations = GobdContext.Locations.FindAll();
            return locations.ToJson();
        }

        [Route("api/location/insert/")]
        [HttpGet]
        public string Insert(string lat, string lon)
        {
            var location = new Location { Coordinate = new Coordinate { Latitude = double.Parse(lat), Longitude = double.Parse(lon) } };
            GobdContext.Locations.Insert(location);

            var locations = GobdContext.Locations.FindAll();
            return locations.ToJson();
        }

        [Route("api/location/find/")]
        [HttpGet]
        public string Find(string lat, string lon)
        {
            var location = new Location { Coordinate = new Coordinate { Latitude = double.Parse(lat), Longitude = double.Parse(lon) } };

            GobdContext.Locations.CreateIndex(IndexKeys<Location>.Ascending(l =>l.Coordinate ));

            var query = Query.Near("Coordinate", location.Coordinate.Latitude, location.Coordinate.Longitude);
            var nearest = GobdContext.Locations.Find(query).First();

            return nearest.ToJson();
        }

        // GET: api/Location/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Location
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Location/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Location/5
        public void Delete(int id)
        {
        }

    }
}
