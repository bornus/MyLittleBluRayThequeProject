using MyLittleBluRayThequeProject.DTOs;

namespace MyLittleBluRayThequeProject.Models
{
    public class ExtendedIndexViewModel
    {
        public List<BluRayApi> BluRays { get; set; }

        public BluRayApi SelectedBluRay { get; set; }
    }
}
