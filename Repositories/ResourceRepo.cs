using System;
using InternalBookingApp.Data;
using InternalBookingApp.Interfaces;
using InternalBookingApp.Models;

namespace InternalBookingApp.Repositories;

public class ResourceRepo(ApplicationDbContext context) : IResourceRepo
{
    private readonly ApplicationDbContext _context = context;

    public Task CreateResource(Resource resource)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Resource>> GetAllResources()
    {
        throw new NotImplementedException();
    }

    public Task<Resource> GetResourceById(int Id)
    {
        throw new NotImplementedException();
    }

    public Task RemoveResource(int Id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateResource(Resource resource, int Id)
    {
        throw new NotImplementedException();
    }
}
