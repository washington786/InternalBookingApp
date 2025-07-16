using System;
using InternalBookingApp.DTOs.Booking;

namespace InternalBookingApp.Interfaces;

public interface IStatsService
{
    Task<int> GetTotalResources();
    Task<int> GetTotalAvailableResources();
    Task<int> GetTotalInMaintenceResources();
    Task<int> GetTodaysBookings();
    Task<IEnumerable<BookingDto>> GetUpcomingBookings();
}
