using System.Web.Mvc;
using eUseControl.Web.Extension;
using eUseControl.Web.Models;

namespace eUseControl.Web.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            SessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] == "login")
            {
                var user = System.Web.HttpContext.Current.GetMySessionObject();
                UserLogin u = new UserLogin
                {
                    Credential = user.Username,
                };
                return View(u);
            }
            return View();
        }
    }
}