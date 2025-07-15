using System;
using InternalBookingApp.DTOs.Resource;
using InternalBookingApp.Models;

namespace InternalBookingApp.Interfaces;

public interface IResourceRepo
{
    Task<Resource> GetResourceById(int Id);
    Task<IEnumerable<Resource>> GetAllResources();

    Task CreateResource(CreateResourceDto resource);

    Task UpdateResource(UpdateResourceDto resource, int Id);

    Task RemoveResource(int Id);
}
