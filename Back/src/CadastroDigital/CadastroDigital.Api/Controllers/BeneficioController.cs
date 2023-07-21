using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using CadastroDigital.App.Interfaces;

namespace CadastroDigital.Api.Controllers
{
    [Route("api/[controller]")]
    public class BeneficioController : Controller
    {
        private readonly IBeneficioService _beneficioService;
        private readonly IWebHostEnvironment _hostEnviroment;
        // private readonly ILogger<BeneficioController> _logger;

        // public BeneficioController(ILogger<BeneficioController> logger)
        public BeneficioController(IBeneficioService beneficioService, IWebHostEnvironment hostEnviroment)
        {
            _beneficioService = beneficioService;
            _hostEnviroment = hostEnviroment;
            // _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var beneficios = await _beneficioService.Get();

            if (beneficios == null)
                return NotFound("Nenhum registro encontrado.");

            return Ok(beneficios);
        }
    }
}