using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObektiApi.Models
{
    public class NewTouristModel
    {
        public string AndroidID { get; set; }
        public string Username { get; set; }
        public int VisitedSites { get; set; }
    }
}