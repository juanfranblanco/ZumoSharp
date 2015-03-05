using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Zumo.Sharp.AspNet
{
    public class ZumoAuthorisationFilter : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var identity = Thread.CurrentPrincipal.Identity;
            if (identity == null && HttpContext.Current != null)
                identity = HttpContext.Current.User.Identity;

            if (identity != null && identity.IsAuthenticated)
            {
                return true;
            }

            return false;
        }
    }
}