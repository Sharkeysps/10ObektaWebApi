using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitesDB;
namespace ObektiApi.Models
{
    public class TouristModel
    {
        public int Place { get; set; }

        public void SaveTourist(NewTouristModel newTourist)
        {
            using(var db=new SitesEntities())
            {
                var searchedTourist = (from t in db.Tourists
                                       where t.AndroidID.Equals(newTourist.AndroidID) == true
                                       select t).FirstOrDefault();
                if (searchedTourist == null)
                { 
                    Tourist addTourist=new Tourist();
                    addTourist.AndroidID=newTourist.AndroidID;
                    addTourist.Username=newTourist.Username;
                    addTourist.VisitedSites=0;
                    db.Tourists.Add(addTourist);
                    db.SaveChanges();
                }

                if (searchedTourist != null)
                {
                    var updateTourist = db.Tourists.Find(searchedTourist.ID);
                    updateTourist.VisitedSites = newTourist.VisitedSites;
                    db.SaveChanges();
                    
                }
            }
        }

        public int ReturnTouristPlace(string androidId)
        {
            using (var db = new SitesEntities())
            {
                var searchedTourist=(from t in db.Tourists
                                       where t.AndroidID.Equals(androidId) == true
                                       select t).FirstOrDefault();
                if (searchedTourist != null)
                {
                    var listOfTourists = db.Tourists.OrderBy(v => v.VisitedSites).ToList().Reverse();
                    int place = listOfTourists.IndexOf(searchedTourist);
                    return place;
                }

            }
            return -1;
        }
    }
}