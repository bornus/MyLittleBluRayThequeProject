using MyLittleBluRayThequeProject.DTOs;

namespace MyLittleBluRayThequeProject.Models
{
    public class InfoBluRayApiViewModel
    {
        /// <summary>
        /// Identifiant technique
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Titre du film contenu sur le Blu-Ray
        /// </summary>
        public string Titre { get; set; }

        /// <summary>
        /// Version du film contenu sur le Blu-Ray
        /// </summary>
        public string Version { get; set; }

        public static InfoBluRayApiViewModel ToModel(BluRay dto)
        {
            if (dto == null)
            {
                return null;
            }
            return new InfoBluRayApiViewModel { Id = dto.Id, Titre = dto.Titre, Version = dto.Version };
        }
    }
}
