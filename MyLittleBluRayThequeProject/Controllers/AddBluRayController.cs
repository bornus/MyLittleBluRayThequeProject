using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLittleBluRayThequeProject.Models;

namespace MyLittleBluRayThequeProject.Controllers
{
    public class AddBluRayController : Controller
    {
        public IActionResult Index()
        {
            AddBluRayViewModel model = new AddBluRayViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int? id)
        {
            AddBluRayViewModel model = new AddBluRayViewModel();
            var titre = Request.Form["Titre"];
            var scenariste = Request.Form["scenariste"];
            var realisateur = Request.Form["realisteur"];
            var acteurs = Request.Form["acteurs"];
            var duree = Request.Form["duree"];
            var dateSortie = Request.Form["dateSortie"];
            var langues = Request.Form["langues"];
            var ssTitre = Request.Form["ssTitre"];
            var version = Request.Form["version"];

            Console.WriteLine(titre +""+ scenariste+""+ realisateur+""+ acteurs+ ""+duree+ ""+dateSortie+""+ langues+""+ssTitre+""+version);
            return View(model);
        }
    }
}
