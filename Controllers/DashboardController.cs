using InternalBookingApp.Interfaces;
using InternalBookingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace InternalBookingApp.Controllers
{
    public class DashboardController(IStatsService statsService) : Controller
    {
        private readonly IStatsService _statsService = statsService;

        [Route("")]
        [Route("/Index/Dashboard")]
        [Route("Index")]
        public async Task<ActionResult> Index()
        {
            var model = new Dashboard
            {
                TotalResources = await _statsService.GetTotalResources(),
                AvailableResources = await _statsService.GetTotalAvailableResources(),
                ResourcesInMaintenance = await _statsService.GetTotalInMaintenceResources(),
                TodaysBookingsCount = await _statsService.GetTodaysBookings(),
                TotalCancelledBookings = await _statsService.GetTotalCancelled(),
                UpcomingBookings = await _statsService.GetUpcomingBookings()
            };

            return View(model);
        }

    }
}
