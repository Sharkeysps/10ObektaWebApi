﻿using System;
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
                    updateTourist.Username = newTourist.Username;
                    db.SaveChanges();
                    
                }
            }
        }

        public bool CheckIfUsernameExists(string userName)
        {
            using (var db = new SitesEntities())
            {
                var usernameExists = (from t in db.Tourists
                                       where t.Username.Equals(userName) == true
                                       select t).FirstOrDefault();
                if (usernameExists != null)
                {
                    return true;
                }

            }
            return false;
        }

        public ProgressAndMessageModel ReturnTouristPlace(string androidId)
        {
            ProgressAndMessageModel progress = new ProgressAndMessageModel();

            using (var db = new SitesEntities())
            {

                var searchedTourist=(from tourist in db.Tourists
                                       where tourist.AndroidID.Equals(androidId) == true
                                       select tourist).FirstOrDefault();
                if (searchedTourist != null)
                {
                    var listOfTourists = db.Tourists.OrderBy(v => v.VisitedSites).ToList();
                    listOfTourists.Reverse();
                    int place = listOfTourists.IndexOf(searchedTourist);
                    progress.ProgressNumber = place;
                    if(!String.IsNullOrWhiteSpace(searchedTourist.MessageToUser))
                    {
                    progress.Message = searchedTourist.MessageToUser;
                    }
                    return progress;
                }

            }
            return progress;
        }
    }
}