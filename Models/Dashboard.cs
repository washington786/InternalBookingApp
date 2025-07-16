using System;
using InternalBookingApp.DTOs.Booking;

namespace InternalBookingApp.Models;

public class Dashboard
{
    public int TotalResources { get; set; }
    public int AvailableResources { get; set; }
    public int ResourcesInMaintenance { get; set; }
    public int TodaysBookingsCount { get; set; }
    public IEnumerable<BookingDto> UpcomingBookings { get; set; } = [];
}
