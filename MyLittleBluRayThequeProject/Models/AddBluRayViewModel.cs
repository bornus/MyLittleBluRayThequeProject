using Microsoft.AspNetCore.Mvc;
using MyLittleBluRayThequeProject.DTOs;

namespace MyLittleBluRayThequeProject.Models
{
    public class AddBluRayViewModel
    {
        public int id { get; set; }
        public string Titre { get; set; }

        public Personne Scenariste { get; set; }

        public Personne Realisateur { get; set; }

        public List<Personne> Acteurs { get; set; }

        public TimeSpan Duree { get; set; }

        public DateTime DateSortie { get; set; }

        public List<string> Langues { get; set; }

        public List<string> SsTitres { get; set; }

        public string Version { get; set; }

    }
}
