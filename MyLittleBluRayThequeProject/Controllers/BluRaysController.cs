using Microsoft.AspNetCore.Mvc;
using MyLittleBluRayThequeProject.Models;

namespace MyLittleBluRayThequeProject.Controllers
{
    using global::MyLittleBluRayThequeProject.Business;
    using global::MyLittleBluRayThequeProject.DTOs;
    using global::MyLittleBluRayThequeProject.Repositories;
    using Microsoft.AspNetCore.Mvc;

    namespace MyLittleBluRayThequeProject.Controllers
    {
        [ApiController]
        [Route("[controller]")]
        public class BluRaysController
        {
            private readonly ILogger<BluRaysController> _logger;

            private readonly BluRayBusiness brManager;

            public BluRaysController(ILogger<BluRaysController> logger)
            {
                _logger = logger;
                brManager = new BluRayBusiness();
            }

            [HttpGet()]
            public ObjectResult Get()
            {
                List<BluRay> br = brManager.GetBluRays().ToList();
                List<InfoBluRayApiViewModel> bluRays = br.ConvertAll(InfoBluRayApiViewModel.ToModel);
                return new OkObjectResult(bluRays);
            }

            [HttpPost("{IdBluray}/Emprunt")]
            public ObjectResult EmprunterBluRay([FromRoute] IdBluRayRoute route)
            {
                BluRay br = brManager.EmprunterBluRay(route.IdBluray);
                if(br != null)
                {
                    return new CreatedResult($"{route.IdBluray}", br);

                }
                return new NotFoundObjectResult(route.IdBluray);
            }
        }
    }
}
