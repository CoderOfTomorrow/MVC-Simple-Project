using eUseControl.BusinessLogic.DBModel;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entites.Topics;
using eUseControl.Web.Models;
using eUseControl.Web.Models.Posts;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace eUseControl.Web.Controllers
{
    public class TopicController : Controller
    {

        private readonly IForum _forum;
        public TopicController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _forum = bl.GetForumBL();
        }

        
        public ActionResult Index()
        {
            Forum data = new Forum();
            /*using (ForumContext db = new ForumContext())
            {
                if (db.Forum.OrderByDescending(p => p.CategoryID).FirstOrDefault() != null)
                {
                    Forum last = db.Forum.OrderByDescending(p => p.CategoryID).FirstOrDefault();
                    PostData new_list = new PostData
                    {
                        List = new List<PCategoryData>()
                    };

                    for (int i = 1; i <= last.CategoryID; i++)
                    {
                        data = db.Forum.Where(x => x.CategoryID == i).FirstOrDefault();

                        PCategoryData category = data;
                        new_list.List.Add(category);
                    }
                    return View(new_list);
                }
            }*/ 
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(PCategoryData category)
        {
            var new_category = new CategoryData()
            {
                Title = category.Title
            };

            _forum.AddCategory(new_category);

            return RedirectToAction("Index","Topic");
        }

        [HttpPost]
        public ActionResult AddTopic()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSubject()
        {
            return View();
        }
    }
}