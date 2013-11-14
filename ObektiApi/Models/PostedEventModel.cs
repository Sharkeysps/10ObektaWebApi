using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObektiApi.Models
{
    public class PostedEventModel
    {
        public string EventDescription { get; set; }
        public Nullable<System.DateTime> DateOfEvent { get; set; }
        public int SiteID { get; set; }
    }
}