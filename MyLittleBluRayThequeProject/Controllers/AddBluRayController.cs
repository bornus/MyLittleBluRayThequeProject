using Microsoft.AspNetCore.Mvc;
using MyLittleBluRayThequeProject.DTOs;
using MyLittleBluRayThequeProject.Models;
using MyLittleBluRayThequeProject.Repositories;
using MyLittleBluRayThequeProject.Business;

namespace MyLittleBluRayThequeProject.Controllers
{
    public class AddBluRayController : Controller
    {

        BluRayBusiness brBusiness = new BluRayBusiness();
        PersonneBusiness prBusiness = new PersonneBusiness();

        public IActionResult Index()
        {   AddBluRayViewModel model = new AddBluRayViewModel();
            model.listReal = prBusiness.GetListPersonnes();
            model.listActeurs = prBusiness.GetListPersonnes();
            model.listScenar = prBusiness.GetListPersonnes();
            model.listLangues = brBusiness.GetLangues();
            model.listSsTitre = brBusiness.GetLangues();
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
            br.Version = version;
            brBusiness.CreerBluRay(br, idRealisateur, idScenariste, idsActeurs, ssTitre, langues);

            AddBluRayViewModel model = new AddBluRayViewModel();
            model.listReal = prBusiness.GetListPersonnes();
            model.listActeurs = prBusiness.GetListPersonnes();
            model.listScenar = prBusiness.GetListPersonnes();
            model.listLangues = brBusiness.GetLangues();
            model.listSsTitre = brBusiness.GetLangues();
            return View(model);
        }

    }
}
