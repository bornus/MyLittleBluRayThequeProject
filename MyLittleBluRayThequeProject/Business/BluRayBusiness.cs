using MyLittleBluRayThequeProject.DTOs;
using MyLittleBluRayThequeProject.Repositories;

namespace MyLittleBluRayThequeProject.Business
{
    public class BluRayBusiness
    {

        private readonly BluRayRepository bluRayRepository;

        public BluRayBusiness()
        {
            this.bluRayRepository = new BluRayRepository();
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
            List<BluRay> bluRays = bluRayRepository.GetListeBluRaySQL();

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

        public List<(long, string)> GetSsTitre()
        {
            List<(long, string)> ssTitres = bluRayRepository.GetListSsTitre();

            if (ssTitres == null)
            {
                throw new ArgumentException("Liste des sous titre non trouvé");
            }
            return ssTitres;
        }

        public void CreerBluRay(BluRay bluRay, long idRealisateur, long idScenariste, List<long> idsActeurs, List<string> ssTitres, List<string> langues)
        {
            bluRayRepository.PostBluRay(bluRay, idRealisateur, idScenariste, idsActeurs);
            bluRayRepository.LinkBluRayRealisateur(bluRay, idRealisateur);
            bluRayRepository.LinkBluRayScenariste(bluRay, idScenariste);
            bluRayRepository.LinkBluRayActeurs(bluRay, idsActeurs);
            bluRayRepository.LinkBluRaySsTitres(bluRay, ssTitres);
            bluRayRepository.LinkBluRayLangues(bluRay, langues);

        }


    }
}
