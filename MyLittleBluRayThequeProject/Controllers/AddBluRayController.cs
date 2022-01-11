using Microsoft.AspNetCore.Mvc;
using MyLittleBluRayThequeProject.Business;
using MyLittleBluRayThequeProject.DTOs;
using MyLittleBluRayThequeProject.Models;

namespace MyLittleBluRayThequeProject.Controllers
{
    public class AddBluRayController : Controller
    {
        BluRayBusiness brBu = new BluRayBusiness();
        PersonneBusiness prBu = new PersonneBusiness();
        public IActionResult Index()
        {
            
            AddBluRayViewModel model = new AddBluRayViewModel();
            var list = prBu.GetListePersonne();
            var list2 = brBu.GetLangues();
            model.listReal = list;
            model.listActeurs = list;
            model.listScenar = list;
            model.listLangues = list2;
            model.listSsTitre = list2;
            return View(model);
        }

        [HttpPost]
        public ViewResult Index([FromForm] AddBlurayBodyViewModel body)
        {
            var titre = body.Titre;
            var scenariste = body.IdScenar;
            var realisateur = body.IdReal;
            var acteurs = body.IdsActeurs;
            var duree = body.duree;
            var dateSortie = body.dateSortie;
            var langues = body.langues;
            var ssTitre = body.ssTitres;
            var version = body.Version;

            AddBluRayViewModel model = new AddBluRayViewModel();
            var list = prBu.GetListePersonne();
            var list2 = brBu.GetLangues();
            model.listReal = list;
            model.listActeurs = list;
            model.listScenar = list;
            model.listLangues = list2;
            model.listSsTitre = list2;
            return View(model);
        }

    }
}
