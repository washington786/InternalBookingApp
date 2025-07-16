using System.Threading.Tasks;
using InternalBookingApp.DTOs.Booking;
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
            await GetResources();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateBookingDto booking)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var createdBooking = await _bookingService.CreateBooking(booking);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    ModelState.AddModelError("", ex.Message);
                }
            }

            await GetResources();

            return View(booking);
        }


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

        // helper Methods
        public async Task GetResources()
        {
            var resources = await _res.GetAllResources();
            ViewData["Resources"] = resources.Select(r => new SelectListItem
            {
                Value = r.Id.ToString(),
                Text = r.Name
            });

        }

    }
}
