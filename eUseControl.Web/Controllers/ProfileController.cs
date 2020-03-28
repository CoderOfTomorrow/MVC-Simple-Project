using eUseControl.Web.Extension;
using eUseControl.Web.Models;
using System.Web.Mvc;

namespace eUseControl.Web.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }
    }
}