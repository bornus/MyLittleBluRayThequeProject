﻿using Microsoft.AspNetCore.Mvc;
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
        {
            var list = new List<Personne>
                    {
                        new Personne
                        {
                            Id = 0,
                            Nom = "nom 0 ",
                            Prenom = "prenom 0",
                            Nationalite = "Fr",
                            DateNaissance = DateTime.Now,
                            Professions = new List<string>{"Acteur"}
                        },
                        new Personne
                        {
                            Id = 1,
                            Nom = "nom 1",
                            Prenom = "prenom 1",
                            Nationalite = "Fr",
                            DateNaissance = DateTime.Now,
                            Professions = new List<string>{"Acteur"}
                        }
                    };

            AddBluRayViewModel model = new AddBluRayViewModel();
            model.listReal = prRepo.GetListRealisateurs();
            model.listActeurs = prRepo.GetListActeurs();
            model.listScenar = prRepo.GetListScenaristes();
            model.listLangues = brRepo.GetListLangues();
            model.listSsTitre = brRepo.GetListLangues();
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

            var br = new BluRay();
            br.Titre = titre;
            br.Duree = duree;
            br.DateSortie = dateSortie;
            br.Langues = langues;
            br.SsTitres = ssTitre;
            br.Version = version;

            brRepo.PostBluRay(br);


            var list = new List<Personne>
                    {
                        new Personne
                        {
                            Id = 0,
                            Nom = "nom 0 ",
                            Prenom = "prenom 0",
                            Nationalite = "Fr",
                            DateNaissance = DateTime.Now,
                            Professions = new List<string>{"Acteur"}
                        },
                        new Personne
                        {
                            Id = 1,
                            Nom = "nom 1",
                            Prenom = "prenom 1",
                            Nationalite = "Fr",
                            DateNaissance = DateTime.Now,
                            Professions = new List<string>{"Acteur"}
                        }
                    };


            AddBluRayViewModel model = new AddBluRayViewModel();
            model.listReal = prRepo.GetListRealisateurs();
            model.listActeurs = prRepo.GetListActeurs();
            model.listScenar = prRepo.GetListScenaristes();
            model.listLangues = brRepo.GetListLangues();
            model.listSsTitre = brRepo.GetListLangues();
            return View(model);
        }

    }
}
