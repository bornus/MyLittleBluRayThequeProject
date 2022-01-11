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

        public BluRay GetBluRayById(long idBr)
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


        public List<BluRay> GetBlurays()
        {
            List<BluRay> bluRays = bluRayRepository.GetListeBluRay();

            if (bluRays == null)
            {
                throw new ArgumentException("Liste des BluRay non trouvé");
            }

            return bluRays;
        }

        public List<(long, string)> GetLangues()
        {
            List<(long, string)> langues = bluRayRepository.GetListLangues();

            if (langues == null)
            {
                throw new ArgumentException("Liste des langues non trouvé");
            }
            return langues;
        }

            //bluRay.Realisateur = personneRepository.GetRealisateurBr(idBr);

            //bluRay.Acteurs = personneRepository.GetActeursBr(idBr);

            return bluRay;
        }
    }
}
