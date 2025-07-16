using System;
using InternalBookingApp.DTOs.Booking;
using InternalBookingApp.DTOs.Resource;
using InternalBookingApp.Interfaces;
using InternalBookingApp.Models;

namespace InternalBookingApp.Services;

public class ResourceService(IResourceRepo resourceRepo) : IResourceService
{
    private readonly IResourceRepo _resource = resourceRepo;

    public async Task<IEnumerable<ResourceDto>> GetAllResources()
    {
        var res = await _resource.GetAllResources();
        return res.Select((resource) => new ResourceDto(resource.Id, resource.Name, resource.Description, resource.Location, resource.Capacity, resource.IsAvailable));
    }

    public async Task<ResourceDto?> GetResourceById(int Id)
    {
        /* int Id, DateTime StartTime, DateTime EndTime, string Purpose, string BookedBy, int ResourceId, string? Resource, bool? IsCancelled = false */
        var resource = await _resource.GetResourceById(Id);

        return resource is not null ? new ResourceDto(
            resource.Id,
            resource.Name,
            resource.Description,
            resource.Location,
            resource.Capacity,
            resource.IsAvailable,
            resource.Bookings?.Select(b => new BookingDto(
                b.Id,
                b.StartTime,
                b.EndTime,
                b.Purpose,
                b.BookedBy,
                b.ResourceId,
                b.Resource?.Name,
                b.IsCancelled
            )).ToArray()
            ) : null;
    }

    public async Task<ResourceDto> CreateResource(CreateResourceDto request)
    {
        var resource = new Resource()
        {
            Name = request.Name,
            Description = request.Description,
            Location = request.Location,
            Capacity = request.Capacity,
            IsAvailable = request.IsAvailable,
        };

        await _resource.CreateResource(resource);

        return new ResourceDto(
            resource.Id,
             resource.Name,
           resource.Description,
            resource.Location,
            resource.Capacity,
            resource.IsAvailable
        );
    }

    public async Task RemoveResource(int Id)
    {
        await _resource.RemoveResource(Id);
    }

    public async Task UpdateResource(int Id, UpdateResourceDto request)
    {
        var resource = await _resource.GetResourceById(Id);
        if (resource != null)
        {
            resource.Name = request.Name;
            resource.Description = request.Description;
            resource.Capacity = request.Capacity;
            resource.Location = request.Location;
            resource.IsAvailable = request.IsAvailable;

            await _resource.UpdateResource(resource, Id);
        }
    }
}
