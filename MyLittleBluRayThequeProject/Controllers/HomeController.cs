using Microsoft.AspNetCore.Mvc;
using MyLittleBluRayThequeProject.DTOs;
using MyLittleBluRayThequeProject.Models;
using MyLittleBluRayThequeProject.Repositories;
using System.Diagnostics;

namespace MyLittleBluRayThequeProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly BluRayRepository brRepository;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            brRepository = new BluRayRepository();
        }

        public IActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();
            
            model.BluRays = brRepository.GetListeBluRay();
            foreach(BluRay bray in model.BluRays)
            {
                //brRepository.PostBluRay(bray);
            }
            return View(model);
        }

        public IActionResult SelectedBluRay([FromRoute]long idBr)
        {
            IndexViewModel model = new IndexViewModel();
            model.BluRays = brRepository.GetListeBluRay();
            model.SelectedBluRay = model.BluRays.FirstOrDefault(x => x.Id == idBr);
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