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

        // GET api/tourist/?androidId
        [HttpGet]
        [ActionName("GetProgress")]
        public ProgressAndMessageModel Get(string androidId)
        {
            var model = new TouristModel();
            var progress = model.ReturnTouristPlace(androidId);
            return progress;
        }

        [HttpGet]
        [ActionName("CheckUsername")]
        public bool checkUsername(string userName)
        {
            var model = new TouristModel();
            var usernameExists = model.CheckIfUsernameExists(userName);
            return usernameExists;
        }



        // POST api/tourist
        public void Post([FromBody]NewTouristModel newTourist)
        {
            var model = new TouristModel();
            model.SaveTourist(newTourist);
        }
    }
}
