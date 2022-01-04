using MyLittleBluRayThequeProject.DTOs;

namespace MyLittleBluRayThequeProject.Models
{
    public class AddBluRayViewModel
    {
        public int id { get; set; }
        public string Titre { get; set; }

        public Personne Scenariste { get; set; }

        public Personne Realisateur { get; set; }

        public List<Personne> listActeurs { get; set; }

        public TimeSpan Duree { get; set; }

        public DateTime DateSortie { get; set; }

        public string Version { get; set; }

        public List<Personne> listReal { get; set; }

        public List<Personne> listScenar { get; set; }

        public List<string> listLangues { get; set; }

        public List<string> listSsTitre { get; set; }
    }
}
