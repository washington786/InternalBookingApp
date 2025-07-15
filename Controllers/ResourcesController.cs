using System.Threading.Tasks;
using InternalBookingApp.DTOs.Resource;
using InternalBookingApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InternalBookingApp.Controllers
{
    public class ResourcesController(IResourceService resourceService) : Controller
    {
        private readonly IResourceService _resourceService = resourceService;

        public async Task<ActionResult> Index()
        {
            var resources = await _resourceService.GetAllResources();
            return View(resources);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateResourceDto resourceDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TempData["Message"] = "Resource created successfully.";
                    TempData["MessageType"] = "success";
                    await _resourceService.CreateResource(resourceDto);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(resourceDto);
        }

        public async Task<ActionResult> Edit(int Id)
        {
            var resource = await _resourceService.GetResourceById(Id);
            if (resource == null)
            {
                return NotFound();
            }
            return View(resource);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int Id, UpdateResourceDto resourceDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TempData["Message"] = "Resource updated successfully.";
                    TempData["MessageType"] = "success";
                    await _resourceService.UpdateResource(Id, resourceDto);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }

            }
            return View(resourceDto);
        }

        public async Task<ActionResult> Details(int Id)
        {
            var resource = await _resourceService.GetResourceById(Id);
            if (resource == null)
            {
                return NotFound();
            }
            return View(resource);
        }
        public async Task<ActionResult> Delete(int Id)
        {
            var resource = await _resourceService.GetResourceById(Id);
            if (resource == null)
            {
                return NotFound();
            }
            return View(resource);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int Id)
        {
            var resource = await _resourceService.GetResourceById(Id);
            if (resource != null)
            {
                try
                {
                    await _resourceService.RemoveResource(Id);
                    TempData["Message"] = "Resource deleted successfully.";
                    RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    TempData["Message"] = $"Error deleting resource: {ex.Message}";
                    TempData["MessageType"] = "error";
                }
            }
            return View(resource);
        }
    }
}
