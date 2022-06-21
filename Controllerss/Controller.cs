using Kolokwium_poprawa.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium_poprawa.Controllerss
{
    [Route("api")]
    [ApiController]
    public class Controller : ControllerBase
    {
        private readonly IDbService _dbService;
        public Controller(IDbService dbService)
        {
            _dbService = dbService;
        }

        //[HttpGet("{id}")]

    }
}
