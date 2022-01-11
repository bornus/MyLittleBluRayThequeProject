﻿namespace MyLittleBluRayThequeProject.DTOs
{
    public class BluRayApi
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

        /// <summary>
        /// Le flag de la disponibilité du BluRay
        /// </summary>
        public bool Disponible { get; set; }
    }
}
