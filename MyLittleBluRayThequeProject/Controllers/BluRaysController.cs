using Microsoft.AspNetCore.Mvc;
using MyLittleBluRayThequeProject.Models;

namespace MyLittleBluRayThequeProject.Controllers
{
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

            private readonly BluRayRepository brRepository;

            public BluRaysController(ILogger<BluRaysController> logger)
            {
                _logger = logger;
                brRepository = new BluRayRepository();
            }

            [HttpGet()]
            public ObjectResult Get()
            {
                List<BluRay> br = brRepository.GetListeBluRay();
                List<InfoBluRayApiViewModel> bluRays = br.ConvertAll(InfoBluRayApiViewModel.ToModel);
                return new OkObjectResult(bluRays);
            }

            [HttpPost("{IdBluray}/Emprunt")]
            public ObjectResult EmprunterBluRay([FromRoute] IdBluRayRoute route)
            {
                return new CreatedResult($"{route.IdBluray}", null);
            }
        }
    }
}
