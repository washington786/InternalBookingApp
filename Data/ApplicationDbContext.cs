using System;
using InternalBookingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InternalBookingApp.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Resource> Resources { get; set; }

}
