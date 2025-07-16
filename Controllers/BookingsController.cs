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


        public async Task<ActionResult> Edit(int Id)
        {
            var booking = await _bookingService.GetBookingById(Id);
            if (booking == null)
            {
                return NotFound();
            }

            var updateDto = new UpdateBookingDto(
                booking.Id,
                booking.StartTime,
                booking.EndTime,
                booking.Purpose,
                booking.BookedBy,
                booking.ResourceId
            );

            await GetResources();

            return View(updateDto);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int Id, UpdateBookingDto booking)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _bookingService.EditBooking(booking, Id);
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

        public async Task<ActionResult> Details(int Id)
        {
            var booking = await _bookingService.GetBookingById(Id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }


        [HttpPost, ActionName("Cancel")]
        public async Task<ActionResult> CancelBooking(int Id)
        {
            var booking = await _bookingService.GetBookingById(Id);
            if (booking != null)
            {
                await _bookingService.CancelBooking(Id);
                return RedirectToAction(nameof(Index));
            }
            return View(booking);
        }

        public async Task<ActionResult> Delete(int Id)
        {
            var booking = await _bookingService.GetBookingById(Id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteBooking(int Id)
        {
            var booking = await _bookingService.GetBookingById(Id);
            if (booking != null)
            {
                await _bookingService.RemoveBooking(Id);
                return RedirectToAction(nameof(Index));
            }

            return View(booking);
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
