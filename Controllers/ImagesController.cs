using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FindTutor.Models;

namespace FindTutor.Controllers
{
    public class ImagesController : Controller
    {
        DbModels db = new DbModels();

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Image image)
        {
            string FileName = Path.GetFileNameWithoutExtension(image.ImageFile.FileName);
            string FileExtension = Path.GetExtension(image.ImageFile.FileName);

            FileName = FileName + DateTime.Now.ToString("yymmssfff") + FileExtension;
            image.Path = "~/Images/" + FileName;
            FileName = Path.Combine(Server.MapPath("~/Images/"), FileName);
            image.ImageFile.SaveAs(FileName);

            db.Images.Add(image);
            db.SaveChanges();

            return View();
        }

        [HttpGet]
        public ActionResult ShowImage(int id)
        {
            Image image = db.Images.Find(id);

            return View(image);
        }
    }
}