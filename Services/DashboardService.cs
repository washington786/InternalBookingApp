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

        return bookings.Count(booking =>
            (booking.StartTime.Date == today || booking.EndTime.Date == today) &&
            (booking.IsCancelled == false));
    }

    public async Task<int> GetTotalCancelled()
    {
        var bookings = await _booking.GetAllBookings();
        var total = bookings.Count(b => b.IsCancelled == true);
        return total;
    }

    public Task<IEnumerable<BookingDto>> GetUpcomingBookings()
    {
        var bookings = _booking.GetAllBookings();
        var upcomingBookings = bookings.Result.Where(booking => booking.StartTime.Date > DateTime.Today && booking.IsCancelled == false);
        return Task.FromResult(upcomingBookings);
    }

    public async Task<int> GetTotalInMaintenceResources()
    {
        var resources = await _resouce.GetAllResources();
        var total = resources.Where(res => res.IsAvailable == false).Count();
        return total;
    }
    public async Task<int> GetTotalAvailableResources()
    {
        var resources = await _resouce.GetAllResources();
        var total = resources.Where(res => res.IsAvailable == true).Count();
        return total;
    }

    public async Task<int> GetTotalResources()
    {
        var resources = await _resouce.GetAllResources();
        var total = resources.Count();
        return total;
    }

}
