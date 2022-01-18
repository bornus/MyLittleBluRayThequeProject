﻿using MyLittleBluRayThequeProject.DTOs;
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

        public BluRay EmprunterBluRay(long idBr)
        {
            BluRay br = this.GetBluRay(idBr);
            if (br!= null && br.Disponible)
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

        public BluRay RendreBluRay(long idBr)
        {
            BluRay br = this.GetBluRay(idBr);
            if (br!= null && !br.Disponible)
            {
                bool success = bluRayRepository.EmpruntBluRay(idBr);
                if (success)
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
                return null;
            }
            return bluRay;
        }


        public IEnumerable<BluRay> GetBlurays()
        {
            List<BluRay> bluRays = bluRayRepository.GetListeBluRaySQL().ToList();

            if (bluRays == null)
            {
                throw new ArgumentException("Liste des BluRay non trouvé");
            }

            return bluRays;
        }

        public List<(long, string)> GetLangues()
        {
            List<(long, string)> langues = bluRayRepository.GetListLangues().ToList();

            if (langues == null)
            {
                throw new ArgumentException("Liste des langues non trouvé");
            }
            return langues;
        }

        public List<(long, string)> GetSsTitre()
        {
            List<(long, string)> ssTitres = bluRayRepository.GetListSsTitre().ToList();

            if (ssTitres == null)
            {
                throw new ArgumentException("Liste des sous titre non trouvé");
            }
            return ssTitres;
        }

        public void CreerBluRay(BluRay bluRay, long idRealisateur, long idScenariste, List<long> idsActeurs, List<long> ssTitres, List<long> langues)
        {
            bluRayRepository.PostBluRay(bluRay);
            bluRayRepository.LinkBluRayRealisateur(idRealisateur);
            bluRayRepository.LinkBluRayScenariste(idScenariste);
            bluRayRepository.LinkBluRayActeurs(idsActeurs);
            bluRayRepository.LinkBluRaySsTitres(ssTitres);
            bluRayRepository.LinkBluRayLangues(langues);

        }

        public void DeleteBluRay(long id)
        {
            Console.WriteLine("delete" + id);
            bluRayRepository.DeleteBluRaySsTitres(id);
            bluRayRepository.DeleteBluRayLangues(id);
            bluRayRepository.DeleteBluRayRealisateur(id);
            bluRayRepository.DeleteBlurayScenariste(id);
            bluRayRepository.DeleteBlurayActeurs(id);
            bluRayRepository.DeleteBluRay(id);
        }


       
    }
}