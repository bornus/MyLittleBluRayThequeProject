using MyLittleBluRayThequeProject.DTOs;
using MyLittleBluRayThequeProject.Repositories;

namespace MyLittleBluRayThequeProject.Business
{
    public class PersonneBusiness
    {

        PersonneRepository prRepo = new PersonneRepository();
        public List<Personne> GetListePersonne()
        {
            List<Personne> personnes = prRepo.GetListPersonnes();

            if (personnes == null)
            {
                throw new ArgumentException("Liste des sous titre non trouvé");
            }
            return personnes;
        }

    }
}
