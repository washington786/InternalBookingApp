using System;
using InternalBookingApp.Data;
using InternalBookingApp.Interfaces;
using InternalBookingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InternalBookingApp.Repositories;

public class BookingRepo(ApplicationDbContext dbContext) : IBookingRepo
{
    private readonly ApplicationDbContext _context = dbContext;

    public async Task CreateBooking(Booking booking)
    {
        await _context.Bookings.AddAsync(booking);
        await _context.SaveChangesAsync();
    }

    public async Task EditBooking(Booking booking)
    {
        var book = await GetBookingById(booking.Id);
        if (book != null)
        {
            book.BookedBy = booking.BookedBy;
            book.EndTime = booking.EndTime;
            book.Purpose = booking.Purpose;
            book.ResourceId = booking.ResourceId;
            book.StartTime = booking.StartTime;
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Booking>> GetAllBookings()
    {
        return await _context.Bookings.Include(b => b.Resource).OrderBy((b) => b.StartTime).ToListAsync();
    }

    public async Task<Booking?> GetBookingById(int Id)
    {
        return await _context.Bookings.Include(b => b.Resource).FirstOrDefaultAsync((b) => b.Id == Id);
    }

    public async Task RemoveBooking(int Id)
    {
        var booking = await GetBookingById(Id);

        if (booking != null)
        {
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Booking>> GetBookingByResource(int Id)
    {
        return await _context.Bookings.Where(b => b.ResourceId == Id).OrderBy(b => b.StartTime).ToListAsync();
    }

    public async Task<IEnumerable<Booking>> GetUpcomingBookings(int daysUpcoming = 7)
    {
        var today = DateTime.UtcNow;

        var endTime = today.AddDays(daysUpcoming);

        return await _context.Bookings.Where(b => b.StartTime >= today && b.StartTime <= endTime).OrderBy(b => b.StartTime)
        .ToListAsync();
    }

    public async Task<bool> HasBookingConflicts(int ResourceId, DateTime StartTime, DateTime EndTime, int? bookingId = null)
    {
        return await _context.Bookings.AnyAsync(b =>
         b.ResourceId == ResourceId &&
         StartTime < b.EndTime && EndTime > b.StartTime &&
         (!bookingId.HasValue || b.Id != bookingId.Value)
     );
    }
}
