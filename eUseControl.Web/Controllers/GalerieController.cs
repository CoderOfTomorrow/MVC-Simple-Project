using eUseControl.BusinessLogic.DBModel;
using eUseControl.Domain.Entites.Images;
using eUseControl.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace eUseControl.Web.Controllers
{
    public class GalerieController : Controller
    {
        // GET: Galerie
        public ActionResult Index()
        {
            IDbTable view_img = new IDbTable();
            using (ImageContext db =new ImageContext())
            {
                if (db.Images.OrderByDescending(p => p.ImageID).FirstOrDefault() != null)
                {
                    IDbTable last = db.Images.OrderByDescending(p => p.ImageID).FirstOrDefault();
                    PImageData new_list = new PImageData
                    {
                        ImageList = new List<ImageData>()
                    };
                    for (int i = 1; i <= last.ImageID; i++)
                    {
                        view_img = db.Images.Where(x => x.ImageID == i).FirstOrDefault();
                        new_list.ImageList.Add(new ImageData()
                        {
                            ImageID = view_img.ImageID,
                            Title = view_img.Title,
                            ImagePath = view_img.ImagePath
                        });
                    }
     
                    return View(new_list);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Add(PImageData model)
        {
            var image = new ImageData()
            {
                ImageID = model.Image.ImageID,
                Title = model.Image.Title,
                ImagePath = model.Image.ImagePath,
                ImageFile = model.ImageFile
            };
            string fileName = Path.GetFileNameWithoutExtension(image.ImageFile.FileName);
            string extension = Path.GetExtension(image.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            image.ImagePath = "~/Images/Galerie/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Images/Galerie/"), fileName);
            image.ImageFile.SaveAs(fileName);

            IDbTable new_img = new IDbTable();

            using(ImageContext db = new ImageContext())
            {
                new_img.ImageID = image.ImageID;
                new_img.Title = image.Title;
                new_img.ImagePath = image.ImagePath;

                db.Images.Add(new_img);
                db.SaveChanges();
            }
            return RedirectToAction("Index","Galerie");
        }
    }
}