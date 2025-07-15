using System;
using InternalBookingApp.DTOs.Booking;
using InternalBookingApp.Interfaces;
using InternalBookingApp.Models;

namespace InternalBookingApp.Services;

public class BookingService(IBookingRepo bookingRepo) : IBookingService
{
    private readonly IBookingRepo _bookingRepo = bookingRepo;

    public Task<BookingDto> CreateBooking(CreateBookingDto booking)
    {
        throw new NotImplementedException();
    }

    public async Task EditBooking(UpdateBookingDto booking, int Id)
    {
        var foundBooking = await _bookingRepo.GetBookingById(Id);

        if (foundBooking != null)
        {
            foundBooking.BookedBy = booking.BookedBy;
            foundBooking.EndTime = booking.EndTime;
            foundBooking.Purpose = booking.Purpose;
            foundBooking.ResourceId = booking.ResourceId;
            foundBooking.StartTime = booking.StartTime;

            await _bookingRepo.EditBooking(foundBooking);
        }
    }

    public async Task<IEnumerable<BookingDto>> GetAllBookings()
    {
        var bookings = await _bookingRepo.GetAllBookings();
        return bookings.Select(book => ToDto(book!));
    }

    public async Task<BookingDto?> GetBookingById(int Id)
    {

        var booking = await _bookingRepo.GetBookingById(Id);
        return booking != null ? ToDto(booking) : null;
    }

    public async Task RemoveBooking(int Id)
    {
        await _bookingRepo.RemoveBooking(Id);
    }


    // helper method
    private static BookingDto ToDto(Booking book)
    {
        return new BookingDto(
            Id: book.Id, BookedBy: book.BookedBy, EndTime: book.EndTime, Purpose: book.Purpose, StartTime: book.StartTime, ResourceId: book.ResourceId
        )
        { };
    }
}
