using System;
using InternalBookingApp.Models;

namespace InternalBookingApp.Interfaces;

public interface IResourceRepo
{
    Task<Resource> GetResourceById(int Id);
    Task<IEnumerable<Resource>> GetAllResources();

    Task CreateResource(Resource resource);

    Task UpdateResource(Resource resource, int Id);

    Task RemoveResource(int Id);
}
