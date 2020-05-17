using eUseControl.Controllers.Atributes;
using System.Web.Mvc;

namespace eUseControl.Web.Controllers
{
    public class AdminController : Controller
    {
        [AdminMod]
        public ActionResult Index()
        {
            string msg = "Rolul dumneavostra este de administrator";

            return View(msg);
        }
    }
}