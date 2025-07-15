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
            _context.Bookings.Update(book);
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

    public Task<IEnumerable<Booking>> GetBookingByResource(int Id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Booking>> GetUpcomingBookings(int daysUpcoming = 5)
    {
        throw new NotImplementedException();
    }

    public Task<bool> HasBookingConflicts(int ResourceId, DateTime StartTime, DateTime EndTime, int? bookingId = null)
    {
        throw new NotImplementedException();
    }
}
