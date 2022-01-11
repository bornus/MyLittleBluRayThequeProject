using Microsoft.AspNetCore.Mvc;
using MyLittleBluRayThequeProject.DTOs;
using MyLittleBluRayThequeProject.Models;
using MyLittleBluRayThequeProject.Repositories;

namespace MyLittleBluRayThequeProject.Controllers
{
    public class AddBluRayController : Controller
    {

        BluRayRepository brRepo = new BluRayRepository();
        PersonneRepository prRepo = new PersonneRepository();

        public IActionResult Index()
        {   AddBluRayViewModel model = new AddBluRayViewModel();
            model.listReal = prRepo.GetListPersonnes();
            model.listActeurs = prRepo.GetListPersonnes();
            model.listScenar = prRepo.GetListPersonnes();
            model.listLangues = brRepo.GetListLangues();
            model.listSsTitre = brRepo.GetListLangues();
            return View(model);
        }

        [HttpPost]
        public ViewResult Index([FromForm] AddBlurayBodyViewModel body)
        {
            var titre = body.Titre;
            var idScenariste = body.IdScenar;
            var idRealisateur = body.IdReal;
            var idsActeurs = body.IdsActeurs;
            var duree = body.duree;
            var dateSortie = body.dateSortie;
            var langues = body.langues;
            var ssTitre = body.ssTitres;
            var version = body.Version;

            var br = new BluRay();
            br.Titre = titre;
            br.Duree = duree;
            br.DateSortie = dateSortie;
            br.Langues = langues;
            br.SsTitres = ssTitre;
            br.Version = version;

            brRepo.PostBluRay(br, idRealisateur, idScenariste, idsActeurs);

            AddBluRayViewModel model = new AddBluRayViewModel();
            model.listReal = prRepo.GetListPersonnes();
            model.listActeurs = prRepo.GetListPersonnes();
            model.listScenar = prRepo.GetListPersonnes();
            model.listLangues = brRepo.GetListLangues();
            model.listSsTitre = brRepo.GetListLangues();
            return View(model);
        }

    }
}
