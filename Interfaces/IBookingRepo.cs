using System;
using InternalBookingApp.Models;

namespace InternalBookingApp.Interfaces;

public interface IBookingRepo
{
    Task<IEnumerable<Booking>> GetAllBookings();

    Task<Booking?> GetBookingById(int Id);

    Task CreateBooking(Booking booking);

    Task EditBooking(Booking booking);

    Task RemoveBooking(int Id);

    Task CancelOrder(int Id);

    // main application logic
    Task<bool> HasBookingConflicts(int ResourceId, DateTime StartTime, DateTime EndTime, int? bookingId = null);
    Task<IEnumerable<Booking>> GetBookingByResource(int Id);
    Task<IEnumerable<Booking>> GetUpcomingBookings(int daysUpcoming = 7);
}
