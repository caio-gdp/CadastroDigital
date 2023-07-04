using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using CadastroDigital.App.Interfaces;

namespace CadastroDigital.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CidadeController : ControllerBase
    {
        private readonly ICidadeService _cidadeService;
        private readonly IWebHostEnvironment _hostEnviroment;

        public CidadeController(ICidadeService cidadeService, IWebHostEnvironment hostEnviroment){
            _cidadeService = cidadeService;
            _hostEnviroment = hostEnviroment;
        }

        [HttpGet("estado/{estado}")]
        public async Task<IActionResult> GetCidadeByEstado(int estado)
        {
            var cidades = await _cidadeService.GetCidadeByEstado(estado);

            if (cidades.Equals(null))
                 return NotFound("");

             return Ok(cidades);
        }
    }
}