using Microsoft.AspNetCore.Mvc;
using MyLittleBluRayThequeProject.Business;
using MyLittleBluRayThequeProject.Models;
using MyLittleBluRayThequeProject.Repositories;
using System.Diagnostics;

namespace MyLittleBluRayThequeProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly BluRayRepository brRepository;

        private readonly BluRayBusiness brBusiness;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            brRepository = new BluRayRepository();
            brBusiness = new BluRayBusiness();
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
                model.SelectedBluRay = brBusiness.GetBluRay(id.Value);
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