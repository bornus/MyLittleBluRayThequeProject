using MyLittleBluRayThequeProject.DTOs;
using MyLittleBluRayThequeProject.Repositories;

namespace MyLittleBluRayThequeProject.Business
{
    public class BluRayBusiness
    {

        private readonly BluRayRepository bluRayRepository;
        private readonly PersonneRepository personneRepository;

        public BluRayBusiness()
        {
            this.bluRayRepository = new BluRayRepository();
            this.personneRepository = new PersonneRepository();
        }

        public IEnumerable<BluRay> GetBluRays()
        {
            return bluRayRepository.GetListeBluRaySQL();

        }

        public BluRay EmprunterBluRay(long idBr)
        {
            BluRay br = this.GetBluRay(idBr);
            if (br.Disponible)
            {
                bool success = bluRayRepository.EmpruntBluRay(idBr);
                if (!success)
                {
                    throw new ArgumentException($"L'emprunt a échoué pour le bluray d'id :{idBr}");
                }
                else
                {
                    return br;
                }
            }
            return null;
        }

        public BluRay GetBluRay(long idBr)
        {
            BluRay bluRay = bluRayRepository.GetBluRay(idBr);

            if (bluRay == null)
            {
                throw new ArgumentException($"Bluray d'id :{idBr} non trouvé");
            }

            //bluRay.Realisateur = personneRepository.GetRealisateurBr(idBr);

            //bluRay.Acteurs = personneRepository.GetActeursBr(idBr);

            return bluRay;
        }
    }
}
