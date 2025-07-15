using System;

namespace InternalBookingApp.Models;

public class Resource
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string Description { get; set; }

    public required string Location { get; set; }

    public int Capacity { get; set; }

    public bool IsAvailable { get; set; } = true;

}
