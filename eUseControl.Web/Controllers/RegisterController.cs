using eUseControl.Web.Models;
using System.Web.Mvc;
using eUseControl.Domain.Entites.User;
using eUseControl.BusinessLogic.Interfaces;

namespace eUseControl.Web.Controllers
{
    public class RegisterController : Controller
    {

        private readonly IRegister _register;
        // GET: Login
        public RegisterController()
        {
            var re = new BusinessLogic.BusinessLogic();
            _register = re.GetRegisterBL();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserRegister user)
        {
            URegisterData data = new URegisterData
            {
                Nume = user.Nume,
                Parola = user.Parola,
                Email = user.Email
            };

            _register.UserRegister(data);

            return View();
        }
    }
}