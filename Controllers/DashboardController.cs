using Microsoft.AspNetCore.Mvc;

namespace InternalBookingApp.Controllers
{
    public class Dashboard : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

    }
}
