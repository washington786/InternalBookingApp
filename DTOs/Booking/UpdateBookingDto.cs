using System.ComponentModel.DataAnnotations;

namespace InternalBookingApp.DTOs.Booking;

public record class UpdateBookingDto(int? Id,
    [Required] DateTime StartTime,
     [Required] DateTime EndTime,
     [Required] string Purpose,
     [Required] string BookedBy,
      int ResourceId)
{

}
