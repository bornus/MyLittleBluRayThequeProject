using MyLittleBluRayThequeProject.DTOs;

namespace MyLittleBluRayThequeProject.Models
{
    public class IndexViewModel
    {
        public List<BluRay> BluRays { get; set; }

        public BluRay SelectedBluRay { get; set; }
    }
}
