using System;
using InternalBookingApp.DTOs.Booking;
using InternalBookingApp.Interfaces;

namespace InternalBookingApp.Services;

public class DashboardService(IResourceService resourceService, IBookingService bookingService) : IStatsService
{
    private readonly IResourceService _resouce = resourceService;
    private readonly IBookingService _booking = bookingService;

    public async Task<int> GetTodaysBookings()
    {
        var today = DateTime.Today;
        var bookings = await _booking.GetAllBookings();
        var results = bookings.Where(booking => booking.StartTime == today || booking.EndTime == today);
        return results.Where(res => res.IsCancelled == false).Count();
    }

    public async Task<int> GetTotalAvailableResources()
    {
        var resources = await _resouce.GetAllResources();
        var total = resources.Where(res => res.IsAvailable == true).Count();
        return total;
    }

    public async Task<int> GetTotalInMaintenceResources()
    {
        var resources = await _resouce.GetAllResources();
        var total = resources.Where(res => res.IsAvailable == false).Count();
        return total;
    }

    public async Task<int> GetTotalResources()
    {
        var resources = await _resouce.GetAllResources();
        var total = resources.Count();
        return total;
    }

    public Task<IEnumerable<BookingDto>> GetUpcomingBookings()
    {
        var bookings = _booking.GetAllBookings();
        var upcomingBookings = bookings.Result.Where(booking => booking.StartTime > DateTime.Now && booking.IsCancelled == false);
        return Task.FromResult(upcomingBookings);
    }
}
