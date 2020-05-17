using AutoMapper;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entites.Images;
using eUseControl.Web.App_Start;
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
        private readonly IGalerie _galerie;
        public GalerieController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _galerie = bl.GetGalerieBL();
        }

        public ActionResult Index()
        {
            var data = _galerie.GetGalerieData();

            PImageData new_list = new PImageData {
                ImageList = new List<ImageData>()
            };

            foreach(var img in data)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Image, ImageData>());
                var local = Mapper.Map<ImageData>(img);
                new_list.ImageList.Add(local);
            }

            return View(new_list);
        }

        [HttpPost][AdminMod]
        public ActionResult Add(PImageData model)
        {
            string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
            string extension = Path.GetExtension(model.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            model.Image.ImagePath = "~/Images/Galerie/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Images/Galerie/"), fileName);
            model.ImageFile.SaveAs(fileName);


            
            IDbTable new_img = new IDbTable();

            Mapper.Initialize(cfg => cfg.CreateMap<ImageData, Image>());
            var image = Mapper.Map<Image>(model.Image);

            using (ImageContext db = new ImageContext())
            {
                new_img.ImageID = image.ImageID;
                new_img.Title = image.Title;
                new_img.ImagePath = image.ImagePath;

                db.Images.Add(new_img);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Galerie");
        }
    }
}