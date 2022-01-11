using Microsoft.AspNetCore.Mvc;
using MyLittleBluRayThequeProject.Business;
using MyLittleBluRayThequeProject.Models;
using System.Diagnostics;

namespace MyLittleBluRayThequeProject.Controllers
{
    public class ExtendedBluRayController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BluRayApiBusiness brBusiness;

        public ExtendedBluRayController(ILogger<HomeController> logger)
        {
            _logger = logger;
            brBusiness = new BluRayApiBusiness();
        }

        public IActionResult Index()
        {
            ExtendedIndexViewModel model = new ExtendedIndexViewModel();
            
            model.BluRays = brBusiness.GetBluRays().ToList();
            return View(model);
        }

        public IActionResult SelectedBluRay(long id)
        {
            ExtendedIndexViewModel model = new ExtendedIndexViewModel();
            model.BluRays = brBusiness.GetBluRays().ToList();
            model.SelectedBluRay = model.BluRays.FirstOrDefault(x => x.Id == id);
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}