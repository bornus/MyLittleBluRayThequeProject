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
            List<string> urls = bluRayApiRepository.getUrls();
            foreach (string url in urls)
            {
                bluRayApis.AddRange(bluRayApiRepository.GetBluRays(url));
            }
            if(bluRayApis.Count == 0)
            {
                bluRayApis.Add(new BluRayApi() { Id = 0, Titre="Aucun bluray n'a été trouvé"});
            }
            return bluRayApis;

        }

        public BluRayApi EmprunterBluRay(BluRayApi brApi)
        {
            if (brApi.FromUrl != null)
            {
                bluRayApiRepository.EmprunterBluRay(brApi, brApi.FromUrl);
            }
            return null;
        }
    }
}
