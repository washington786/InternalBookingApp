using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternalBookingApp.Models;

public class Booking
{
    public int Id { get; set; }

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public required string BookedBy { get; set; }
    public required string Purpose { get; set; }

    public bool IsCancelled { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public int ResourceId { get; set; }
    [ForeignKey("ResourceId")]
    public Resource? Resource { get; set; }

}
