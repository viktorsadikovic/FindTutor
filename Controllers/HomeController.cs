using FindTutor.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FindTutor.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DodadiOglas(int id, Customer customer)
        {
            DatabaseDB db = new DatabaseDB();
            customer.FavoriteAnnouncements.Add(db.Announcements.Find(id));

            return View();
        }
    }
}