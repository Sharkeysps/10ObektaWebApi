//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DbModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class TouristSite
    {
        public TouristSite()
        {
            this.Events = new HashSet<Event>();
            this.Users = new HashSet<User>();
        }
    
        public int ID { get; set; }
        public string TouristSiteName { get; set; }
    
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
