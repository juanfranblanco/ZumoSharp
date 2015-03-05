using System.Web.Mvc;

namespace ZumoSharp.Demo.Web.Controllers
{
	public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
