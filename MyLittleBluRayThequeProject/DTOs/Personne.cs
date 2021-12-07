namespace MyLittleBluRayThequeProject.DTOs
{
    public class Personne
    {
        /// <summary>
        /// Identifiant technique
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Nom de la personne
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Prénom de la personne
        /// </summary>
        public string Prenom { get; set; }
        
        /// <summary>
        /// Date de naissance de la personne
        /// </summary>
        public DateTime DateNaissance { get; set; }

        /// <summary>
        /// Nationalité de la personne
        /// </summary>
        public string Nationalite { get; set; }

        /// <summary>
        /// Professions de la personne
        /// </summary>
        public List<string> Professions { get; set; }
    }
}
