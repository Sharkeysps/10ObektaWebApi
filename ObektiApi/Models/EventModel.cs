using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObektiApi.Models
{
    public class EventModel
    {
        public String Description { get; set; }
        public DateTime? DateOfEvent { get; set; }
        public int SiteID { get; set; }
    }
}