using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ObektiApi.Models;

namespace ObektiApi.Controllers
{
    public class EventController : ApiController
    {
        // GET api/event/5
        public SiteEventsModel Get(int id)
        {
            var foundEvents = new SiteEventsModel();
            foundEvents.FindEvents(id);
            return foundEvents;
        }

        // POST api/comment
        public void Post([FromBody]PostedEventModel Event)
        {
            var newEvent = new SiteEventsModel();
            newEvent.SaveEvent(Event);
        }

    }
}
