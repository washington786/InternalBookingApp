namespace InternalBookingApp.DTOs.Booking;

public record class BookingDto(int Id, DateTime StartTime, DateTime EndTime, string Purpose, string BookedBy, int ResourceId, string? Resource, bool IsCancelled)
{
}
