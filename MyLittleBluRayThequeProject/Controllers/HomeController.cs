using Microsoft.AspNetCore.Mvc;
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

        //public IActionResult Index()
        //{
        //    IndexViewModel model = new IndexViewModel();
        //    model.BluRays = brRepository.GetListeBluRay();
        //    return View(model);
        //}

        public IActionResult Index(long? id)
        {
            IndexViewModel model = new IndexViewModel();
            var br = brRepository.GetListeBluRay();
            model.BluRays = br.ConvertAll(InfoBluRayViewModel.ToModel);
            if (id != null)
            {
                model.SelectedBluRay = br.FirstOrDefault(x => x.Id == id);
            }
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