using System;
using InternalBookingApp.Data;
using InternalBookingApp.DTOs.Resource;
using InternalBookingApp.Interfaces;
using InternalBookingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InternalBookingApp.Repositories;

public class ResourceRepo(ApplicationDbContext context) : IResourceRepo
{

    private readonly ApplicationDbContext _context = context;

    public async Task<Resource> GetResourceById(int Id)
    {
        return (await _context.Resources.FirstOrDefaultAsync((res) => res.Id == Id))!;
    }

    public async Task<IEnumerable<Resource>> GetAllResources()
    {
        return await _context.Resources.ToListAsync();
    }

    public async Task RemoveResource(int Id)
    {
        var res = await GetResourceById(Id);
        if (res != null)
        {
            _context.Resources.Remove(res);
            await _context.SaveChangesAsync();
        }
    }

    public async Task CreateResource(CreateResourceDto resource)
    {
        await _context.AddAsync(resource);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateResource(UpdateResourceDto resource, int Id)
    {
        var res = await GetResourceById(Id);
        if (res != null)
        {
            res.Name = resource.Name;
            res.Description = resource.Description;
            res.Capacity = resource.Capacity;
            res.Location = resource.Location;
            res.IsAvailable = resource.IsAvailable;
            await _context.SaveChangesAsync();
        }
    }
}
