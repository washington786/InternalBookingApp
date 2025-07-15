using Microsoft.AspNetCore.Mvc;

namespace InternalBookingApp.Controllers
{
    public class BookingsController : Controller
    {
        // GET: BookingsController
        public ActionResult Index()
        {
            return View();
        }

    }
}
