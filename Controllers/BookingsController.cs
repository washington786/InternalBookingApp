using System.Threading.Tasks;
using InternalBookingApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InternalBookingApp.Controllers
{
    public class BookingsController(IBookingService bookingService) : Controller
    {
        private readonly IBookingService _bookingService = bookingService;

        public async Task<ActionResult> Index()
        {
            var bookings = await _bookingService.GetAllBookings();

            return View(bookings);
        }

        public ActionResult Create()
        {
            return View();
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

    }
}
