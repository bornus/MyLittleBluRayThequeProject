namespace MyLittleBluRayThequeProject.DTOs
{
    /// <summary>
    /// Dto d'un Disque Blu-Ray
    /// </summary>
    public class SourceEmprunt
    {
        /// <summary>
        /// Identifiant technique
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Titre du film contenu sur le Blu-Ray
        /// </summary>
        public string Nom { get; set; }


        public string Url { get; set; }
    }
}
