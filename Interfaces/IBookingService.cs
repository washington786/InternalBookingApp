using System;
using InternalBookingApp.DTOs.Booking;

namespace InternalBookingApp.Interfaces;

public interface IBookingService
{
    Task<IEnumerable<BookingDto>> GetAllBookings();

    Task<BookingDto?> GetBookingById(int Id);

    Task<BookingDto> CreateBooking(CreateBookingDto booking);

    Task EditBooking(UpdateBookingDto booking, int Id);

    Task RemoveBooking(int Id);
}

