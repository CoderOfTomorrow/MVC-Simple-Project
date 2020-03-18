using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entites.User;
using eUseControl.Web.Models;
using System;
using System.Web.Mvc;

namespace eUseControl.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISession _session;
        // GET: Login
        public LoginController() {
            var bl = new BusinessLogic.BusinessLogic();
            _session = bl.GetSessionBL();
        }
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index(UserData user)
        {
            if (ModelState.IsValid)
            {
                ULoginData data = new ULoginData
                {
                    Login = user.Login,
                    Password = user.Password,
                    UserIp = Request.UserHostAddress,
                    UserLTime = DateTime.Now
                };

                /*var userLogin = _session.UserLogin(data);
                if (userLogin.Status)
                {
                    //ADD COOKIE

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", userLogin.StatusMsg);
                    return View();
                }*/

            }
            return View();
        }
    }
}