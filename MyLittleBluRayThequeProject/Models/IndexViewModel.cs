using MyLittleBluRayThequeProject.DTOs;

namespace MyLittleBluRayThequeProject.Models
{
    public class IndexViewModel
    {
        public List<InfoBluRayViewModel> BluRays { get; set; }

        public BluRay SelectedBluRay { get; set; }
    }
}
