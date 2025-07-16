using InternalBookingApp.DTOs.Booking;

namespace InternalBookingApp.DTOs.Resource;

public record class ResourceDto(int Id,
    string Name,
    string Description,
    string Location,
    int Capacity,
    bool IsAvailable, BookingDto[]? Bookings = null)

{

}
