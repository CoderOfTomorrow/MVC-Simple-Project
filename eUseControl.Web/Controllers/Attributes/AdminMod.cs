using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Enums;
using eUseControl.Web.Extension;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace eUseControl.Controllers.Atributes
{
    public class AdminMod : ActionFilterAttribute
    {
        private readonly ISession _session;

        public AdminMod()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _session = bl.GetSessionBL();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var apiCooki = HttpContext.Current.Request.Cookies["X-KEY"];
            if(apiCooki != null)
            {
                var profile = _session.GetUserByCookie(apiCooki.Value);
                if(profile != null && profile.Level == URole.Admin)
                {
                    HttpContext.Current.SetMySessionObject(profile);
                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult(new
                        RouteValueDictionary(new { controller = "Error", action = "Error404" }));
                }
            }

        }
    }
}