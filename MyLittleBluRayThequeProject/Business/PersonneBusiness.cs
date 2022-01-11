using MyLittleBluRayThequeProject.Repositories;
using MyLittleBluRayThequeProject.DTOs;

namespace MyLittleBluRayThequeProject.Business
{
    public class PersonneBusiness
    {
        PersonneRepository personneRepository = new PersonneRepository();
        public List<Personne> GetListPersonnes()
        {
            List<Personne> personnes = personneRepository.GetListPersonnes();

            if (personnes == null)
            {
                throw new ArgumentException("Liste des personnes non trouvé");
            }
            return personnes;
        }
    }
}
