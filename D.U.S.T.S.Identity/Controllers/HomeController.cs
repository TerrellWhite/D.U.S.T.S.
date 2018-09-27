using D.U.S.T.S.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace D.U.S.T.S.Identity.Controllers
{
    public class HomeController : Controller
    {
        //[ValidateAntiForgeryToken]
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [Authorize]
        public ActionResult Artist()
        {
            dustEntities ORM = new dustEntities();
            ViewBag.Artistinfo = ORM.artistinformations;
            return View();
        }
        [Authorize(Roles = "admin")]
        public ActionResult AdminArtist()
        {
            dustEntities ORM = new dustEntities();
            ViewBag.Artistinfo = ORM.artistinformations;
            return View();
        }
        [Authorize(Roles = "admin")]
        public ActionResult Add()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        public ActionResult AddArtist(artistinformation newArtist)
        {
            dustEntities ORM = new dustEntities();
            ORM.artistinformations.Add(newArtist);
            ORM.SaveChanges();
            return RedirectToActionPermanent("AdminArtist");
        }
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int artistid)
        {
            dustEntities ORM = new dustEntities();
            artistinformation Artistedit = ORM. artistinformations.Find(artistid);
            if (Artistedit == null)
            {
                return RedirectToAction("AdminArtist");
            }
            ViewBag.Artistedit = Artistedit;
            return View();
        }
        public ActionResult SaveChanges(artistinformation UpdatedItem)
        {
            dustEntities ORM = new dustEntities(); //need this is every operation that takes in information
            //find the old record
            artistinformation OldRecord = ORM.artistinformations.Find(UpdatedItem.artistid);
            //ToDo check for null
            OldRecord.soundcloud = UpdatedItem.soundcloud;
            OldRecord.website = UpdatedItem.website; 
            OldRecord.genre = UpdatedItem.genre; 
            OldRecord.spotify = UpdatedItem.spotify; 
            OldRecord.youtube = UpdatedItem.youtube; 
            OldRecord.email = UpdatedItem.email; 
            OldRecord.twitter = UpdatedItem.twitter; 
            OldRecord.instagram = UpdatedItem.instagram; 
            OldRecord.facebook = UpdatedItem.facebook; 
            OldRecord.popularcity = UpdatedItem.popularcity; 
            ORM.Entry(OldRecord).State = System.Data.Entity.EntityState.Modified;
            ORM.SaveChanges();

            return RedirectToAction("AdminArtist");
        }
        public ActionResult SearchArtistByName(string name)
        {
            dustEntities ORM = new dustEntities();//need this is every operation that takes in information
            ViewBag.Artistinfo = ORM.artistinformations.Where(x => x.artistname.ToLower().Contains(name.ToLower())|| x.genre.ToLower().Contains(name.ToLower())).ToList();

            return View("Artist");
        }
        public ActionResult SearchAdminArtistByName(string name)
        {
            dustEntities ORM = new dustEntities();//need this is every operation that takes in information
            ViewBag.Artistinfo = ORM.artistinformations.Where(x => x.artistname.ToLower().Contains(name.ToLower()) || x.genre.ToLower().Contains(name.ToLower())).ToList();

            return View("AdminArtist");
        }
        public ActionResult Page(int artistid)
        {
            dustEntities ORM = new dustEntities();
            artistinformation Artist = ORM.artistinformations.Find(artistid);
            if (Artist == null)
            {
                return RedirectToAction("Artist");
            }
            ViewBag.Artist = Artist;
            return View();
        }
    }
}