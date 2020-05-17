using AutoMapper;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entites.Topics;
using eUseControl.Domain.Entites.User;
using eUseControl.Web.Models;
using eUseControl.Web.Models.Posts;
using System.Collections.Generic;
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
            var data = _forum.GetCategoryData();
            PostData new_forum = new PostData
            {
                CList = new List<PCategoryData>()
            };

            foreach(var d in data)
            {
                var topic = new List<PTopicData>();
                var cat = new PCategoryData()
                {
                    CategoryID = d.CategoryID,
                    Title = d.Title,
                    Topics = new List<PTopicData>()
                };

                foreach(var t in d.Topics)
                {
                    var local = new PTopicData()
                    {
                        TopicID = t.TopicID,
                        Title = t.Title
                    };
                    topic.Add(local);
                }
                cat.Topics = topic;
                new_forum.CList.Add(cat);
            }

            return View(new_forum);
        }

        public ActionResult Topic()
        {
            var data = _forum.GetTopicData(1);
            var new_topic = new PostData
            {
                Title = data.Title,
                SList = new List<PSubjectData>()
            };
            foreach(var l in data.Subjects)
            {
                var local = new PSubjectData
                {
                    SubjectID = l.SubjectID,
                    Text = l.Text,
                    Author = l.Author,
                    Title = l.Title
                };
                new_topic.SList.Add(local);
            };
            return View(new_topic);
        }

        [HttpPost]
        public ActionResult AddCategory(PostData category)
        {
            var new_category = new CategoryData()
            {
                Title = category.Title
            };

            _forum.AddCategory(new_category);

            return RedirectToAction("Index","Topic");
        }

        [HttpPost]
        public ActionResult AddTopic(PostData topic)
        {
            var id = topic.Id;
            var new_topic = new TopicData()
            {
                Title = topic.Title
            };

            _forum.AddTopic(new_topic,id);

            return RedirectToAction("Index","Topic");
        }

        [HttpPost]
        public ActionResult AddSubject(PostData subject)
        {
            var id = 1;
            var new_subject = new SubjectData()
            {
                Title = "Primul subiect",
                Text = "blablabla"
            };

            _forum.AddSubject(new_subject,id,1);

            return RedirectToAction("Index", "Topic");
        }
    }
}