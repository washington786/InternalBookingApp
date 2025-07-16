using System;
using InternalBookingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InternalBookingApp.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Resource>().HasData(
            new Resource
            {
                Id = 1,
                Name = "Conference Room A",
                Description = "Main conference room with video conferencing",
                Location = "Floor 1, West Wing",
                Capacity = 20,
                IsAvailable = true
            },
        new Resource
        {
            Id = 2,
            Name = "Training Room B",
            Description = "Training room with projector and whiteboards",
            Location = "Floor 2, East Wing",
            Capacity = 15,
            IsAvailable = false
        },
        new Resource
        {
            Id = 3,
            Name = "Executive Suite",
            Description = "Private meeting room for executive staff",
            Location = "Floor 3, North Wing",
            Capacity = 8,
            IsAvailable = true
        },
        new Resource
        {
            Id = 4,
            Name = "Open Workspace",
            Description = "Shared collaborative workspace",
            Location = "Floor 1, Central Area",
            Capacity = 50,
            IsAvailable = true
        },
        new Resource
        {
            Id = 5,
            Name = "Phone Booth",
            Description = "Soundproof booth for private calls",
            Location = "Floor 2, Near Elevators",
            Capacity = 1,
            IsAvailable = true
        }
        );
        modelBuilder.Entity<Resource>().HasMany(r => r.Bookings).WithOne(r => r.Resource).HasForeignKey(r => r.ResourceId);
    }

    public DbSet<Resource> Resources { get; set; }

    public DbSet<Booking> Bookings { get; set; }

}
