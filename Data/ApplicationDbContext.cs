using System;
using InternalBookingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InternalBookingApp.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Resource>().HasMany(r => r.Bookings).WithOne(r => r.Resource).HasForeignKey(r => r.ResourceId);
    }

    public DbSet<Resource> Resources { get; set; }

    public DbSet<Booking> Bookings { get; set; }

}
