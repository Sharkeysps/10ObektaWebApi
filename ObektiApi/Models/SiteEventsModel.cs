using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitesDB;

namespace ObektiApi.Models
{
    public class SiteEventsModel
    {
       public List<EventModel> Events { get; set; }

       public SiteEventsModel()
        {
            this.Events = new List<EventModel>();
        }

        public void FindEvents(int siteId)
        {
            using (var db = new SitesEntities())
            {
                var events = (from e in db.SiteEvents
                                where e.SiteID == siteId
                                select e);

                foreach (var singleEvent in events)
                {
                    var eventModel = new EventModel();
                    eventModel.Description = singleEvent.EventDescription;
                    eventModel.SiteID = singleEvent.SiteID;
                    eventModel.DateOfEvent = singleEvent.DateOfEvent;
                    Events.Add(eventModel);

                }
                
            }

        }

        public void SaveEvent(PostedEventModel postedEvent)
        {
            using (var db = new SitesEntities())
            { 
                SiteEvent newEvent=new SiteEvent();
                newEvent.DateOfEvent = postedEvent.DateOfEvent;
                newEvent.EventDescription = postedEvent.EventDescription;
                newEvent.SiteID = postedEvent.SiteID;


                db.SiteEvents.Add(newEvent);
                db.SaveChanges();
            }
        }

    }
}