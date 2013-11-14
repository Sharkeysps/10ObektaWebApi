using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ObektiApi.Models;
namespace ObektiApi.Controllers
{
    public class TouristController : ApiController
    {
        // GET api/tourist
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/tourist/?androidId
        public int Get(string androidId)
        {
            var model = new TouristModel();
            var place = model.ReturnTouristPlace(androidId);
            return place;
        }

        // POST api/tourist
        public void Post([FromBody]NewTouristModel newTourist)
        {
            var model = new TouristModel();
            model.SaveTourist(newTourist);
        }

        //// PUT api/tourist/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/tourist/5
        //public void Delete(int id)
        //{
        //}
    }
}
