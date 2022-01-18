using MyLittleBluRayThequeProject.DTOs;

namespace MyLittleBluRayThequeProject.Models
{
    public class AddBlurayBodyViewModel
    {

        public string Titre { get; set; }

        public long IdReal { get; set; }

        public long IdScenar { get; set; }

        public List<long> IdsActeurs { get; set; }

        public TimeSpan duree { get; set; }

        public DateTime dateSortie { get; set; }

        public List<(long, string)> langues { get; set; }

        public List<(long, string)> ssTitres { get; set; }

        public string Version { get; set; }

    }
}
