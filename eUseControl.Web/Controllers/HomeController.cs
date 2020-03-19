using eUseControl.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace eUseControl.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            /*UserData u = new UserData();
            u.Username = "Nicu";
            u.Products = new List<string> { "One #1", "One #2", "One #3" };*/
            return View();
        }
    }
}