using System.ComponentModel.DataAnnotations;

namespace MyLittleBluRayThequeProject.Models
{
    public class IdBluRayRoute
    {
        /// <summary>
        /// L'Id du BluRay dans une route d'api
        /// </summary>
        [Required]
        public long IdBluray { get; set; }
    }
}
