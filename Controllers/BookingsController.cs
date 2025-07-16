using System.Threading.Tasks;
using InternalBookingApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InternalBookingApp.Controllers
{
    public class BookingsController(IBookingService bookingService, IResourceService resourceService) : Controller
    {
        private readonly IBookingService _bookingService = bookingService;
        private readonly IResourceService _res = resourceService;

        public async Task<ActionResult> Index()
        {
            var bookings = await _bookingService.GetAllBookings();

            return View(bookings);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var resource = await _res.GetAllResources();

            ViewData["Resources"] = resource.Select(r => new SelectListItem()
            {
                Value = r.Id.ToString(),
                Text = r.Name
            }).ToList();

            return View();
        }

        // [HttpPost]
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult Details()
        {
            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }

    }
}
