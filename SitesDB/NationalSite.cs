
//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace SitesDB
{

using System;
    using System.Collections.Generic;
    
public partial class NationalSite
{

    public NationalSite()
    {

        this.SiteComments = new HashSet<SiteComment>();

        this.SiteEvents = new HashSet<SiteEvent>();

    }


    public int ID { get; set; }

    public string Name { get; set; }

    public string City { get; set; }

    public int Number { get; set; }



    public virtual ICollection<SiteComment> SiteComments { get; set; }

    public virtual ICollection<SiteEvent> SiteEvents { get; set; }

}

}
