using System;
using InternalBookingApp.DTOs.Resource;

namespace InternalBookingApp.Interfaces;

public interface IResourceService
{
    Task<IEnumerable<ResourceDto>> GetAllResources();
    Task<ResourceDto?> GetResourceById(int Id);
    Task<ResourceDto> CreateResource(CreateResourceDto request);
    Task UpdateResource(int Id, UpdateResourceDto request);
    Task RemoveResource(int Id);
}
