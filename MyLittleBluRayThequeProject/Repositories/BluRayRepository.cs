using MyLittleBluRayThequeProject.DTOs;

namespace MyLittleBluRayThequeProject.Repositories
{
    public class BluRayRepository
    {
        /// <summary>
        /// Consctructeur par défaut
        /// </summary>
        public BluRayRepository()
        {

        }

        public List<BluRay> GetListeBluRay()
        {
            return new List<BluRay>
            {
                new BluRay
                {
                    Id = 0,
                    Titre = "My Little film 1",
                    DateSortie = DateTime.Now,
                    Version = "Courte",
                    Acteurs = new List<Personne>
                    {
                        new Personne
                        {
                            Id = 0,
                            Nom = "Per",
                            Prenom = "Sonne",
                            Nationalite = "Fr",
                            DateNaissance = DateTime.Now,
                            Professions = new List<string>{"Acteur"}
                        }
                    },
                    Langues = new List<string>
                    {
                        "francais", "anglais"
                    },
                    SsTitres = new List<string>
                    {
                        "francais", "anglais"
                    },
                    Duree = new TimeSpan(2, 15, 45),
                },
                new BluRay
                {
                    Id = 1,
                    Titre = "My Little film 2",
                    DateSortie = DateTime.Now,
                    Version = "Longue",
                    Acteurs = new List<Personne>
                    {
                        new Personne
                        {
                            Id = 0,
                            Nom = "Per",
                            Prenom = "Sonne",
                            Nationalite = "Fr",
                            DateNaissance = DateTime.Now,
                            Professions = new List<string>{"Acteur"}
                        }
                    },
                    Langues = new List<string>
                    {
                        "francais", "anglais"
                    },
                    SsTitres = new List<string>
                    {
                        "francais", "anglais"
                    },
                    Duree = new TimeSpan(1, 25, 00),
                }
            };
        }
    }
}
