using MyLittleBluRayThequeProject.DTOs;
using MyLittleBluRayThequeProject.Repositories;

namespace MyLittleBluRayThequeProject.Business
{
    public class BluRayApiBusiness
    {

        private readonly BluRayApiRepository bluRayApiRepository;

        public BluRayApiBusiness()
        {
            this.bluRayApiRepository = new BluRayApiRepository();
        }

        public List<BluRayApi> GetBluRays()
        {
            List<BluRayApi> bluRayApis = new List<BluRayApi>();
            List<SourceEmprunt> urls = bluRayApiRepository.getEmprunts();
            foreach (SourceEmprunt emprunt in urls)
            {
                bluRayApis.AddRange(bluRayApiRepository.GetBluRays(emprunt.Url));
            }
            if(bluRayApis.Count == 0)
            {
                bluRayApis.Add(new BluRayApi() { Id = 0, Titre="Aucun bluray n'a été trouvé"});
            }
            return bluRayApis;

        }

        public BluRayApi EmprunterBluRay(long brId)
        {
            //TODO lié avec sourceEmprunt dans la bdd
            List<SourceEmprunt> emprunts = bluRayApiRepository.getEmprunts();
            if (brId != null)
            {
                bluRayApiRepository.EmprunterBluRay(brId, emprunts.First());
            }
            return null;
        }
    }
}
