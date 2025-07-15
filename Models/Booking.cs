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

    public int ResourceId { get; set; }
    [ForeignKey("ResourceId")]
    public required Resource Resource { get; set; }

}
