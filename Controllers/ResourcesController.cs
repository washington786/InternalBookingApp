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

        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult Details()
        {
            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }
    }
}
