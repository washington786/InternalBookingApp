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
            var totalResources = await _statsService.GetTotalResources();
            var totalAvailableResources = await _statsService.GetTotalAvailableResources();
            var totalInMaintenanceResources = await _statsService.GetTotalInMaintenceResources();
            var todaysBookings = await _statsService.GetTodaysBookings();
            var upcomingBookings = await _statsService.GetUpcomingBookings();

            var model = new Dashboard
            {
                TotalResources = totalResources,
                AvailableResources = totalAvailableResources,
                ResourcesInMaintenance = totalInMaintenanceResources,
                TodaysBookingsCount = todaysBookings,
                UpcomingBookings = upcomingBookings
            };

            return View(model);
        }

    }
}
