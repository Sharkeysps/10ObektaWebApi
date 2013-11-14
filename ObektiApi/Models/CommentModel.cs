using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObektiApi.Models
{
    public class CommentModel
    {
        public String Comment { get; set; }
        public DateTime? DateAdded { get; set; }
        public int SiteID { get; set; }
    }
}