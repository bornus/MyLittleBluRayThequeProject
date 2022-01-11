using MyLittleBluRayThequeProject.DTOs;

namespace MyLittleBluRayThequeProject.Models
{
    public class InfoBluRayViewModel
    {
        /// <summary>
        /// Identifiant technique
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Titre du film contenu sur le Blu-Ray
        /// </summary>
        public string Titre { get; set; }

        public static InfoBluRayViewModel ToModel(BluRay dto)
        {
            if (dto == null)
            {
                return null;
            }
            return new InfoBluRayViewModel { Id = dto.Id, Titre = dto.Titre };
        }
    }
}
